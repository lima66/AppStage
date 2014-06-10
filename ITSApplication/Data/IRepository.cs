using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    interface IRepository
    {
        IEnumerable<Object> GetAll();
        Object Get(int id);
        void Put(Object myObject);
        void Delete(int id);
        void Post(Object myObject);
    }
}
