using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WoodworkingShop.Domain.Interfaces
{
    public interface IRepository<T>
    {
        Task<T> GetById(int id);
        Task<IList<T>> ListAll();
    }
}
