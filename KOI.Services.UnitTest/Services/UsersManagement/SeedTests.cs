using KOI.Blueprint.Domain.Entites.Users;
using KOI.Blueprint.Infrastructure.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Xunit;
using FluentAssertions;

namespace KOI.Services.UnitTest.Services.UsersManagement
{
   
    public class SeedTests
    {
        [Fact]
        public async Task Initial_UserExist_ShouldSkipSeeding()
        {
            IQueryable<User> existingUsers = new List<User>
            { 
                new User 
                {
                    UserName = "Admin",
                    Email = "system@gmail.com",
                } 
            }.AsQueryable();

            var userManagerMock = CreateUserManagerMock(existingUsers);
            var roleManagerMock = CreateRoleManagerMock();

            var initializer = new Seed(userManagerMock.Object, roleManagerMock.Object);

            await initializer.Invoking(x => x.InitialSeedData())
                .Should().NotThrowAsync();

            roleManagerMock.Verify(x => x.RoleExistsAsync(It.IsAny<string>()), Times.Never);
            roleManagerMock.Verify(x => x.CreateAsync(It.IsAny<Role>()), Times.Never);
            userManagerMock.Verify(x => x.CreateAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Never);
            userManagerMock.Verify(x => x.AddToRoleAsync(It.IsAny<User>(), It.IsAny<string>()), Times.Never);
            userManagerMock.Verify(x => x.FindByNameAsync(It.IsAny<string>()), Times.Never);
            userManagerMock.Verify(x => x.AddToRolesAsync(It.IsAny<User>(), It.IsAny<IEnumerable<string>>()), Times.Never);

        }

        private static Mock<UserManager<User>> CreateUserManagerMock(IQueryable<User> existingUsers)
        {
            var userStoreMock = new Mock<IQueryableUserStore<User>>();
            userStoreMock.Setup(x => x.Users).Returns(existingUsers);

            var userManagerMock = new Mock<UserManager<User>>(
                userStoreMock.Object,
                Options.Create(new IdentityOptions()),
                 new Mock<IPasswordHasher<User>>().Object,
                 new List<IUserValidator<User>>(),
                 new List<IPasswordValidator<User>>(),
                 new UpperInvariantLookupNormalizer(),
                 new IdentityErrorDescriber(),
                 new Mock<IServiceProvider>().Object,
                 new Mock<ILogger<UserManager<User>>>().Object);

            userManagerMock.Setup(x => x.Users).Returns(existingUsers);

            return userManagerMock;
        }

        private static Mock<RoleManager<Role>> CreateRoleManagerMock()
        {
            var roleStoreMock = new Mock<IRoleStore<Role>>();
         
            return new Mock<RoleManager<Role>>(
                roleStoreMock.Object,
                new List<IRoleValidator<Role>>(),
                new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(),
                new Mock<ILogger<RoleManager<Role>>>().Object);
        }
    }
}
