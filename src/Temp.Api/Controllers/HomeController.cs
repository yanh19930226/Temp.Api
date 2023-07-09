namespace Temp.Api.Controllers
{
    [Route("temp/home")]
    [Microsoft.AspNetCore.Authorization.Authorize(AuthenticationSchemes = BasicDefaults.AuthenticationScheme)]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOptionsSnapshot<CorsConfig> _option;
        private readonly IOptionsSnapshot<TestConfig> _toption;
        private readonly IRedisProvider _redis;
        private readonly ICacheProvider _cache;
        private readonly IDistributedLocker _locker;
        private readonly IEventBus _eventBus;
        private readonly IEventPublisher _eventPublisher;
        private readonly ITestServices _testServices;
        private readonly IMongoRepository<LoginLog> _mongoRepository;

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="logger"></param>
        public HomeController(ILogger<HomeController> logger,
            ITestServices testServices,
            IRedisProvider redis,
            IDistributedLocker locker,
            ICacheProvider cache,
            IOptionsSnapshot<CorsConfig> option,
            IOptionsSnapshot<TestConfig> toption,
            IEventPublisher eventPublisher,
            IMongoRepository<LoginLog> mongoRepository,
            IEventBus eventBus
            )
        {
            _logger = logger;
            _testServices = testServices;
            _option = option;
            _toption = toption;
            _redis = redis;
            _locker = locker;
            _cache = cache;
            _eventPublisher = eventPublisher;
            _mongoRepository = mongoRepository;
            _eventBus = eventBus;
        }
        
        /// <summary>
        /// CreateBasicToken
        /// </summary>
        /// <returns></returns>
        [HttpGet("CreateBasicToken")]
        [AllowAnonymous]
        public string CreateBasicToken(string userName)
        {
            var token = BasicTokenValidator.PackToBase64(userName);
            return token;
        }
        /// <summary>
        /// TestLog
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestLog")]
        [AllowAnonymous]
        public string TestLog()
        {
            _logger.LogTrace(1000, "log Trace msg");
            _logger.LogDebug(1001, "log Debug msg");
            _logger.LogInformation(1002, "log Information msg");
            _logger.LogWarning(1003, "log Warning msg");
            _logger.LogError(1004, "log Error msg");
            _logger.LogCritical(1005, "log Critical msg");

            return "testlog";
        }

        /// <summary>
        /// testconfig
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestConfig")]
        [AllowAnonymous]
        public IActionResult TestConfig()
        {
            var res = _option.Value.IPs;

            var sss = _toption.Value.TestStr;

            return Ok(res + "====" + sss);
        }

        /// <summary>
        /// TestData
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestData")]
        [AllowAnonymous]
        public async Task<IActionResult> TestData()
        {
            var testEntity = await _testServices.GetTestEntityFromDb();

            return Ok(testEntity);
        }

        /// <summary>
        /// TestRpc
        /// </summary>
        /// <returns></returns>
        [HttpGet("TestRpc")]
        public async Task<IActionResult> TestRpc()
        {
            _logger.LogInformation(1002, "log Information msg");

            var yande = await _testServices.GetYande(1);

            var consul = await _testServices.GetConsul(1);

            return Ok(new
            {
                yande = $"Headers:{yande.Headers}\r\n RequestMessage:{yande.RequestMessage}\r\n Result:{yande.Content.Name}",
                consul = $"Headers:{consul.Headers}\r\n RequestMessage:{consul.RequestMessage}\r\n Result:{consul.Content.Name}"
            });
        }

        /// <summary>
        /// RedisBasic
        /// </summary>
        /// <returns></returns>
        [HttpGet("RedisBasic")]
        [AllowAnonymous]
        public IActionResult RedisBasic()
        {
            _redis.StringSet("redisbasic", "redisbasic");

            return Ok();
        }

        /// <summary>
        /// RedisCache
        /// </summary>
        /// <returns></returns>
        [HttpGet("RedisCache")]
        [AllowAnonymous]
        public IActionResult RedisCache()
        {
            _cache.Set("rediscache", new { Id = "rediscache", Name = "rediscache" }, TimeSpan.FromMinutes(1));

            return Ok();
        }

        /// <summary>
        /// PublishCap
        /// </summary>
        /// <returns></returns>
        [HttpGet("PublishCap")]
        [AllowAnonymous]
        public async Task<IActionResult> PublishCap()
        {
            var eventmodel = new TestCapEventModel() { CustomerId = "cap", TransactionLogId = "cap", Amount = "cap" };

            await _eventPublisher.PublishAsync(new CaptEvent(nameof(CaptEvent), eventmodel));

            return Ok();
        }

        /// <summary>
        /// PublishRabbitTest
        /// </summary>
        /// <returns></returns>
        [HttpGet("PublishRabbitTest")]
        [AllowAnonymous]
        public async Task<IActionResult> PublishRabbitTest()
        {
            var RabbitTestEventModel = new RabbitTestEventModel()
            {
                Id = "test",
                Test = "test",

            };
            await _eventBus.PublishAsync(new RabbitTestEvent(nameof(RabbitTestEvent), RabbitTestEventModel));

            return Ok();
        }

        /// <summary>
        /// PublishRabbitDemo
        /// </summary>
        /// <returns></returns>
        [HttpGet("PublishRabbitDemo")]
        [AllowAnonymous]
        public async Task<IActionResult> PublishRabbitDemo()
        {
            var RabbitDemoEventModel = new RabbitDemoEventModel()
            {
                Id = "demo",
                Demo = "demo",
            };
            await _eventBus.PublishAsync(new RabbitDemoEvent(nameof(RabbitDemoEvent), RabbitDemoEventModel));

            return Ok();
        }

        /// <summary>
        /// MongoCreate
        /// </summary>
        /// <returns></returns>
        [HttpGet("MongoCreate")]
        [AllowAnonymous]
        public async Task<IActionResult> MongoCreate()
        {
            
            LoginLog loginLog = new LoginLog()
            {
               
                UserId = 1,
                UserName = "tmpl",
                Account = "tmpl",
                Device = "tmpl",
                Message = "tmpl",
                RemoteIpAddress = "127.0.0.1",
                Succeed = true,
                StatusCode = 200,
                CreateTime = DateTime.Now,
            };

            await _mongoRepository.AddAsync(loginLog);

            return Ok();
        }

        /// <summary>
        /// MongoGetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet("MongoGetAll")]
        [AllowAnonymous]
        public async Task<IActionResult> MongoGetAll()
        {
            var res = await _mongoRepository.GetAllAsync();

            return Ok(res);
        }

        /// <summary>
        /// MongoGetPage
        /// </summary>
        /// <returns></returns>
        [HttpGet("MongoGetPage")]
        [AllowAnonymous]
        public async Task<IActionResult> MongoGetPage()
        {
            var filter = new FilterDefinitionBuilder<LoginLog>();

            var res = await _mongoRepository.PagedAsync(1, 4, filter.Where(p => true), (p) => p.Id, false);

            return Ok(res);
        }

        /// <summary>
        /// Version
        /// </summary>
        /// <returns></returns>
        [HttpGet("Version")]
        [AllowAnonymous]
        //[ApiVersion("2.0")]
        public async Task<IActionResult> Version()
        {
            var filter = new FilterDefinitionBuilder<LoginLog>();

            var res = await _mongoRepository.PagedAsync(1, 4, filter.Where(p => true), (p) => p.Id, false);

            return Ok(res);
        }

    }
}
