using Application.DTO;
using AutoMapper;
using Data.Repositories.User;
using System.Threading.Tasks;

namespace Application.Logic.User
{
    public class UserService : IUserService
    {
        IMapper Mapper { get; set; }
        IUserRepository UserRepository { get; set; }

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            Mapper = mapper;
            UserRepository = userRepository;
        }

        public async Task<UserDTO> GetUser(UserDTO userDTO)
        {
            var user = Mapper.Map<Data.Entities.User>(userDTO);
            var res = await UserRepository.GetUser(user);
            return Mapper.Map<UserDTO>(res);
        }

        public async Task<UserDTO> GetUser(string login)
        {
            var res = await UserRepository.GetUser(login);
            return Mapper.Map<UserDTO>(res);
        }
    }
}
