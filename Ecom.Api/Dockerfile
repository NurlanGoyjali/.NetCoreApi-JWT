FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Ecom.Api/Ecom.Api.csproj", "Ecom.Api/"]
RUN dotnet restore "Ecom.Api/Ecom.Api.csproj"
COPY . .
WORKDIR "/src/Ecom.Api"
RUN dotnet build "Ecom.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecom.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecom.Api.dll"]
