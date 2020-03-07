FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["College.Services/College.Services.csproj", "College.Services/"]
RUN dotnet restore "College.Services/College.Services.csproj"
COPY . .
WORKDIR "/src/College.Services"
RUN dotnet build "College.Services.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "College.Services.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "College.Services.dll"]