using System.Threading.Tasks;
using FakeItEasy;
using UserAccount.Controllers;
using UserAccount.Database;
using UserAccount.Models;
using Xunit;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace UserAccount.Tests.Controllers 
{
    public class AccountsControllerTests
    {
        private readonly AccountsController _controller;
        private readonly IRepository<Account> _repository;

        public AccountsControllerTests()
        {
            _repository = A.Fake<IRepository<Account>>();

            _controller = new AccountsController(_repository);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Get_GivenAnIncorrectId_ReturnsABadRequest(string id)
        {
            var response = await _controller.Get(id);

            response.Result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task Get_WhenAccountNotFound_ReturnsNotFound()
        {
            A.CallTo(() => _repository.GetAsync(A<string>._)).Returns(Task.FromResult<Account>(null));

            var response = await _controller.Get("some-id");

            response.Result.Should().BeOfType<NotFoundResult>();
        }
    }
}