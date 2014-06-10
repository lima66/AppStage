using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsModel
{
    public class News
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Titolo { get; set; }
        public string  Testo { get; set; }
        public string Foto { get; set; }
    }
}
