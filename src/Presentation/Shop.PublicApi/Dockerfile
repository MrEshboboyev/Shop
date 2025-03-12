FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

# Specifies whether .NET welcome and telemetry messages are displayed on the first run.
ENV DOTNET_NOLOGO=1

# Specifies whether data about the .NET tools usage is collected and sent to Microsoft.
ENV DOTNET_CLI_TELEMETRY_OPTOUT=1


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src
COPY ["Directory.Packages.props", "."]
COPY ["Directory.Build.props", "."]
COPY ["src/Presentation/Shop.PublicApi/Shop.PublicApi.csproj", "src/Presentation/Shop.PublicApi/"]
COPY ["src/Core/Shop.Application/Shop.Application.csproj", "src/Core/Shop.Application/"]
COPY ["src/Core/Shop.Core/Shop.Core.csproj", "src/Core/Shop.Core/"]
COPY ["src/Core/Shop.Domain/Shop.Domain.csproj", "src/Core/Shop.Domain/"]
COPY ["src/Core/Shop.Query/Shop.Query.csproj", "src/Core/Shop.Query/"]
COPY ["src/Infrastructure/Shop.Infrastructure/Shop.Infrastructure.csproj", "src/Infrastructure/Shop.Infrastructure/"]
RUN dotnet restore "./src/Presentation/Shop.PublicApi/Shop.PublicApi.csproj"
COPY . .
WORKDIR "/src/src/Presentation/Shop.PublicApi"
RUN dotnet build "Shop.PublicApi.csproj" --configuration Release --no-restore --nologo --output /app/build 

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
RUN dotnet publish "Shop.PublicApi.csproj" --configuration Release --no-restore --nologo --output /app/publish

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Shop.PublicApi.dll"]