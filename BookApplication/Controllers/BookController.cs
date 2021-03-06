﻿using Microsoft.AspNetCore.Mvc;
using System;
using Application.Logic;
using Application.DTO;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Application.Pagination;
using System.Security.Claims;
using System.IO;

namespace WebAPI.Controllers
{
    public class BookController : Controller
    {
        IBookService BookService { get; set; }
        IGenreService GenreService { get; set; }
        IAuthorService AuthorService { get; set; }
        IStatusService StatusService { get; set; }
        ISeriesService SeriesService { get; set; }
        ITagService TagService { get; set; }

        static List<BookDTO> BookForPagination { get; set; }

        public BookController(IBookService BookService, IGenreService GenreService, 
                              IAuthorService AuthorService, IStatusService StatusService, 
                              ISeriesService SeriesService, ITagService TagService)
        {
            this.BookService = BookService;
            this.GenreService = GenreService;
            this.AuthorService = AuthorService;
            this.StatusService = StatusService;
            this.SeriesService = SeriesService;
            this.TagService = TagService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;

                List<BookDTO> books = new List<BookDTO>();
                switch (role)
                {
                    case "Администратор":
                        books = await BookService.GetBook();
                        break;
                    case "Проверяющий":
                        books = await BookService.GetBook("На рассмотрении");
                        books.AddRange(await BookService.GetBook("Опубликовано"));
                        books.AddRange(await BookService.GetBook("Снято с публикации"));
                        books.OrderBy(b => b.Id);
                        break;
                    case "Писатель":
                        books = await BookService.GetBook();
                        break;

                    default:
                        books = await BookService.GetBook("Опубликовано");
                        break;
                }

                ViewData["role"] = role;
                return View(books);
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet("Home/Book/{Id?}")]
        public async Task<IActionResult> Book(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            try
            {
                return View(await BookService.GetBook(id));
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }
        }

        [HttpGet("FindBook")]
        public async Task<IActionResult> FindBook(string pattern)
        {
            return View(await BookService.GetBook(pattern));
        }

        [HttpGet("AddBook")]
        [Authorize(Roles = "Писатель, Администратор")]
        public async Task<IActionResult> AddBook()
        {
            ListDTO listDTO = new ListDTO
            {
                GenreDTO = await GenreService.GetGenre(),
                AuthorDTO = await AuthorService.GetAuthor(),
                BookStatusDTO = await StatusService.GetStatus(),
                BookSeriesDTO = await SeriesService.GetSeries()
            };
            return View(listDTO);
        }

        [HttpPost("AddBook")]
        [Authorize(Roles = "Администратор")]
        public async Task<string> AddBook(BookDTO book)
        {
            try
            {
                await BookService.AddBook(book);
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
                ListDTO listDTO = new ListDTO
                {
                    GenreDTO = await GenreService.GetGenre(),
                    AuthorDTO = await AuthorService.GetAuthor(),
                    BookStatusDTO = await StatusService.GetStatus(),
                    BookSeriesDTO = await SeriesService.GetSeries(),
                    TagDTO = await TagService.GetTag(),
                    BookDTO = await BookService.GetBook(id)
                };
                return View(listDTO);
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
                List<BookToTagDTO> tags = new List<BookToTagDTO>();

                foreach (int tagId in tagsId)
                    tags.Add(new BookToTagDTO(book.Id, tagId));


                book.BookToTagsDTO = tags;
                await BookService.ChangeBook(book);

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
            await BookService.DeleteBook(bookDTO);

            return "Книга удалена";
        }

        [HttpGet("Home/Book/Filters")]
        public async Task<IActionResult> FilterBook()
        {
            ListDTO listDTO = new ListDTO()
            {
                AuthorDTO = await AuthorService.GetAuthor(),
                TagDTO = await TagService.GetTag()
            };

            return View(listDTO);
        }

        [HttpPost("Home/Book/Filters")]
        public async Task<IActionResult> FilterBookResult(BookDTO bookDTO, int[] tagsId)
        {
            List<BookToTagDTO> bookToTags = new List<BookToTagDTO>();

            foreach (int tagId in tagsId)
                bookToTags.Add(new BookToTagDTO(bookDTO.Id, tagId));

            bookDTO.BookToTagsDTO = bookToTags;
            BookForPagination = await BookService.GetBook(bookDTO);

            return RedirectPermanent("~/Home/BookResult");            
        }

        [Route("Home/BookResult")]
        [Authorize(Roles = "Администратор")]
        public IActionResult FilterResult(int page = 1)
        {
            int pageSize = 1;
            int count = BookForPagination.Count;
            List<BookDTO> items = BookForPagination.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel viewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Books = items
            };

            return View(viewModel);
        }

        [HttpGet("Home/ChangeStatus/{Id?}")]
        [Authorize(Roles = "Писатель, Администратор, Проверяющий")]
        public async Task<IActionResult> ChangeStatus(int? id)
        {
            string role = User.FindFirst(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value;
            var list = new ListDTO();
            list.BookDTO = await BookService.GetBook(id);
            switch (role)
            {
                case "Проверяющий":
                    list.BookStatusDTO = await StatusService.GetStatus();
                    list.BookStatusDTO = list.BookStatusDTO.Where(s => s.Id != 1).ToList();
                    break;

                case "Писатель":
                    list.BookStatusDTO = await StatusService.GetStatus();
                    list.BookStatusDTO = list.BookStatusDTO.Where(s => s.Id == 1 || s.Id == 2).ToList();
                    break;
                case "Администратор":
                    list.BookStatusDTO = await StatusService.GetStatus();
                    break;
            };
            
            return View(list);
        }

        [HttpPost("Home/ChangeStatus/{Id?}")]
        [Authorize(Roles = "Писатель, Администратор, Проверяющий")]
        public async Task<IActionResult> ChangeStatus(BookDTO book)
        {
            await BookService.ChangeBookStatus(book);

            return RedirectToAction("Index");
        }

        [HttpPost("Home/Book/{Id?}")]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> AddImage(int? id)
        {
            BookDTO book = new BookDTO();
            book.Id = (int)id;

            using (var target = new MemoryStream())
            {
                await Request.Form.Files[0].CopyToAsync(target);
                book.Image = target.ToArray();
            }
            await BookService.ChangeBookImage(book);

            return RedirectToAction("Index");
        }
    }
}
