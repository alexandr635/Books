using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.WebAPI.Controllers
{
    public class RatingController : Controller
    {
        IBookRepository BookRepository { get; set; }
        IMapper Mapper { get; set; }

        public RatingController(IBookRepository bookRepository, IMapper mapper)
        {
            BookRepository = bookRepository;
            Mapper = mapper;
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index()
        {
            var listDTO = Mapper.Map<List<BookDTO>>(await BookRepository.GetRatingList(100));
            return View(listDTO);
        }
    }
}
