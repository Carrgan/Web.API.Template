FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/WebApi/Template.Web.Api/Template.Web.Api.csproj", "src/WebApi/Template.Web.Api/"]
RUN dotnet restore "src/WebApi/Template.Web.Api/Template.Web.Api.csproj"
COPY . .
WORKDIR "/src/src/WebApi/Template.Web.Api"
RUN dotnet build "Template.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Template.Web.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Template.Web.Api.dll"]
