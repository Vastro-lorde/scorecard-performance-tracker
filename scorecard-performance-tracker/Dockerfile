#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["scorecard-performance-tracker/scorecard-performance-tracker.csproj", "scorecard-performance-tracker/"]
RUN dotnet restore "scorecard-performance-tracker/scorecard-performance-tracker.csproj"
COPY . .
WORKDIR "/src/scorecard-performance-tracker"
RUN dotnet build "scorecard-performance-tracker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "scorecard-performance-tracker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "scorecard-performance-tracker.dll"]
