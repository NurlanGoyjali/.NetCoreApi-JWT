using System.Text;
using System.Threading.Tasks;
using Ecom.Bussines.Complex_Type;
using Ecom.Bussines.Conrete;
using Ecom.DataAccess.ComplexType;
using Ecom.DataAccess.Concrete;
using Ecom.DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace Ecom.Api
{
  public class Startup
  {
    private string _key = "hbjhbuvbytvghbkjhvbıytvhvbkghıtgvıyutvcytcyctrfcycvnu";
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    readonly string Policy = "Policy";
    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddControllers();
      services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Ecom.Api", Version = "v1" }); });
      services.AddScoped<IProductDal, EfProductDal>();
      services.AddScoped<IProductService, ProductManager>();
      services.AddScoped<IUserDal, EfUserDal>();
      services.AddScoped<IUserService, UserManager>();
      services.AddScoped<IBuyDal, EFBuyDal>();
      services.AddScoped<ISellDal, EFSellDal>();
      services.AddAuthentication(x =>
          {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
          }).AddJwtBearer("Bearer", x =>
            {
              x.RequireHttpsMetadata = false;
              x.SaveToken = true;
              x.TokenValidationParameters = new TokenValidationParameters
              {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_key)),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
              };
            }
           );
      services.AddSingleton<IJWTService>(new JWTManager(_key));

      services.AddCors(options =>{ options.AddPolicy(Policy, builder => builder
                      .WithOrigins() .SetIsOriginAllowed(origin => true) .AllowCredentials() .AllowAnyHeader()
                      .WithMethods("PUT", "DELETE", "GET")
              );
      });



      services.AddAutoMapper(typeof(Startup));
    }



    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ecom.Api v1"));
      }
      app.UseCors("Policy");
      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();



      });

    }
  }
}
