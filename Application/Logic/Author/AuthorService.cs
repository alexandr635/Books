﻿using Application.DTO;
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
            var listOfAuthor = await AuthorRepository.GetAuthor();
            List<AuthorDTO> listOfAuthorDTO = new List<AuthorDTO>();

            foreach (Author author in listOfAuthor)
                listOfAuthorDTO.Add(Mapper.Map<AuthorDTO>(author));

            return listOfAuthorDTO;
        }

        public async Task<List<AuthorDTO>> GetAuthor(string pattern)
        {
            var listOfAuthor = await AuthorRepository.GetAuthor(pattern);
            List<AuthorDTO> listOfAuthorDTO = new List<AuthorDTO>();

            foreach (Author author in listOfAuthor)
                listOfAuthorDTO.Add(Mapper.Map<AuthorDTO>(author));

            return listOfAuthorDTO;
        }

        public async Task<AuthorDTO> GetAuthor(int? id)
        {
            Author author = await AuthorRepository.GetAuthor(id);
            AuthorDTO authorDTO = Mapper.Map<AuthorDTO>(author);

            return authorDTO;
        }

        public async Task AddAuthor(AuthorDTO authorDTO)
        {
            Author author = Mapper.Map<Author>(authorDTO);
            await AuthorRepository.AddAuthor(author);
        }

        public async Task ChangeAuthor(AuthorDTO authorDTO)
        {
            Author author = Mapper.Map<Author>(authorDTO);
            await AuthorRepository.ChangeAuthor(author);
        }

        public async Task DeleteAuthor(AuthorDTO authorDTO)
        {
            Author book = Mapper.Map<Author>(authorDTO);
            await AuthorRepository.DeleteAuthor(book);
        }
    }
}
