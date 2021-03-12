using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using Books.Infrastructure.Lists;
using System.Linq;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class ListService : IListService
    {
        IAuthorRepository AuthorRepository { get; set; }
        IGenreRepository GenreRepository { get; set; }
        IBookStatusRepository BookStatusRepository { get; set; }
        IBookSeriesRepository BookSeriesRepository { get; set; }
        ITagRepository TagRepository { get; set; }
        IBookRepository BookRepository { get; set; }
        IUserRepository UserRepository { get; set; }
        IRoleRepository RoleRepository { get; set; }

        public ListService(IAuthorRepository authorRepository, IGenreRepository genreRepository,
                           IBookSeriesRepository bookSeriesRepository, IBookStatusRepository bookStatusRepository,
                           ITagRepository tagRepository, IBookRepository bookRepository,
                           IUserRepository userRepository, IRoleRepository roleRepository)
        {
            AuthorRepository = authorRepository;
            GenreRepository = genreRepository;
            BookStatusRepository = bookStatusRepository;
            BookSeriesRepository = bookSeriesRepository;
            BookRepository = bookRepository;
            TagRepository = tagRepository;
            UserRepository = userRepository;
            RoleRepository = roleRepository;
        }

        public async Task<ListEntities> GetListEntities()
        {
            ListEntities list = new ListEntities()
            {
                Genre = await GenreRepository.GetGenre(),
                Author = await AuthorRepository.GetAuthor(),
                BookStatus = await BookStatusRepository.GetStatus(),
                BookSeries = await BookSeriesRepository.GetSeries()
            };

            return list;
        }

        public async Task<ListEntities> GetFullListEntities(int id)
        {
            ListEntities list = new ListEntities()
            {
                Genre = await GenreRepository.GetGenre(),
                Author = await AuthorRepository.GetAuthor(),
                BookStatus = await BookStatusRepository.GetStatus(),
                BookSeries = await BookSeriesRepository.GetSeries(),
                Tag = await TagRepository.GetTag(),
                Book = await BookRepository.GetBook(id)
            };

            return list;
        }

        public async Task<ListEntities> GetListBookAndStatus(string role, int id)
        {
            ListEntities list = new ListEntities();
            list.Book = await BookRepository.GetBook(id);
            const byte statusDraft = 1;
            const byte statusPending = 2;

            switch (role)
            {
                case "Проверяющий":
                    list.BookStatus = await BookStatusRepository.GetStatus();
                    list.BookStatus = list.BookStatus.Where(s => s.Id != statusDraft).ToList();
                    break;
                case "Писатель":
                    list.BookStatus = await BookStatusRepository.GetStatus();
                    list.BookStatus = list.BookStatus.Where(s => s.Id == statusDraft || s.Id == statusPending).ToList();
                    break;
                case "Администратор":
                    list.BookStatus = await BookStatusRepository.GetStatus();
                    break;
            };

            return list;
        }

        public async Task<ListEntities> GetListAuthorAndTag()
        {
            ListEntities list = new ListEntities()
            {
                Author = await AuthorRepository.GetAuthor(),
                Tag = await TagRepository.GetTag()
            };

            return list;
        }

        public async Task<UserToRoles> GetListUserAndRole(int id)
        {
            UserToRoles list = new UserToRoles()
            {
                User = await UserRepository.GetUser(id),
                Roles = await RoleRepository.GetRole()
            };

            return list;
        }
    }
}
