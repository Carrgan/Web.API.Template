namespace Template.Web.Api
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        private static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webHostBuilder => webHostBuilder.ConfigureAppConfiguration(builder =>
            { 
                // TODO: What this method mean ?
            }).UseStartup<Startup>());

    }
}