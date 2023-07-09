namespace Temp.Api
{
    public class AppWebApiDependencyRegistrar : AbstractWebApiDependencyRegistrar
    {
        public AppWebApiDependencyRegistrar(IServiceCollection services)
            : base(services)
        {
        }

        public AppWebApiDependencyRegistrar(IApplicationBuilder app)
            : base(app)
        {
        }

        public override void AddCoreWebApi()
        {
            //WebApiDefault
            AddWebApiDefault();
            Services.Configure<TestConfig>(Configuration.GetSection("Test"));
        }

        public override void AddCoreApplication()
        {
            //default
            AddApplicaitonDefault();

            //rabbitmq
            AddRabbitMq();

            //cap
            AddCapEventBus<CapEventSubscriber>();

            //rpc-restclient
            var restPolicies = this.GenerateDefaultRefitPolicies();
            //AddRestClient<IConsulRestClient>(RpcConsts.Usr, restPolicies);
            //AddRestClient<IYandeRestClient>(RpcConsts.YandeService, restPolicies);

            ////rpc-grpcclient
            //var gprcPolicies = this.GenerateDefaultGrpcPolicies();
            //Services.AddGrpcClient<AuthGrpc.AuthGrpcClient>(RpcConsts.TestGrpcService, gprcPolicies);
        }

        public override void UseCore()
        {
            UseWebApiDefault(endpointRoute: endpoint =>
            {
            });
        }
    }
}

