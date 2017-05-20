using Hasan.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hasan.App.Controllers
{
    public class UsergrpController : Controller
    {
        // GET: Usergrp
        private HasanHoutoneEntities db = new HasanHoutoneEntities();

        public ActionResult Index()
        {
            if (GlobalClass.SystemSession)
            {
                var temp = from x in db.Usergroup where x.CompanyKey == GlobalClass.Company.CompanyKey select x;
                temp = temp.OrderBy(m => m.GroupName);
                return View(temp.ToList());
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
        public ActionResult Details(Guid id)
        {
            if (GlobalClass.SystemSession)
            {
                Usergroup company = db.Usergroup.Find(id);
                if (company == null)
                {
                    return HttpNotFound();
                }
                return View(company);

            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
        public ActionResult Create()
        {
            if (GlobalClass.SystemSession)
            {
                return View();
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
        [HttpPost]
        public ActionResult Create(Usergroup model, Guid?[] formlist)
        {
            if (GlobalClass.SystemSession)
            {
                Usergroup abm = new Usergroup();
                abm.GroupName = model.GroupName;
                abm.GroupID = model.GroupID;
                abm.UserGroupKey = Guid.NewGuid();
                abm.CompanyKey = GlobalClass.Company.CompanyKey;
                db.Usergroup.Add(abm);
                db.SaveChanges();
                if (formlist == null)
                {

                }
                else
                {
                    if (formlist.Count() > 0)
                    {
                        foreach (var item in formlist)
                        {
                            db = new HasanHoutoneEntities();
                            Forms f = db.Forms.Find(item);
                            CheckForModule(f.ModuleID, abm.UserGroupKey);
                            UserGroupForm obj = new UserGroupForm();
                            obj.CompanyKey = GlobalClass.Company.CompanyKey;
                            obj.ModuleKey = f.ModuleID;
                            obj.UserGroupKey = abm.UserGroupKey;
                            obj.UserGroupFormKey = Guid.NewGuid();
                            obj.FormKey = item;
                            db.UserGroupForm.Add(obj);
                            db.SaveChanges();
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        public ActionResult Edit(Guid id)
        {
            if (GlobalClass.SystemSession)
            {
                Usergroup obj = db.Usergroup.Find(id);
                return View(obj);
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }
        [HttpPost]
        public ActionResult Edit(Usergroup model, Guid?[] formlist, Guid?[] DelList)
        {
            if (GlobalClass.SystemSession)
            {
                Usergroup abm = db.Usergroup.Find(model.UserGroupKey);
                abm.GroupName = model.GroupName;
                abm.GroupID = model.GroupID;
                db.SaveChanges();
                if (formlist == null)
                {

                }
                else
                {
                    if (formlist.Count() > 0)
                    {
                        foreach (var item in formlist)
                        {
                            db = new HasanHoutoneEntities();
                            Forms f = db.Forms.Find(item);
                            CheckForModule(f.ModuleID, model.UserGroupKey);
                            UserGroupForm obj = new UserGroupForm();
                            obj.CompanyKey = GlobalClass.Company.CompanyKey;
                            obj.ModuleKey = f.ModuleID;
                            obj.UserGroupKey = abm.UserGroupKey;
                            obj.UserGroupFormKey = Guid.NewGuid();
                            obj.FormKey = item;
                            db.UserGroupForm.Add(obj);
                            db.SaveChanges();
                        }
                    }
                }
                if (DelList == null)
                {

                }
                else
                {
                    if (DelList.Count() > 0)
                    {
                        foreach (var item in DelList)
                        {
                            db = new HasanHoutoneEntities();
                            UserGroupForm f = db.UserGroupForm.Find(item);
                            CheckForModuleBeforDelete(f);
                            db.UserGroupForm.Remove(f);
                            db.SaveChanges();
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        private void CheckForModuleBeforDelete(UserGroupForm f)
        {
            HasanHoutoneEntities ac = new HasanHoutoneEntities();
            var temp = from x in ac.UserGroupForm where x.UserGroupKey == f.UserGroupKey && x.ModuleKey == f.ModuleKey && x.CompanyKey == GlobalClass.Company.CompanyKey select x;
            if (temp.Count() > 0)
            {

            }
            else
            {
                UserGroupModule obj = db.UserGroupModule.FirstOrDefault(x => x.UserGroupKey == f.UserGroupKey && x.ModuleKey == f.ModuleKey && x.CompanyKey == GlobalClass.Company.CompanyKey);
                ac.UserGroupModule.Remove(obj);
                ac.SaveChanges();
            }
        }

        private void CheckForModule(Guid moduleID, Guid UserGroupKey)
        {
            HasanHoutoneEntities ac = new HasanHoutoneEntities();
            var temp = from x in ac.UserGroupModule where x.UserGroupKey == UserGroupKey && x.ModuleKey == moduleID && x.CompanyKey == GlobalClass.Company.CompanyKey select x;
            if (temp.Count() > 0)
            {

            }
            else
            {
                UserGroupModule obj = new UserGroupModule();
                obj.CompanyKey = GlobalClass.Company.CompanyKey;
                obj.ModuleKey = moduleID;
                obj.UserGroupKey = UserGroupKey;
                obj.UserGroupModuleKey = Guid.NewGuid();
                ac.UserGroupModule.Add(obj);
                ac.SaveChanges();
            }
        }

        public ActionResult Delete(Guid? id)
        {
            if (GlobalClass.SystemSession)
            {

                Usergroup company = db.Usergroup.Find(id);
                var temp = from x in db.UserGroupForm where x.UserGroupKey == id select x;
                var temp2 = from x in db.UserGroupModule where x.UserGroupKey == id select x;
                var temp3 = from x in db.StaffList where x.Usergr == id select x;
                if (temp.Count() > 0)
                {
                    foreach (var a in temp)
                    {
                        HasanHoutoneEntities ac = new HasanHoutoneEntities();
                        UserGroupForm form = db.UserGroupForm.Find(a.UserGroupFormKey);
                        ac.UserGroupForm.Remove(form);
                        ac.SaveChanges();
                    }
                }
                if (temp3.Count() > 0)
                {
                    foreach (var a in temp3)
                    {
                        HasanHoutoneEntities ac = new HasanHoutoneEntities();
                        StaffList form = db.StaffList.Find(a.PersonnelKey);
                        form.Usergr = null;
                        ac.SaveChanges();
                    }
                }
                if (temp2.Count() > 0)
                {
                    foreach (var a in temp2)
                    {
                        HasanHoutoneEntities ac = new HasanHoutoneEntities();
                        UserGroupModule form = db.UserGroupModule.Find(a.UserGroupModuleKey);
                        ac.UserGroupModule.Remove(form);
                        ac.SaveChanges();
                    }
                }
                db.Usergroup.Remove(company);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Exception e = new Exception("Sorry, your Session has Expired");
                return View("Error", new HandleErrorInfo(e, "UserHome", "Logout"));
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}