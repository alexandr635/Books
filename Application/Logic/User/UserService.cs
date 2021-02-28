using Application.DTO;
using AutoMapper;
using Data.Repositories.User;
using System.Collections.Generic;
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

            return Mapper.Map<UserDTO>(await UserRepository.GetUser(user));
        }

        public async Task<UserDTO> GetUser(string login)
        {
            return Mapper.Map<UserDTO>(await UserRepository.GetUser(login));
        }

        public async Task<List<UserDTO>> GetUser()
        {
            return Mapper.Map<List<UserDTO>>(await UserRepository.GetUser());
        }

        public async Task<UserDTO> GetUser(int id)
        {
            return Mapper.Map<UserDTO>(await UserRepository.GetUser(id));
        }

        public async Task ChangeUser(UserDTO user)
        {
            await UserRepository.ChangeUser(Mapper.Map<Data.Entities.User>(user));
        }

        public async Task DeleteUser(UserDTO user)
        {
            await UserRepository.DeleteUser(Mapper.Map<Data.Entities.User>(user));
        }

        public async Task AddUser(UserDTO user)
        {
            await UserRepository.AddUser(Mapper.Map<Data.Entities.User>(user));
        }
    }
}
