namespace Inventory.WebApi.Controllers
{
    using System.Threading.Tasks;
    using Inventory.WebApi.Request.Role;
    using Inventory.WebApi.ViewModel;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System;

    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IMediator mediator;

        public RoleController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<IEnumerable<RoleViewModel>> Get()
        {
            return mediator.Send(new FetchRoleRequest());
        }

        [HttpGet]
        [Route("{id}")]
        public Task<RoleViewModel> Get(Guid id)
        {
            return mediator.Send(new FetchOneRoleRequest(id));
        }

        [HttpPut]
        [Route("{id}")]
        public Task<bool> Put(Guid id, RoleViewModel roleViewModel)
        {
            return mediator.Send(new UpdateRoleRequest(id, roleViewModel));
        }

        [HttpPost]
        public Task<bool> Post(RoleViewModel roleViewModel)
        {
            return mediator.Send(new CreateRoleRequest(roleViewModel));
        }

        [HttpDelete]
        [Route("{id}")]
        public Task<bool> Delete(Guid id)
        {
            return mediator.Send(new DeleteRoleRequest(id));
        }
    }
}
