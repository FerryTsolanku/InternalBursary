using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Internal_Bursary.Models;

namespace Internal_Bursary.Controllers
{
   // public override string Name { get { return "MasterDetail"; } }
    public class BursaryModelsController : Controller
    {
        private BursaryDBContext db = new BursaryDBContext();
        private EMpCurr CurrEmpModel = new EMpCurr();
        // GET: BursaryModels
        //public ActionResult IndexDetails()
        //{
        //    List<object> myMode = new List<object>();

        //    myMode.Add(db.Employee.ToList());
        //    myMode.Add(db.Curriculum.ToList());

        //    return View(myMode);
        //   // RedirectToAction("_GridView1Partial");
        //}

        // GET: BursaryModels/Details/5
        public ActionResult Details(int? id)
        {
            CurriculumDetails CurrModel = db.Curriculum.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (CurrModel == null)
            {
                return HttpNotFound();
            }
            return View(CurrModel);
        }

        // GET: BursaryModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BursaryModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PassID,Username,password")] BursaryModel bursaryModel)
        {
            if (ModelState.IsValid)
            {
                var username = bursaryModel.Username;
                var pass = bursaryModel.password;

                var burUser = from m in db.Bursaries
                             select m.Username;
                var burPass = from m in db.Bursaries
                              select m.password;

                if (burUser.Contains(username) && burPass.Contains(pass))
                {
                    return RedirectToAction("IndexDetails");
                    
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password.");

                }
            }

             return View(bursaryModel);
        }

        public ActionResult CurriculumDetails([Bind(Include = "EMPID,SubCrse,PassSubj,YrPass,FailSubj,YrFail,AGBurAmountPaid,AGLoanPaid")] CurriculumDetails CurrModel)
        {
            if (ModelState.IsValid)
            {
                db.Curriculum.Add(CurrModel);
                db.SaveChanges();
                //return RedirectToAction("IndexDetails");
            }

            return View(CurrModel);
        }

        // GET: BursaryModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurriculumDetails CurrModel = db.Curriculum.Find(id);
            if (CurrModel == null)
            {
                return HttpNotFound();
            }
            return View(CurrModel);
        }

        // POST: BursaryModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMPID,SubCrse,PassSubj,YrPass,FailSubj,YrFail,AGBurAmountPaid,AGLoanPaid")] CurriculumDetails CurrModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(CurrModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("IndexDetails");
            }
            return View(CurrModel);
        }

        // GET: BursaryModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CurriculumDetails CurrModel = db.Curriculum.Find(id);
            if (CurrModel == null)
            {
                return HttpNotFound();
            }
            return View(CurrModel);
        }

        // POST: BursaryModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CurriculumDetails CurrModel = db.Curriculum.Find(id);
            db.Curriculum.Remove(CurrModel);
            db.SaveChanges();
            return RedirectToAction("IndexDetails");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

       // [ValidateInput(true)]
        //public ActionResult GridView1Partial()
        //{
        //    var model = new object[0];
        //    List<object> myMode = new List<object>();
        //    myMode.Add(db.Employee.ToList());
        //    myMode.Add(db.Curriculum.ToList());
        //     return PartialView("_GridView1Partial", db.Curriculum.ToList());
        //   // return from CurriculumDetails in db.Curriculum select CurriculumDetails;
        //}
        //public override string Name { get { return "IndexDetails"; } }
        public ActionResult IndexDetails()
        {
            return View("IndexDetails", db.Employee.ToList());
        }

        public ActionResult MasterDetailMasterPartial()
        {
            return PartialView("MasterDetailMasterPartial", db.Employee.ToList());
        }

        public ActionResult MasterDetailDetailPartial(EmployeeDetails empDetails)
        {
            var myModel =  empDetails.EMPID;
            //var burUser = " ";
            //var burUser = from m in db.Curriculum
            //              join CurriculumDetails in db.Curriculum on curr.EMPID equals emModel.EMPID
            //              where curr.EMPID == emModel.EMPID
            //              select m;


            // return PartialView("MasterDetailDetailPartial", db.Curriculum.Where(i => i.EMPID == myModel).ToList());
            return PartialView("MasterDetailDetailPartial", db.Curriculum.ToList());
        }
        //[HttpPost, ValidateInput(false)]
        //public ActionResult GridView1PartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] Internal_Bursary.Models.CurriculumDetails item)
        //{
        //    var model = new object[0];
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Insert here a code to insert the new item in your model
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_GridView1Partial", model);
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult GridView1PartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] Internal_Bursary.Models.CurriculumDetails item)
        //{
        //    var model = new object[0];
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            // Insert here a code to update the item in your model
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    else
        //        ViewData["EditError"] = "Please, correct all errors.";
        //    return PartialView("_GridView1Partial", model);
        //}
        //[HttpPost, ValidateInput(false)]
        //public ActionResult GridView1PartialDelete(System.Int32 SubCrseID)
        //{
        //    var model = new object[0];
        //    if (SubCrseID >= 0)
        //    {
        //        try
        //        {
        //            // Insert here a code to delete the item from your model
        //        }
        //        catch (Exception e)
        //        {
        //            ViewData["EditError"] = e.Message;
        //        }
        //    }
        //    return PartialView("_GridView1Partial", model);
        //}
    }
}
