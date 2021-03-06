﻿using Books.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.Infrastructure.Interfaces
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksByRole(string role);
        Task ChangeBook(Book book, int[] tagsId);
        Task AddBookImage(int id, IFormFile file);
    }
}