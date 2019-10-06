FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["Source/College.Microservice.csproj", "Source/"]
RUN dotnet restore "Source/College.Microservice.csproj"
COPY . .
WORKDIR "/src/Source"
RUN dotnet build "College.Microservice.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "College.Microservice.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "College.Microservice.dll"]