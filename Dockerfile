#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["cruddockercompose.csproj", "."]
COPY ["appsettings.json", "."]
RUN dotnet restore "./cruddockercompose.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "cruddockercompose.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "cruddockercompose.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "cruddockercompose.dll"]

FROM build AS builddb
WORKDIR /src
COPY ["cruddockercompose.csproj", "./"]
COPY entrypoint.sh entrypoint.sh
RUN dotnet tool install --global dotnet-ef
ENV PATH $PATH:/root/.dotnet/tools
RUN dotnet restore "./cruddockercompose.csproj"
COPY . .
WORKDIR "/src/."
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh