using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using ObjectsModel;

namespace TestConsole
{
    class Program
    {
        
        static void Main(string[] args)
        {
            NewsRepository rep = new NewsRepository();

            // GET ALL
            //List<News> news = (List<News>)rep.GetAll();

            //foreach (News news_obj in news)
            //{
            //    Console.WriteLine("Titolo : " + news_obj.Titolo + " / "
            //                    + "Testo : " + news_obj.Testo);
            //    Console.WriteLine("");
            //}
            //Console.ReadKey();

            // GET BY ID
            //News news_obj = (News)rep.Get(2);
            //if (news_obj != null) { 
            //    Console.WriteLine(news_obj.Titolo + " / " + news_obj.Testo);
            //    Console.ReadKey();
            //}

            // PUT
            News news = new News();
            news.Id = 3; // bisogna fare in modo che l'id venga generato automaticamente in auto increment
            news.Data = DateTime.Now;
            news.Titolo = "Il mio titolo modificato";
            news.Testo = "Il mio Testo";
            news.Foto = "linkphoto";
            //rep.Put(news);

            // DELETE
            //rep.Delete(4);
            
            // POST
            rep.Post(news);
        }
    }
}
