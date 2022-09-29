using Autofac.Extras.Moq;
using Estacionamento.Database;
using Estacionamento.Models;
using Estacionamento.Repositories.ApiRepositories;
using Moq;
using NuGet.ContentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Estacionamento.tests
{
    public class UserRepositoryTest
    {

        [Fact(DisplayName ="GetUsers")]
        public void GetUsers_ValidCall()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IUserRepository>()
                    .Setup(x => x.GetUsers())
                    .Returns(SampleList());
            
                var controller = mock.Create<UserRepository>();
                var expectd = SampleList();
                var actual = controller.GetUsers();

                Assert.True(actual != null);
                Assert.Equal(expectd.Count, actual.Count);
            }
        }

        private List<AppUser> SampleList()
        {
            List<AppUser> output = new List<AppUser>
            {
                new AppUser
                {
                    Email = "sample@sample.com",
                    UserName = "sample@sample.com",
                },

                new AppUser
                {
                    Email = "sample1@sample.com",
                    UserName = "sample1@sample.com",
                },


                new AppUser
                {
                    Email = "sample2@sample.com",
                    UserName = "sample2@sample.com",
                }

            };
            return output;
        }
    }
}
