FROM node:20-alpine AS frontend-build
WORKDIR /src/frontend
COPY frontend/package.json ./
RUN npm install
COPY frontend/ ./
RUN npm run build

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS api-build
WORKDIR /src
COPY backend/WexaGraph.Api/WexaGraph.Api.csproj backend/WexaGraph.Api/
RUN dotnet restore backend/WexaGraph.Api/WexaGraph.Api.csproj
COPY backend/WexaGraph.Api/ backend/WexaGraph.Api/
RUN dotnet publish backend/WexaGraph.Api/WexaGraph.Api.csproj -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080
COPY --from=api-build /app/publish ./
COPY --from=frontend-build /src/frontend/dist/wexa/browser ./wwwroot
ENTRYPOINT ["dotnet","WexaGraph.Api.dll"]
