using ElectronicInvoicesSystem.Data;
using ElectronicInvoicesSystem.Models;
using ElectronicInvoicesSystem.ModelsView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicInvoicesSystem.Controllers
{
    [Authorize]
    public class ItemsController : Controller
    {
        private readonly DatabaseContext _context;
        public ItemsController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: ItemsController
        public ActionResult Index()
        {
            List<ItemsViewModel> cv = new List<ItemsViewModel>();
            try
            {
                var cs = _context.Item.ToList();
                foreach (var c in cs)
                {
                    cv.Add(new ItemsViewModel()
                    {
                        UniqueId = c.UniqueId,
                        Code = c.Code,
                        CreationDate = c.CreationDate,
                        NameAr = c.NameAr,
                        UnitId = c.UnitId,
                        ItemTaxAuthorityCode = c.ItemTaxAuthorityCode
                    });
                }

                return View(cv);
            }
            catch (Exception)
            {
                return View(cv);
            }
        }

        // GET: ItemsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ItemsController/Create
        public ActionResult Create()
        {
            ItemsViewModel itms = new ItemsViewModel();
            var Company = _context.Company.FirstOrDefault();
            if (Company !=null)
            {
                itms.CompanyTaxRegestrationNo = Company.TaxAuthorityRegestrationNumber;
            }

            itms.Units = _context.Unit.ToList();
            itms.ItemCodeType = new List<ItemCodeType>()
            {
                new ItemCodeType(){ name="EGS" },
                new ItemCodeType(){ name="GS1" },

            };
            return View(itms);

        }

        // POST: ItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Items cv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Items c = new Items();
                    c.Code = cv.Code;
                    c.CreationDate = cv.CreationDate;
                    c.NameAr = cv.NameAr;
                    c.ItemTaxAuthorityCode = cv.ItemTaxAuthorityCode;
                    c.ItemTaxAuthorityType = cv.ItemTaxAuthorityType;
                    c.UnitId = cv.UnitId;
                    c.GPCBrickCode = cv.GPCBrickCode;
                    _context.Item.Add(c);
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

        // GET: ItemsController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ItemsViewModel cv = new ItemsViewModel();
                var c = _context.Item.Find(id);
                if (c != null)
                {
                    cv.Code = c.Code;
                    cv.CreationDate = c.CreationDate;
                    cv.NameAr = c.NameAr;
                    cv.ItemTaxAuthorityCode = c.ItemTaxAuthorityCode;
                    cv.UnitId = c.UnitId;
                    cv.ItemTaxAuthorityType = c.ItemTaxAuthorityType;
                    cv.GPCBrickCode = c.GPCBrickCode;

                }
                cv.Units = _context.Unit.ToList();
                cv.ItemCodeType = new List<ItemCodeType>()
                 {
                  new ItemCodeType(){ name="EGS" },
                  new ItemCodeType(){ name="GPC" },

                 };
                return View(cv);
            }
            catch (Exception)
            {
                return View();

            }
        }

        // POST: ItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemsViewModel cv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Items c = _context.Item.Find(id);
                    if (c != null)
                    {
                        c.Code = cv.Code;
                        c.CreationDate = cv.CreationDate;
                        c.NameAr = cv.NameAr;
                        c.ItemTaxAuthorityCode = cv.ItemTaxAuthorityCode;
                        c.UnitId = cv.UnitId;
                        c.GPCBrickCode = cv.GPCBrickCode;
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

        // GET: ItemsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ItemsController/Delete/5
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
