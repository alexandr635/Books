using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class BookStatusService : IBookStatusService
    {
        IBookStatusRepository BookStatusRepository { get; set; }

        public BookStatusService(IBookStatusRepository bookStatusRepository)
        {
            BookStatusRepository = bookStatusRepository;
        }


        public async Task<List<BookStatus>> GetStatusByRole(string role)
        {
            List<BookStatus> list = new List<BookStatus>();
            const byte statusDraft = 1;
            const byte statusPending = 2;

            switch (role)
            {
                case "Проверяющий":
                case "Администратор":
                    list = await BookStatusRepository.GetStatus();
                    break;
                case "Писатель":
                    list = await BookStatusRepository.GetStatus();
                    list = list.Where(s => s.Id == statusDraft || s.Id == statusPending).ToList();
                    break;
            };

            return list;
        }
    }
}
