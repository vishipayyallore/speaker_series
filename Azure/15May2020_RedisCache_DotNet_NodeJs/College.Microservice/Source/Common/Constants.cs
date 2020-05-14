namespace College.Microservice.Common
{

    public static class Constants
    {
        // For Data Store
        public static class DataStore
        {
            public static string SqlConnectionString { get; set; } = "ConnectionStrings:CollegeDBConnectionString";

            public static string RedisConnectionString { get; set; } = "ConnectionStrings:CollegeRedisConnectionString";
        }

    }

}
