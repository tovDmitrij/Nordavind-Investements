FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-components
WORKDIR /components/database.context
COPY database.context/*csproj .
RUN dotnet restore
COPY components/database.context .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-misc
WORKDIR /components/misc.security
COPY misc.security/*csproj .
RUN dotnet restore
COPY components/misc.security .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-api
WORKDIR /api
COPY api/*.csproj .
RUN dotnet restore
COPY api .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /publish
COPY --from=build-api /publish .
EXPOSE 7
ENTRYPOINT [ "dotnet", "myWebApp.dll" ]