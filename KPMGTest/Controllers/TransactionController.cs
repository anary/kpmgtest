using KPMG.Core.Contract;
using KPMG.Core.Entities;
using KPMG.DataProcess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace KPMGTest.Controllers
{
    public class TransactionController : Controller
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<Transaction> transactionRepository;

        public TransactionController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            transactionRepository = _unitOfWork.Repository<Transaction>();
        }
        //
        // GET: /Transaction/

        public ActionResult Index(int? page)
        {
            var transactions = transactionRepository.GetAll().ToList();
            ViewBag.SuccessedCount = transactions.Count();
            var pageNumber = page ?? 1;
            var onePageOfTransactions = transactions.ToPagedList(pageNumber, 20);
            ViewBag.OnePageOfTransactions = onePageOfTransactions;
            return View();
        }

        //public ActionResult GoodTrans(int? page)
        //{
        //    var transaction = transactionRepository.GetAll().ToList();
        //    ViewBag.SuccessedCount = transaction.Count();
        //    var pageNumber = page ?? 1;
        //    var onePageOfTransaction = transaction.ToPagedList(pageNumber, 20);
        //    ViewBag.OnePageOfTransaction = onePageOfTransaction;
        //    return View();
        //}

        public ActionResult Edit(int id)
        {
            var transaction = transactionRepository
                .FindBy(t => t.Id == id).SingleOrDefault();
            return View(transaction);
        }

        [HttpPost]
        public ActionResult Edit(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                transactionRepository.Update(transaction);
                _unitOfWork.Save();
                return RedirectToAction("Index");

            }
            return View();
        }

        public ActionResult Delete(int id)
        {
            if (id > 0)
            {
               var trans = transactionRepository.FindBy(t => t.Id == id).SingleOrDefault();
               if (trans != null)
               {
                   transactionRepository.Delete(trans);
                   _unitOfWork.Save();
                   return RedirectToAction("Index");
               }
            }
            return View();
        }

   
    }
}
