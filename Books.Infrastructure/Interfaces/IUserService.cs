﻿using System.Threading.Tasks;

namespace Books.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task DeleteUser(int id);
    }
}