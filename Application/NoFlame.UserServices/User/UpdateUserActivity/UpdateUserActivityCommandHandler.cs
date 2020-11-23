using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NoFlame.Domain.Repository;

namespace NoFlame.UserServices.User.UpdateUserActivity
{
    public class UpdateUserActivityCommandHandler:IRequestHandler<UpdateUserActivityCommand,Domain.UserAggregate.User>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserActivityCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<Domain.UserAggregate.User> Handle(UpdateUserActivityCommand request, CancellationToken cancellationToken)
        {
            return _userRepository.UpdateUserActivity(request.Id, request.IsActive);
        }

       
    }
}