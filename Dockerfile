#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk AS build
WORKDIR /src
COPY ["TheShop.Api/TheShop.Api.csproj", "TheShop.Api/"]
RUN dotnet restore "TheShop.Api/TheShop.Api.csproj"
COPY . .
WORKDIR "/src/TheShop.Api"
RUN dotnet build "TheShop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheShop.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheShop.Api.dll"]