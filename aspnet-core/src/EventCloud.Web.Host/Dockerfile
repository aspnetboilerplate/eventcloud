FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build

WORKDIR /src
COPY ["src/EventCloud.Web.Host/EventCloud.Web.Host.csproj", "src/EventCloud.Web.Host/"]
COPY ["src/EventCloud.Web.Core/EventCloud.Web.Core.csproj", "src/EventCloud.Web.Core/"]
COPY ["src/EventCloud.Application/EventCloud.Application.csproj", "src/EventCloud.Application/"]
COPY ["src/EventCloud.Core/EventCloud.Core.csproj", "src/EventCloud.Core/"]
COPY ["src/EventCloud.EntityFrameworkCore/EventCloud.EntityFrameworkCore.csproj", "src/EventCloud.EntityFrameworkCore/"]
WORKDIR "/src/src/EventCloud.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/EventCloud.Web.Host", "src/EventCloud.Web.Host"]
COPY ["src/EventCloud.Web.Core", "src/EventCloud.Web.Core"]
COPY ["src/EventCloud.Application", "src/EventCloud.Application"]
COPY ["src/EventCloud.Core", "src/EventCloud.Core"]
COPY ["src/EventCloud.EntityFrameworkCore", "src/EventCloud.EntityFrameworkCore"]
WORKDIR "/src/src/EventCloud.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "EventCloud.Web.Host.dll"]
