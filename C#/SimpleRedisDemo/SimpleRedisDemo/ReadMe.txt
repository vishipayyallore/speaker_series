Install Microsoft.Extensions.Configuration.UserSecrets Nuget Package
dotnet user-secrets set CacheConnection "Your Connection String to Redis"
dotnet user-secrets --id "Your User Secret Id" set CacheConnection "Your Connection String to Redis" 

RedisPrompt> KEYS * => Command to retrieve all the keys
