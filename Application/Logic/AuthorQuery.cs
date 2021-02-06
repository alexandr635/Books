using Application.DTO;
using Data.Entities;
using Data.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Logic
{
    public class AuthorQuery : IAuthorQuery
    {
        IWorkWithAuthor iWorkWithAuthor { get; set; }

        public AuthorQuery(IWorkWithAuthor iWorkWithAuthor)
        {
            this.iWorkWithAuthor = iWorkWithAuthor;
        }

        public async Task<HashSet<AuthorDTO>> GetAuthor()
        {
            var listOfAuthor = await iWorkWithAuthor.GetAuthor();
            HashSet<AuthorDTO> listOfAuthorDTO = new HashSet<AuthorDTO>();
            foreach (Author author in listOfAuthor)
                listOfAuthorDTO.Add(ConvertTo.AuthorDTO(author));
            return listOfAuthorDTO;
        }

        public async Task<HashSet<AuthorDTO>> GetAuthor(string pattern)
        {
            var listOfAuthor = await iWorkWithAuthor.GetAuthor(pattern);
            HashSet<AuthorDTO> listOfAuthorDTO = new HashSet<AuthorDTO>();
            foreach (Author author in listOfAuthor)
                listOfAuthorDTO.Add(ConvertTo.AuthorDTO(author));
            return listOfAuthorDTO;
        }

        public async Task<AuthorDTO> GetAuthor(int? id)
        {
            Author author = await iWorkWithAuthor.GetAuthor(id);
            AuthorDTO authorDTO = ConvertTo.AuthorDTO(author);

            return authorDTO;
        }

        public async Task AddAuthor(AuthorDTO authorDTO)
        {
            Author author = ConvertTo.Author(authorDTO);
            await iWorkWithAuthor.AddAuthor(author);
        }

        public async Task ChangeAuthor(AuthorDTO authorDTO)
        {
            Author author = ConvertTo.Author(authorDTO);
            await iWorkWithAuthor.ChangeAuthor(author);
        }
    }
}
