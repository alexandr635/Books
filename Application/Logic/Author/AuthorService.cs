using Application.DTO;
using AutoMapper;
using Data.Entities;
using Data.Logic;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class AuthorService : IAuthorService
    {
        IAuthorRepository AuthorRepository { get; set; }
        IMapper Mapper { get; set; }

        public AuthorService(IAuthorRepository AuthorRepository, IMapper mapper)
        {
            this.AuthorRepository = AuthorRepository;
            Mapper = mapper;
        }

        public async Task<List<AuthorDTO>> GetAuthor()
        {
            return Mapper.Map<List<AuthorDTO>>(await AuthorRepository.GetAuthor());
        }

        public async Task<List<AuthorDTO>> GetAuthor(string pattern)
        {
            return Mapper.Map<List<AuthorDTO>>(await AuthorRepository.GetAuthor(pattern));
        }

        public async Task<AuthorDTO> GetAuthor(int? id)
        {
            return Mapper.Map<AuthorDTO>(await AuthorRepository.GetAuthor(id));
        }

        public async Task AddAuthor(AuthorDTO authorDTO)
        {
            await AuthorRepository.AddAuthor(Mapper.Map<Author>(authorDTO));
        }

        public async Task ChangeAuthor(AuthorDTO authorDTO)
        {
            await AuthorRepository.ChangeAuthor(Mapper.Map<Author>(authorDTO));
        }

        public async Task DeleteAuthor(AuthorDTO authorDTO)
        {
            await AuthorRepository.DeleteAuthor(Mapper.Map<Author>(authorDTO));
        }
    }
}
