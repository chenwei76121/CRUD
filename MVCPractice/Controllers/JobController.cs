using MVCPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace MVCPractice.Controllers
{
    [RoutePrefix("Job")]
    public class JobController : Controller
    {
        // GET: Job
        [HttpGet]
        [Route()]
        [Route("index")]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route()]
        [Route("index")]
        [ValidateAntiForgeryToken]
        public ActionResult Query(string name , int? pay)
        {
            ViewData["title"] = "職缺管理";
            var queryresult = JobService.Query(name, pay);
            return View("index", queryresult);
        }
        [HttpGet]
        [Route("Add")]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Route("Add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add([Bind(Include = "Code,Name,Desc,MinSalary,MaxSalary,JobLocation")] JobModel item)
        {
            if (ModelState.IsValid)
            {
                JobService.Add(item);
            }
            else
            {
                return View(item);
            }
            return RedirectToAction("index");
        }
        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(Guid id)
        {
            var item = JobService.Query(id);
            if(item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpPost]
        [Route("Update")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(JobModel item)
        {
            JobService.Edit(item);
            return RedirectToAction("index");
        }

        [HttpGet]
        [Route("View/{id}")]
        public ActionResult View(Guid id)
        {
            var item = JobService.Query(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        [HttpGet]
        [Route("Del")]
        public ActionResult Del(Guid id)
        {
            JobService.Del(id);
            return RedirectToAction("index");

        }
    }
}