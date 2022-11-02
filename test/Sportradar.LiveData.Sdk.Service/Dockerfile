#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Sportradar.LiveData.Sdk.Service/Sportradar.LiveData.Sdk.Service.csproj", "Sportradar.LiveData.Sdk.Service/"]
RUN dotnet restore "Sportradar.LiveData.Sdk.Service/Sportradar.LiveData.Sdk.Service.csproj"
COPY . .
WORKDIR "/src/Sportradar.LiveData.Sdk.Service"
RUN dotnet build "Sportradar.LiveData.Sdk.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sportradar.LiveData.Sdk.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sportradar.LiveData.Sdk.Service.dll"]