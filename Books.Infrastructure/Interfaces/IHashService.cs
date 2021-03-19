using System;
using System.Collections.Generic;
using System.Text;

namespace Books.Infrastructure.Interfaces
{
    public interface IHashService
    {
        string GetHashPassword(string pass);
    }
}
