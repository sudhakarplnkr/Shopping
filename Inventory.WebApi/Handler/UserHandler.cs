namespace Inventory.WebApi.Handler
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoMapper;
    using Inventory.WebApi.Data.Entity;
    using Inventory.WebApi.Request.User;
    using Inventory.WebApiDbContext;
    using MediatR;

    public class UserHandler : IRequestHandler<CreateUserRequest, bool>
    {
        public readonly InventoryContext context;
        public readonly IMapper mapper;

        public UserHandler(InventoryContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<bool> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            if (context.Users.Any(u => u.Email == request.UserViewModel.Email))
            {
                return false;
            }

            var user = mapper.Map<User>(request.UserViewModel);
            await context.Users.AddAsync(user).ConfigureAwait(false);
            await context.SaveChangesAsync().ConfigureAwait(false);
            return true;
        }
    }
}