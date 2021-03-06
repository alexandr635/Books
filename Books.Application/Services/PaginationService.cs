using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using Books.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class PaginationService : IPaginationService
    {
        IBookRepository BookRepository { get; set; }

        public PaginationService(IBookRepository bookRepository)
        {
            BookRepository = bookRepository;
        }

        public async Task<IndexViewModel> GetPaginationModel(Book pattern, string tagsId, int page)
        {
            if (pattern.BookToTags.Count() == 0 && tagsId != "")
            {
                List<BookToTag> bookToTags = new List<BookToTag>();

                string[] arrayStr = tagsId.Trim(new char[] { ',' }).Split(new char[] { ',' });
                int[] array = new int[arrayStr.Length];

                for(var i = 0; i < arrayStr.Length; i++)
                    array[i] = Convert.ToInt32(arrayStr[i]);
                
                foreach (int tagId in array)
                    bookToTags.Add(new BookToTag(pattern.Id, tagId));

                pattern.SetBookToTags(bookToTags);
            }

            var bookForPagination = await BookRepository.GetBook(pattern);

            int pageSize = 1;
            int count = bookForPagination.Count();
            List<Book> items = bookForPagination.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Books = items,
                Pattern = pattern
            };

            return viewModel;
        }
    }
}
