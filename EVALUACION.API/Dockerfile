FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["EVALUACION.API/EVALUACION.API.csproj", "EVALUACION.API/"]
RUN dotnet restore "EVALUACION.API/EVALUACION.API.csproj"
COPY . .
WORKDIR "/src/EVALUACION.API"
RUN dotnet build "EVALUACION.API.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EVALUACION.API.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EVALUACION.API.dll"]