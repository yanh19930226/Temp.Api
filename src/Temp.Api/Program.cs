internal static class Program
{
    internal static async Task Main(string[] args)
    {
        try
        {
            var webApiAssembly = Assembly.GetExecutingAssembly();
            var serviceInfo = ServiceInfo.CreateInstance(webApiAssembly);

            //Configuration,ServiceCollection,Logging,WebHost(Kestrel)
            var app = WebApplication
                .CreateBuilder(args) 
                .ConfigureDefault(serviceInfo)
                .Build().BuildServiceProvider();

            //Middlewares
            app.UseCore();

            //Start
            await app
                //ThreadPool
                .ChangeThreadPool()
                //RegistrationCenter
                .UseRegistrationCenter()
                .RunAsync();
        }
        catch (Exception ex)
        {
             throw;
        }
        finally
        {
        }
    }
}