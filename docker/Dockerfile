FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copia apenas os .csproj primeiro (cache de restore em camadas)
COPY CBTech.sln .
COPY src/CBTech.Domain/CBTech.Domain.csproj src/CBTech.Domain/
COPY src/CBTech.Application/CBTech.Application.csproj src/CBTech.Application/
COPY src/CBTech.Infrastructure/CBTech.Infrastructure.csproj src/CBTech.Infrastructure/
COPY src/CBTech.Api/CBTech.Api.csproj src/CBTech.Api/
RUN dotnet restore src/CBTech.Api/CBTech.Api.csproj

# Copia o restante e publica
COPY . .
RUN dotnet publish src/CBTech.Api/CBTech.Api.csproj -c Release -o /app/publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "CBTech.Api.dll"]
