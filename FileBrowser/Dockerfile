FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY . /app
# copy everything else and build app

WORKDIR /app/FileBrowser
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
COPY --from=build /app/FileBrowser/out ./
ENTRYPOINT ["dotnet", "FileBrowser.dll"]