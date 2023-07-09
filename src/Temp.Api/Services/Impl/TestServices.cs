namespace Temp.Api.Services.Impl
{
    public class TestServices : BaseSqlSugarServices<TestEntity>,ITestServices
    {
        //private readonly IConsulRestClient _consulRestClient;
        //private readonly IYandeRestClient _yandeRestClient;

        private readonly ISugarBaseRepository<TestEntity> _dal;
        private readonly ISqlSugarUnitOfWork _unitOfWork;
        private readonly ISqlSugarClient _sqlSugarClient;

        public TestServices(
            //IConsulRestClient consulRestClient,
            //IYandeRestClient yandeRestClient,
            ISugarBaseRepository<TestEntity> dal,
            ISqlSugarUnitOfWork unitOfWork, 
            ISqlSugarClient sqlSugarClient

            )
        {
            //_consulRestClient = consulRestClient;
            //_yandeRestClient = yandeRestClient;
            _dal = dal;
            BaseDal = dal;
            _sqlSugarClient = sqlSugarClient;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<TestRto>> GetConsul(long id)
        {
            //return await _consulRestClient.GetConsul(id);
            return await Task.FromResult(new ApiResponse<TestRto>(new HttpResponseMessage(),new TestRto(), new RefitSettings()));
        }

        public async Task<ApiResponse<TestRto>> GetYande(long id)
        {
            //return await _yandeRestClient.GetYande(id);
            return await Task.FromResult(new ApiResponse<TestRto>(new HttpResponseMessage(), new TestRto(), new RefitSettings()));
        }

        public async Task<TestEntity> GetTestEntityFromDb()
        {
            var res=await _dal.QueryByClauseAsync(p => p.Id == 1600000000001);

            return res;
        }
    }
}
