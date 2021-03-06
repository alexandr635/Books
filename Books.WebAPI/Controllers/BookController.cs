﻿using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Books.WebAPI.Controllers
{
    public class BookController : Controller
    {
        IBookService BookService { get; set; }
        IBookRepository BookRepository { get; set; }
        IMapper Mapper { get; set; }
        IListService ListService {get; set;}
        IPaginationService PaginationService { get; set; }

        List<BookDTO> BookForPagination { get; set; }

        public BookController(IBookService bookService, IMapper mapper, 
                              IListService listService, IBookRepository bookRepository,
                              IPaginationService paginationService)
        {
            BookService = bookService;
            Mapper = mapper;
            ListService = listService;
            BookRepository = bookRepository;
            PaginationService = paginationService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
                ViewData["role"] = role;
                var books = Mapper.Map<List<BookDTO>>(await BookService.GetBooksByRole(role));

                return View(books);
            }
            catch
            {
                return RedirectToAction("Index", "Account");
            }
        }

        [HttpGet("Home/Book/{Id?}")]
        public async Task<IActionResult> Book(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            try
            {
                var toDTO = Mapper.Map<BookDTO>(await BookRepository.GetBook(id));
                return View(toDTO);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet("FindBook")]
        public async Task<IActionResult> FindBook(string pattern)
        {
            var toDTO = Mapper.Map<BookDTO>(await BookRepository.GetBook(pattern));
            return View(toDTO);
        }

        [HttpGet("AddBook")]
        [Authorize(Roles = "Писатель, Администратор")]
        public async Task<IActionResult> AddBook()
        {
            var toDTO = Mapper.Map<ListDTO>(await ListService.GetListEntities());
            return View(toDTO);
        }

        [HttpPost("AddBook")]
        [Authorize(Roles = "Администратор")]
        public async Task<string> AddBook(BookDTO book)
        {
            try
            {
                await BookRepository.AddBook(Mapper.Map<Book>(book));
                return "Книга добавлена";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpGet("Home/ChangeBook/{Id?}")]
        [Authorize(Roles = "Писатель, Администратор")]
        public async Task<IActionResult> ChangeBook(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            try
            {
                var toDTO = Mapper.Map<ListDTO>(await ListService.GetFullListEntities((int)id));
                return View(toDTO);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpPost("Home/ChangeBook/{Id?}")]
        [Authorize(Roles = "Писатель, Администратор")]
        public async Task<IActionResult> Change(BookDTO book, int[] tagsId)
        {
            try
            {
                await BookService.ChangeBook(Mapper.Map<Book>(book), tagsId);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet("Home/DeleteBook/{Id?}")]
        [Authorize(Roles = "Писатель, Администратор")]
        public async Task<string> DeleteBook(BookDTO bookDTO)
        {
            await BookRepository.DeleteBook(Mapper.Map<Book>(bookDTO));
            return "Книга удалена";
        }

        [HttpGet("Home/Book/Filters")]
        public async Task<IActionResult> FilterBook()
        {
            var list = Mapper.Map<ListDTO>(await ListService.GetListAuthorAndTag());
            return View(list);
        }

        [Route("Home/BookResult")]
        public async Task<IActionResult> FilterBookResult(double rating, int author, string title, string tagsId, int page = 1)
        {
            if (tagsId == null)
                tagsId = Request.Form["tags"].ToString();

            SortDTO pattern = new SortDTO()
            {
                AverageRating = rating,
                AuthorId = author,
                Title = title
            };

            var book = Mapper.Map<Book>(pattern);
            var viewModel = await PaginationService.GetPaginationModel(book, tagsId, page);

            return View(viewModel);
        }

        [HttpGet("Home/ChangeStatus/{Id?}")]
        [Authorize(Roles = "Писатель, Администратор, Проверяющий")]
        public async Task<IActionResult> ChangeStatus(int? id)
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            var list = await ListService.GetListBookAndStatus(role, (int)id);

            return View(list);
        }

        [HttpPost("Home/ChangeStatus/{Id?}")]
        [Authorize(Roles = "Писатель, Администратор, Проверяющий")]
        public async Task<IActionResult> ChangeStatus(BookDTO book)
        {
            await BookRepository.ChangeBookStatus(Mapper.Map<Book>(book));
            return RedirectToAction("Index");
        }

        [HttpPost("Home/Book/{Id?}")]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> AddImage(int? id)
        {
            var file = Request.Form.Files[0];
            await BookService.AddBookImage((int)id, file);

            return RedirectToAction("Index");
        }
    }
}