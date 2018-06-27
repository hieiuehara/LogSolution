# mssql-server-linux
# Maintainers: Microsoft Corporation (LuisBosquez and twright-msft on GitHub)
# GitRepo: https://github.com/Microsoft/mssql-docker

# Base OS layer: Latest Ubuntu LTS.
FROM ubuntu:16.04

# Default SQL Server TCP/Port.
EXPOSE 1433

# Copy all SQL Server runtime files from build drop into image.
COPY . .

# Run SQL Server process.
CMD [ "/opt/mssql/bin/sqlservr" ]

FROM microsoft/dotnet:latest AS build-env

WORKDIR /app

# Copiar csproj e restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Build da aplicacao
COPY . ./
RUN dotnet publish -c Release -o out UeharaApi_91Tel.csproj
FROM microsoft/dotnet:latest
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "UeharaApi_91Tel.dll"]