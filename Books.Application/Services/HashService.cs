using Books.Infrastructure.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;

namespace Books.Application.Services
{
    public class HashService : IHashService
    {
        public string GetHashPassword(string pass)
        {
            MD5 md5 = MD5.Create();
            var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(pass));

            return Convert.ToBase64String(hash);
        }
    }
}
