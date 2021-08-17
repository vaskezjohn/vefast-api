#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build-env
WORKDIR /app
# Copy csproj and restore as distinct layers
#COPY *.csproj ./
COPY . ./
RUN ls -la
RUN dotnet restore ui/vefast-api/vefast-api.csproj
# Copy everything else and build

RUN dotnet publish ui/vefast-api/vefast-api.csproj -c Release -o out
# Build runtime image
FROM  mcr.microsoft.com/dotnet/sdk:5.0-alpine
WORKDIR /app
COPY --from=build-env /app/out .
EXPOSE 8080
ENV ASPNETCORE_URLS=http://*:8080
ENTRYPOINT ["dotnet", "vefast-api.dll"]