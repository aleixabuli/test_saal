#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Infra.FoodDelivery.Api/Infra.FoodDelivery.Api.csproj", "Infra.FoodDelivery.Api/"]
RUN dotnet restore "./Infra.FoodDelivery.Api/./Infra.FoodDelivery.Api.csproj"
COPY . .
WORKDIR "/src/Infra.FoodDelivery.Api"
RUN dotnet build "./Infra.FoodDelivery.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Infra.FoodDelivery.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Infra.FoodDelivery.Api.dll"]