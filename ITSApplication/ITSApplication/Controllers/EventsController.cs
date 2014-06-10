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
    public class EventsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
	}

    public class EventsApiController : ApiController
    {
        EventRepository eventsRepository = new EventRepository();

        public IEnumerable<News> getAll()
        {
            return (List<News>)eventsRepository.GetAll();
        }
    }
}