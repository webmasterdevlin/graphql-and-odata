#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk AS build
WORKDIR /src
COPY ["TheGameShop.Api/TheGameShop.Api.csproj", "TheGameShop.Api/"]
RUN dotnet restore "TheGameShop.Api/TheGameShop.Api.csproj"
COPY . .
WORKDIR "/src/TheGameShop.Api"
RUN dotnet build "TheGameShop.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TheGameShop.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TheGameShop.Api.dll"]