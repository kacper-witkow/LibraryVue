#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

USER root
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
USER root
RUN apt-get update
RUN apt-get install -y curl
RUN apt-get install -y libpng-dev libjpeg-dev curl libxi6 build-essential libgl1-mesa-glx
RUN curl -sL https://deb.nodesource.com/setup_lts.x | bash -
RUN apt-get install -y nodejs




ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["libraryvue.client/nuget.config", "libraryvue.client/"]
COPY ["LibraryVue.Server/LibraryVue.Server.csproj", "LibraryVue.Server/"]
COPY ["libraryvue.client/libraryvue.client.esproj", "libraryvue.client/"]
RUN dotnet restore "./LibraryVue.Server/LibraryVue.Server.csproj"
WORKDIR "/src/LibraryVue.Server"
RUN mv /src/libraryvue.client/dist /app/wwwroot
RUN dotnet build "./LibraryVue.Server.csproj" -c $BUILD_CONFIGURATION -o /app/build


FROM build AS publish
RUN dotnet publish "./LibraryVue.Server.csproj" -c Debug -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LibraryVue.Server.dll"]