namespace Directory.Services.Data
{
    public class DBInitializer
    {
        public static void Initialize(DirectoryDBContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
