using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Humancare.Data;
using Humancare.Data.repositories;
using HumanCare.BLL;

namespace HumanCarePresentationLayer.Areas.Manager.Controllers
{
    public class BillController : Controller
    {
        private BillRepository billRepo = new BillRepository();
        private ManagerBill billProcess = new ManagerBill();
        //
        // GET: /Manager/Bill/

        public ActionResult Index()
        {
            IEnumerable<Bill> Bills = billRepo.getBills();
            return View(Bills);
        }
        //
        // GET: /Manager/Bill/Details/5

        public ActionResult Details(int id = 0)
        {
            Bill bill = billRepo.getBill(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }
        //
        // GET: /Manager/Bill/Create

        public ActionResult Create()
        {
            Bill bill = new Bill();
            bill.amount = 0;
            bill.dateOfBill = DateTime.Now;
            bill.description = "bill";
            bill.isValid = true;
            bill.ErrorMessage = String.Empty;
            bill.treatmentId = 0;
            return View(bill);
        }

        //
        // POST: /Manager/Bill/Create

        [HttpPost]
        public ActionResult Create(Bill bill)
        {
            if (ModelState.IsValid)
            {
                billProcess.GenerateBill(bill);
                if (bill.ErrorMessage == String.Empty)
                {
                    return RedirectToAction("Details", bill);
                }
                else
                {
                    ViewBag.errorMessage = bill.ErrorMessage;
                    return View(bill);
                }
            }

            return View(bill);
        }

        //
        // GET: /Manager/Bill/Delete/5

        public ActionResult Delete(int id=0)
        {
            Bill bill = billRepo.getBill(id);
            if (bill == null)
            {
                return HttpNotFound();
            }
            return View(bill);
        }

        //
        // POST: /Manager/Bill/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                // TODO: Add delete logic here

                billRepo.delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
