namespace Temp.Api.Services
{
    /// <summary>
    /// ITestServices
    /// </summary>
    public interface ITestServices : IAppService
    {
        /// <summary>
        /// GetConsul
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResponse<TestRto>> GetConsul(long id);

        /// <summary>
        /// GetYande
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ApiResponse<TestRto>> GetYande(long id);

        /// <summary>
        /// GetTestEntityFromDb
        /// </summary>
        /// <returns></returns>
        Task<TestEntity> GetTestEntityFromDb();
    }
}
