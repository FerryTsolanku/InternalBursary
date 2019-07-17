using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Internal_Bursary.Models;
using DevExpress.Web.Mvc;

namespace Internal_Bursary.Controllers
{
    public class SubjectsController : Controller
    {
        private BursaryDBContext db = new BursaryDBContext();

              // GET: Subjects
        public ActionResult Index()
        {
            return View("Index");
            //RedirectToAction("_GridView1Partial");
        }


        // GET: Subjects/Details/5
        [ValidateInput(false)]
        public ActionResult SubjectView()
        {
           
            return View("SubjectView", db.Subs.ToList());
        }
        [ValidateInput(false)]
        public ActionResult BatchEditingUpdateModel(MVCxGridViewBatchUpdateValues<object, int> updateValues)
        {
            foreach (var product in updateValues.Insert)
            {
                if (updateValues.IsValid(product))
                    InsertProduct(product, updateValues);
            }
            foreach (var product in updateValues.Update)
            {
                if (updateValues.IsValid(product))
                    UpdateProduct(product, updateValues);
            }
            foreach (var productID in updateValues.DeleteKeys)
            {
                DeleteProduct(productID, updateValues);
            }
            return PartialView("SubjectView", db.Subs.ToList());
        }
        [HttpPost]
        public ActionResult BatchEditing()
        {
            return View("Index", db.Subs.ToList());
        }
        protected void InsertProduct(object subject, MVCxGridViewBatchUpdateValues<object, int> updateValues)
        {
            try
            {
                var subs = from m in db.Subs
                           select m.SubjID;
            }
            catch (Exception e)
            {
                updateValues.SetErrorText(subject, e.Message);
            }
        }
        protected void UpdateProduct(object subject, MVCxGridViewBatchUpdateValues<object, int> updateValues)
        {
            try
            {
                var subs = from m in db.Subs
                           select m.SubjID;
            }
            catch (Exception e)
            {
                updateValues.SetErrorText(subject, e.Message);
            }
        }
        protected void DeleteProduct(int EMPID, MVCxGridViewBatchUpdateValues<object, int> updateValues)
        {
            try
            {
                var subs = from m in db.Subs
                              select m.SubjID;
            }
            catch (Exception e)
            {
                updateValues.SetErrorText(EMPID, e.Message);
            }
        }
    }
}
