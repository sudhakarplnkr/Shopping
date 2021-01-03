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
    using System.Collections.Generic;
    using Inventory.WebApi.ViewModel;

    public class UserHandler : IRequestHandler<FetchUserRequest, IEnumerable<UserViewModel>>,
                               IRequestHandler<FetchOneUserRequest, UserViewModel>,
                               IRequestHandler<CreateUserRequest, bool>,
                               IRequestHandler<UpdateUserRequest, bool>,
                               IRequestHandler<DeleteUserRequest, bool>
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

        public async Task<IEnumerable<UserViewModel>> Handle(FetchUserRequest request, CancellationToken cancellationToken)
        {
            var users = context.Users;
            return await Task.Run(() => mapper.Map<List<UserViewModel>>(users));
        }

        public async Task<UserViewModel> Handle(FetchOneUserRequest request, CancellationToken cancellationToken)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == request.Id);
            return await Task.Run(() => mapper.Map<UserViewModel>(user));
        }

        public async Task<bool> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var user = context.Users.FirstOrDefault(u => u.Id == request.Id);
            if (user == null)
            {
                return false;
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            if (!context.Users.Any(u => u.Id == request.Id))
            {
                return false;
            }

            var user = mapper.Map<User>(request.UserViewModel);
            context.Users.Update(user);
            await context.SaveChangesAsync();
            return true;
        }
    }
}