#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BookStoreWebApp/BookStoreWebApp.csproj", "BookStoreWebApp/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
RUN dotnet restore "BookStoreWebApp/BookStoreWebApp.csproj"
COPY . .
WORKDIR "/src/BookStoreWebApp"
RUN dotnet build "BookStoreWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BookStoreWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BookStoreWebApp.dll"]
