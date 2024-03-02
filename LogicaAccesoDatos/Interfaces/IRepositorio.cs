using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Interfaces
{
    public interface IRepositorio<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        T GetById(int id);  
        IEnumerable<T> GetAll();
    }
}
