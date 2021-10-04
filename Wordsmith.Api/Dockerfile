
# NuGet restore
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY Wordsmith.Api.sln dist/Wordsmith.Api.sln
COPY src/Wordsmith.Api/Wordsmith.Api.csproj dist/src/Wordsmith.Api/
COPY src/Wordsmith.Core/Wordsmith.Core.csproj dist/src/Wordsmith.Core/
COPY tests/Wordsmith.Core.Tests/Wordsmith.Core.Tests.csproj dist/tests/Wordsmith.Core.Tests/
WORKDIR /dist
RUN dotnet restore
COPY . .

FROM build AS publish
WORKDIR /dist/src/Wordsmith.Api
RUN dotnet publish -c Release -o /src/publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=publish /src/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Wordsmith.Api.dll

