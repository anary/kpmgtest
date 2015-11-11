using KPMGTest.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Spatial;
using System.Web;
using System.Web.Mvc;
using KPMG.Core.Contract;
using KPMG.DataProcess;
using PagedList;

namespace KPMGTest.Controllers
{
    public class FileUploadController : Controller
    {

        private IGetData data;
        private IValidateData invalidator;

        public FileUploadController(IGetData data, IValidateData invalidator)
        {
            this.data = data;
            this.invalidator = invalidator;
        }
        //
        // GET: /FileUpload/

        public ActionResult Index()
        {
            var model = new UploadViewModel();
            model.TotalCount = "Please wait for the process";
            model.IsFirstRowAsColumnName = true;
            return View(model);
        }        

        [HttpPost]
        public ActionResult Index(UploadViewModel model)
        {
            ViewBag.ShowResult = false;
            ViewBag.TotalCount = "P";
            model.TotalCount = "";
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(model.File.FileName);
                if (fileName.ToUpper().EndsWith(".XLSX") || fileName.ToUpper().EndsWith(".CSV"))
                {
                    if (model.File.ContentLength > 0)
                    {
                        var database = new DataPersistance();
                        database.CleanTable();
                        var path = Path.Combine(Server.MapPath("~/App_Data/uploads"), fileName);
                        model.File.SaveAs(path);
                        
                        
                        var ts = data.GetData(path,model.IsFirstRowAsColumnName);
                                              
                        
                        var lists = invalidator.ValidatedData(ts);
                        model.TotalCount = "Total count: " + ts.Count() + ", Please click below to view details."; 
                        Session["Errors"] = lists;
                        Session["Count"] = ts.Count();
                        return RedirectToAction("index","Transaction");
                    }
                    return View("index");
                }
            }

            
            return View("index");
        }

        public ActionResult BadTrans(int? page)
        {          
            var lists = Session["Errors"] as ValidatedTransactions;
            if (lists != null)
            {
                ViewBag.FailedCount = lists.FailedTransactions.Count();
                var pageNumber = page ?? 1;
                var onePageOfTransactions = lists.FailedTransactions.ToPagedList(pageNumber, 20);
                ViewBag.OnePageOfTransactions = onePageOfTransactions;
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
