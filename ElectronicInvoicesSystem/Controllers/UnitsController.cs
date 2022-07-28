using ElectronicInvoicesSystem.Data;
using ElectronicInvoicesSystem.Models;
using ElectronicInvoicesSystem.ModelsView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Controllers
{
    public class UnitsController : Controller
    {
        private readonly DatabaseContext _context;
        public UnitsController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: UnitsController
        public ActionResult Index()
        {
            List<UnitsViewModel> cv = new List<UnitsViewModel>();
            try
            {
                var cs = _context.Unit.ToList();
                foreach (var c in cs)
                {
                    cv.Add(new UnitsViewModel()
                    {
                        UniqueId = c.UniqueId,
                        Code = c.Code,
                        CreationDate = c.CreationDate,
                        NameAr = c.NameAr,
                        UnitTaxAuthorityCode = c.UnitTaxAuthorityCode
                    });
                }
               return View(cv);
            }
            catch (Exception)
            {
                return View(cv);
            }
           
        }

        // GET: UnitsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UnitsController/Create
        public ActionResult Create()
        {
            return View(new UnitsViewModel());
        }

        // POST: UnitsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UnitsViewModel cv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Units c = new Units();
                    c.Code = cv.Code;
                    c.CreationDate = cv.CreationDate;
                    c.NameAr = cv.NameAr;
                    c.UnitTaxAuthorityCode = cv.UnitTaxAuthorityCode;                   
                    _context.Unit.Add(c);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(cv);
                }

            }
            catch
            {
                return View(cv);
            }
        }

        // GET: UnitsController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                UnitsViewModel cv = new UnitsViewModel();
                var c = _context.Unit.Find(id);
                if (c != null)
                {
                    cv.Code = c.Code;
                    cv.CreationDate = c.CreationDate;
                    cv.NameAr = c.NameAr;
                    cv.UnitTaxAuthorityCode = c.UnitTaxAuthorityCode;

                }
                return View(cv);
            }
            catch (Exception)
            {
                return View();

            }
        }

        // POST: UnitsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UnitsViewModel cv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Units c = _context.Unit.Find(id);
                    if (c != null)
                    {
                        c.Code = cv.Code;
                        c.CreationDate = cv.CreationDate;
                        c.NameAr = cv.NameAr;
                        c.UnitTaxAuthorityCode = cv.UnitTaxAuthorityCode;
                        _context.SaveChanges();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        return View(cv);
                    }

                }
                else
                {
                    return View(cv);
                }

            }
            catch
            {
                return View(cv);
            }
        }

        // GET: UnitsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UnitsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
