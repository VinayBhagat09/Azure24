using FunctionWithUnitTesting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Primitives;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace WatchFunctionUnitTests
{
    public class UnitTest1
    {
        #region TestWatchFunctionSuccess
        [Fact]
        public void TestWatchFunctionSuccess()
        {
            //Arrange
            var queryString = "aa";

            var request = new DefaultHttpRequest(new DefaultHttpContext())
            {
                Query = new QueryCollection
                (
                  new Dictionary<string, StringValues>()
                  {
                      {"model", queryString}
                  }
                )
            };
            var logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");

            //Act 
            var reponse = FunctionWithUnitTesting.WatchInfo.Run(request, logger);
            reponse.Wait();
            Assert.IsAssignableFrom<OkObjectResult>(reponse.Result);
            var result = (OkObjectResult)reponse.Result;


            Watches watches = new Watches() { Model = "aa", Manufacturer = "Tata", CaseType = "Solid", Bezel = "Titanium", Dial = "Round", CaseFinish = "Silver", Jewels = "15" };
             
            //Assert

            Watches a;
           
            
                Assert.Equal(watches, result.Value);
            
            
            
           



        }
        #endregion
    }
}