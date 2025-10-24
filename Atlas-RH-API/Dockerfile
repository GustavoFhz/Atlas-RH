# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copiar solução e projetos
COPY *.sln ./
COPY backend/*.csproj backend/
COPY "Atlas-RH-Testes/*.csproj" "Atlas-RH-Testes/"

# Restaurar dependências
RUN dotnet restore

# Copiar todo o código
COPY . ./

# Publicar o backend
WORKDIR /app/backend
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app/backend/out ./

EXPOSE 5000
ENTRYPOINT ["dotnet", "backend.dll"]
