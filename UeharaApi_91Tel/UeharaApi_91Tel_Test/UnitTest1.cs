using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UeharaApi_91Tel.Service;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UeharaApi_91Tel.EntityFramework;
using UeharaApi_91Tel.Models;
using UeharaApi_91Tel.Repositories;

namespace UeharaApi_91Tel_Test
{
    [TestClass]
    public class UnitTest1
    {
        private IClientApi91 testClass = new ClientApi91(new Uri(@"http://integracao.epbx.com.br:5050"));
  

        [TestMethod]
        public void Test_Authentication_When_Should_be_expect_success()
        {
            var result = testClass.Authentication("password", "teste", "teste").Result;
            Assert.AreNotEqual(new ApplicationException(), result);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException),
                           "\\\"error\\\":\\\"invalid_grant\\\",\\\"error_description\\\":\\\"The user name or password is incorrect.\\\"")]
        public void Test_Authentication_When_Should_be_expect_auth_error()
        {
            var result = testClass.Authentication("password", "teste_uehara", "teste_uehara").Result;
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException),
                           "error\\\":\\\"invalid_client\\\"")]
        public void Test_Authentication_When_Should_be_expect_auth_client_invalid()
        {
            var result = testClass.Authentication("senha", "teste_uehara", "teste_uehara").Result;
        }


        [TestMethod]
        public void Test_GetLog_When_Should_be_expected_list_of_logs()
        {
            var auth = testClass.Authentication("password", "teste", "teste").Result;
            var logs = testClass.GetLogs(auth.Access_Token, "2018-06-26").Result;
            Assert.IsTrue(logs.Count > 0);
        }
    }
}
