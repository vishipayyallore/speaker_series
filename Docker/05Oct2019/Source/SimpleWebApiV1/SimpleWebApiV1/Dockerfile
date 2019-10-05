FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-stretch AS build
WORKDIR /src
COPY ["SimpleWebApiV1/SimpleWebApiV1.csproj", "SimpleWebApiV1/"]
RUN dotnet restore "SimpleWebApiV1/SimpleWebApiV1.csproj"
COPY . .
WORKDIR "/src/SimpleWebApiV1"
RUN dotnet build "SimpleWebApiV1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SimpleWebApiV1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SimpleWebApiV1.dll"]