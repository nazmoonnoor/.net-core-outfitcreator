#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/OutfitCreator/OutfitCreator.Service/OutfitCreator.Service.csproj", "src/Services/OutfitCreator/OutfitCreator.Service/"]
COPY ["src/Services/OutfitCreator/OutfitCreator/OutfitCreator.csproj", "src/Services/OutfitCreator/OutfitCreator/"]
COPY ["src/Services/OutfitCreator/OutfitCreator.Infrastructure/OutfitCreator.Infrastructure.csproj", "src/Services/OutfitCreator/OutfitCreator.Infrastructure/"]
COPY ["src/Services/OutfitCreator/OutfitCreator.Core/OutfitCreator.Core.csproj", "src/Services/OutfitCreator/OutfitCreator.Core/"]
COPY ["src/Core/OutfitCreator.SharedKernel/OutfitCreator.SharedKernel.csproj", "src/Core/OutfitCreator.SharedKernel/"]
RUN dotnet restore "src/Services/OutfitCreator/OutfitCreator.Service/OutfitCreator.Service.csproj"
COPY . .
WORKDIR "/src/src/Services/OutfitCreator/OutfitCreator.Service"
RUN dotnet build "OutfitCreator.Service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OutfitCreator.Service.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OutfitCreator.Service.dll"]