using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationBank.ServiceReferenceBank;

namespace WebApplicationBank.Controllers
{
    public class BankController : Controller
    {
        Service1Client service;

        public BankController()
        {
            service = new Service1Client();
        }
        // GET: Bank
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string UserName, string Password)
        {
            if(service.Login(UserName, Password) == null)
            {
                return View("Failed");
            }
            return View("Success");
        }

        // GET: Bank/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bank/Create
        [HttpPost]
        public ActionResult Create(Account account)
        {
            Guid myuuid = Guid.NewGuid();
            var accountNew = new Account();
            accountNew.AccountNumber = account.AccountNumber;
            accountNew.UserName = account.UserName;
            accountNew.Password = account.Password;
            accountNew.Balance = account.Balance;
            accountNew.CreateAt = DateTime.Now;
            accountNew.UpdateAt = DateTime.Now;
            accountNew.DeleteAt = DateTime.Now;
            accountNew.Token = myuuid.ToString();
            
            
            try
            {
                // TODO: Add insert logic here
                if (service.CreateAccount(accountNew) == null)
                {
                    return View("Failed");
                }
                
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Deposit(int AccountNumber, double Amount)
        {
            if(service.Deposit(AccountNumber, Amount)== null)
            {
                return View("Failed");
            }
            return View("Success");
        }

        public ActionResult Withdraw(int AccountNumber, double Amount)
        {
            if (service.Withdraw(AccountNumber, Amount) == null)
            {
                return View("Failed");
            }
            return View("Success");
        }

        public ActionResult Transfer(int SenderAccountNumber, int ReceiverAccountNumber, double Amount)
        {
            if (service.Transfer(SenderAccountNumber, ReceiverAccountNumber, Amount) == null)
            {
                return View("Failed");
            }
            return View("Success");
        }


        // GET: Bank/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Bank/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Bank/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bank/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
