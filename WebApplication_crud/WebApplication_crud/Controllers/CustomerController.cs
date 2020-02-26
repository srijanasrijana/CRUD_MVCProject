using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication_crud.DataAccess;
using WebApplication_crud.Models;

namespace WebApplication_crud.Controllers
{
    public class CustomerController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }
        // GET: Customer
        public ActionResult InsertCustomer()
        {
            return View();
        }

       
        [HttpPost]

        public ActionResult InsertCustomer(Customer objCustomer)

        {

            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if (ModelState.IsValid) //checking model is valid or not

            {
                DataAccessLayer objDB = new DataAccessLayer();
                string result = objDB.InsertData(objCustomer);
                ViewData["result"] = result;
                ModelState.Clear(); //clearing model
                return View();
            }
           else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }

        }

        [HttpGet]
        public ActionResult ShowAllCustomerDetails()
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer();
            objCustomer.ShowallCustomer = objDB.Selectalldata();
            return View(objCustomer);
        }

        [HttpGet]
        public ActionResult Details()
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer();
            objCustomer.ShowallCustomer = objDB.Selectalldata();
            return View(objCustomer);
        }



        [HttpGet]
        public ActionResult Edit(String ID)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer();
            return View(objDB.SelectDatabyID(ID));
        }

        [HttpPost]
        public ActionResult Edit(Customer objCustomer)
        {
            objCustomer.Birthdate = Convert.ToDateTime(objCustomer.Birthdate);
            if(ModelState.IsValid)
            {
                DataAccessLayer objDb = new DataAccessLayer();
                string result = objDb.UpdateData(objCustomer);
                ViewData["result"] = result;
                ModelState.Clear();
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Error in saving data");
                return View();
            }

           
        }

        [HttpGet]

        public ActionResult Delete(string ID)
        {
            Customer objCustomer = new Customer();
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata
            return View(objDB.SelectDatabyID(ID));

        }

        [HttpPost]

        public ActionResult Delete(Customer objCustomer)

        {
            DataAccessLayer objDB = new DataAccessLayer();
            string result = objDB.DeleteData(objCustomer);
            ViewData["result"] = result;
            ModelState.Clear(); //clearing model
            return View();

        }
    }
}