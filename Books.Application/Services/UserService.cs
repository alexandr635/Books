﻿using Books.Domain.Entities;
using Books.Domain.Interfaces;
using Books.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace Books.Application.Services
{
    public class UserService : IUserService
    {
        IUserRepository UserRepository { get; set; }
        IBookRepository BookRepository { get; set; }

        public UserService(IUserRepository userRepository, IBookRepository bookRepository)
        {
            UserRepository = userRepository;
            BookRepository = bookRepository;
        }

        public async Task DeleteUser(int id)
        {
            User user = new User(id);
            await UserRepository.DeleteUser(user);
        }

        public async Task<User> AddUser(User user)
        {
            var check = await UserRepository.GetUser(user.Login);
            if (check != null)
                return null;
            else
            {
                user.SetRole(4);
                await UserRepository.AddUser(user);
                var res = await UserRepository.GetUser(user.Login);
                return res;
            }
        }

        public async Task<User> AddUserRent(int id, string name)
        {
            var user = await UserRepository.GetUserWithBooks(name);
            var book = await BookRepository.GetBook(id);
            var rent = new BookRent(user.Id, book.Id, new DateTime().AddMonths(3));

            foreach(var userRent in user.BookRents)
                if (userRent.BookId == id)
                    return user;

            await UserRepository.AddUserRent(rent);

            return user;
        }

        public async Task<User> AddUserFavorite(int id, string name)
        {
            var user = await UserRepository.GetUserWithBooks(name);
            var book = await BookRepository.GetBook(id);
            var favorite = new UserToBook(book.Id, user.Id, book, user);

            foreach(var fav in user.UserToBooks)
                if (fav.BookId == id)
                    return user;

            await UserRepository.AddUserFavorite(favorite);

            return user;
        }
    }
}
