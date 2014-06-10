using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Data;
using ObjectsModel;

namespace ITSApplication.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}

    public class NewsApiController : ApiController
    {
        NewsRepository newsRepository = new NewsRepository();

        // GET api/newsApi/
        public IEnumerable<News> GetAll()
        {
            return (List<News>)newsRepository.GetAll();
        }

        // GET api/newsApi/id
        public News Get(int id)
        {
            return (News)newsRepository.Get(id);
        }

        // PUT api/newsApi/
        public void Put(News news)
        {
            newsRepository.Put(news);
        }

        // POST api/newsApi/
        public void Post(News news)
        {
            newsRepository.Post(news);
        }

        // DELETE api/newsApi/
        public void Delete(int id)
        {
            newsRepository.Delete(id);
        }
    }
}