using Microbloging.Data;
using Microbloging.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Microbloging.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var model = new PostRepository().GetAllPost();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Post(string post, HttpPostedFileBase file)
        {
            var imgUrl = "";
            if (file != null)
            {
                var extention = file.FileName.Substring(file.FileName.LastIndexOf('.'));
                var fileName = new Guid().ToString().Replace("-", "").Replace(" ", "") + "." + extention;
                var path = Path.Combine(Server.MapPath("~/Content/Upload"), fileName);
                imgUrl = @"/Content/Upload/" + fileName;
                file.SaveAs(path);
            }
            var model = new Post()
            {
                Message = post,
                ImageUrl = imgUrl
            };
            new PostRepository().AddPost(model);

            return PartialView("_Post", model);
        }
    }
}