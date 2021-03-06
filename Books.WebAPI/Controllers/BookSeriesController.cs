﻿using AutoMapper;
using Books.Application.DTO;
using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Books.WebAPI.Controllers
{
    public class BookSeriesController : Controller
    {
        IBookSeriesRepository BookSeriesRepository { get; set; }
        IBookRepository BookRepository { get; set; }
        IMapper Mapper { get; set; }

        public BookSeriesController(IBookSeriesRepository bookSeriesRepository, IBookRepository bookRepository,
                                    IMapper mapper)
        {
            BookSeriesRepository = bookSeriesRepository;
            BookRepository = bookRepository;
            Mapper = mapper;
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index()
        {
            var listDTO = Mapper.Map<List<BookSeriesDTO>>(await BookSeriesRepository.GetSeries());
            return View(listDTO);
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("AddBookSeries")]
        public async Task<IActionResult> AddBookSeries()
        {
            return View(await BookRepository.GetBook());
        }

        [Authorize(Roles = "Администратор")]
        [HttpPost("AddBookSeries")]
        public async Task<string> AddBookSeries(BookSeriesDTO bookSeriesDTO)
        {
            await BookSeriesRepository.AddSeries(Mapper.Map<BookSeries>(bookSeriesDTO));
            return "Серия добавлена!";
        }

        [Authorize(Roles = "Администратор")]
        [HttpGet("BookSeries/DeleteSeries/{id?}")]
        public async Task<string> AddBookSeries(BookSeriesDTO bookSeriesDTO, int? id)
        {
            if (id == null)
                return "потеряйся";
            else
            {
                await BookSeriesRepository.DeleteSeries(Mapper.Map<BookSeries>(bookSeriesDTO));
                return "Серия удалена";
            }
        }
    }
}