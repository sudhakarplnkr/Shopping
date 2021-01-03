namespace Inventory.WebApi.Handler
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Inventory.WebApi.Data.Entity;
    using Inventory.WebApi.Request.Role;
    using Inventory.WebApiDbContext;
    using MediatR;
    using System.Collections.Generic;
    using Inventory.WebApi.ViewModel;

    public class RoleHandler : IRequestHandler<FetchRoleRequest, IEnumerable<RoleViewModel>>,
                               IRequestHandler<FetchOneRoleRequest, RoleViewModel>,
                               IRequestHandler<CreateRoleRequest, bool>,
                               IRequestHandler<UpdateRoleRequest, bool>,
                               IRequestHandler<DeleteRoleRequest, bool>
    {
        public readonly InventoryContext context;
        public readonly IMapper mapper;

        public RoleHandler(InventoryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CreateRoleRequest request, CancellationToken cancellationToken)
        {
            if (context.Roles.Any(u => u.Code == request.RoleViewModel.Code))
            {
                return false;
            }

            var role = mapper.Map<Role>(request.RoleViewModel);
            await context.Roles.AddAsync(role).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }

        public async Task<IEnumerable<RoleViewModel>> Handle(FetchRoleRequest request, CancellationToken cancellationToken)
        {
            var roles = context.Roles;
            return await Task.Run(() => mapper.Map<List<RoleViewModel>>(roles));
        }

        public async Task<RoleViewModel> Handle(FetchOneRoleRequest request, CancellationToken cancellationToken)
        {
            var role = context.Roles.FirstOrDefault(u => u.Id == request.Id);
            return await Task.Run(() => mapper.Map<RoleViewModel>(role));
        }

        public async Task<bool> Handle(DeleteRoleRequest request, CancellationToken cancellationToken)
        {
            var role = context.Roles.FirstOrDefault(u => u.Id == request.Id);
            if (role == null)
            {
                return false;
            }

            context.Roles.Remove(role);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            if (!context.Roles.Any(u => u.Id == request.Id))
            {
                return false;
            }

            var role = mapper.Map<Role>(request.RoleViewModel);
            context.Roles.Update(role);
            await context.SaveChangesAsync();
            return true;
        }
    }
}