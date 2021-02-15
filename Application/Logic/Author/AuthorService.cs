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
        IMapper mapper { get; set; }

        public AuthorService(IAuthorRepository AuthorRepository, IMapper mapper)
        {
            this.AuthorRepository = AuthorRepository;
            this.mapper = mapper;
        }

        public async Task<HashSet<AuthorDTO>> GetAuthor()
        {
            var listOfAuthor = await AuthorRepository.GetAuthor();
            HashSet<AuthorDTO> listOfAuthorDTO = new HashSet<AuthorDTO>();

            foreach (Author author in listOfAuthor)
                listOfAuthorDTO.Add(mapper.Map<AuthorDTO>(author));

            return listOfAuthorDTO;
        }

        public async Task<HashSet<AuthorDTO>> GetAuthor(string pattern)
        {
            var listOfAuthor = await AuthorRepository.GetAuthor(pattern);
            HashSet<AuthorDTO> listOfAuthorDTO = new HashSet<AuthorDTO>();

            foreach (Author author in listOfAuthor)
                listOfAuthorDTO.Add(mapper.Map<AuthorDTO>(author));

            return listOfAuthorDTO;
        }

        public async Task<AuthorDTO> GetAuthor(int? id)
        {
            Author author = await AuthorRepository.GetAuthor(id);
            AuthorDTO authorDTO = mapper.Map<AuthorDTO>(author);

            return authorDTO;
        }

        public async Task AddAuthor(AuthorDTO authorDTO)
        {
            Author author = mapper.Map<Author>(authorDTO);
            await AuthorRepository.AddAuthor(author);
        }

        public async Task ChangeAuthor(AuthorDTO authorDTO)
        {
            Author author = mapper.Map<Author>(authorDTO);
            await AuthorRepository.ChangeAuthor(author);
        }

        public async Task DeleteAuthor(AuthorDTO authorDTO)
        {
            Author book = mapper.Map<Author>(authorDTO);
            await AuthorRepository.DeleteAuthor(book);
        }
    }
}
