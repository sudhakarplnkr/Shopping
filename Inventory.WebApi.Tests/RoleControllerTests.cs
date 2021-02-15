using FakeItEasy;
namespace Inventory.WebApi.Tests
{
    using Inventory.WebApi.Controllers;
    using Inventory.WebApi.Request.Role;
    using Inventory.WebApi.ViewModel;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Xunit;

    public class RoleControllerTests
    {
        [Fact]
        public async Task GivenRequestWhenGetThenSendMediatorRequestToHandler()
        {
            var mediator = A.Fake<IMediator>();
            var controller = new RoleController(mediator);
            await controller.Get().ConfigureAwait(false);
            A.CallTo(() => mediator.Send(A<FetchRoleRequest>.Ignored, A<CancellationToken>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task GivenRequestWhenGetWithIdThenSendMediatorRequestToHandler()
        {
            var mediator = A.Fake<IMediator>();
            var controller = new RoleController(mediator);
            await controller.Get(A.Dummy<Guid>()).ConfigureAwait(false);
            A.CallTo(() => mediator.Send(A<FetchOneRoleRequest>.Ignored, A<CancellationToken>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task GivenRequestWhenPutThenSendMediatorRequestToHandler()
        {
            var mediator = A.Fake<IMediator>();
            var controller = new RoleController(mediator);
            await controller.Put(A.Dummy<Guid>(), A.Dummy<RoleViewModel>()).ConfigureAwait(false);
            A.CallTo(() => mediator.Send(A<UpdateRoleRequest>.Ignored, A<CancellationToken>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task GivenRequestWhenPostThenSendMediatorRequestToHandler()
        {
            var mediator = A.Fake<IMediator>();
            var controller = new RoleController(mediator);
            await controller.Post(A.Dummy<RoleViewModel>()).ConfigureAwait(false);
            A.CallTo(() => mediator.Send(A<CreateRoleRequest>.Ignored, A<CancellationToken>.Ignored)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task GivenRequestWhenDeleteThenSendMediatorRequestToHandler()
        {
            var mediator = A.Fake<IMediator>();
            var controller = new RoleController(mediator);
            await controller.Delete(A.Dummy<Guid>()).ConfigureAwait(false);
            A.CallTo(() => mediator.Send(A<DeleteRoleRequest>.Ignored, A<CancellationToken>.Ignored)).MustHaveHappenedOnceExactly();
        }
    }
}
