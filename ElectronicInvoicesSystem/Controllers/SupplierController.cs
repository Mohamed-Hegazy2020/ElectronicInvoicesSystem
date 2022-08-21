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
    public class SupplierController : Controller
    {
        private readonly DatabaseContext _context;
        public SupplierController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: SupplierController
        public ActionResult Index()
        {
            List<SuppliersViewModel> cv = new List<SuppliersViewModel>();
            try
            {
                var cs = _context.Supplier.ToList();
                foreach (var c in cs)
                {
                    cv.Add(new SuppliersViewModel()
                    {
                        UniqueId = c.UniqueId,
                        Code = c.Code,
                        CreationDate = c.CreationDate,                     
                        NameAr = c.NameAr,
                        Address = c.Address,
                        Tel = c.Tel,
                        Mobile = c.Mobile,
                        Email = c.Email,                      
                        NationalID = c.NationalID,
                        ClassType = c.ClassType,
                        CountryCode = c.CountryCode,
                        Governate = c.Governate,
                        RegionCity = c.RegionCity,
                        BuildingNumber = c.BuildingNumber,
                        IDType = c.IDType,
                    });
                }

            }
            catch (Exception)
            {
                return View(cv);
            }
            return View(cv);
        }

        // GET: SupplierController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            return View(new SuppliersViewModel());
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuppliersViewModel cv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Suppliers c = new Suppliers();
                    c.Code = cv.Code;
                    c.CreationDate = cv.CreationDate;                  
                    c.NameAr = cv.NameAr;
                    c.Address = cv.Address;
                    c.Tel = cv.Tel;
                    c.Mobile = cv.Mobile;
                    c.Email = cv.Email;
                    c.NationalID = cv.NationalID;
                    c.ClassType = cv.ClassType;
                    c.CountryCode = cv.CountryCode;
                    c.Governate = cv.Governate;
                    c.RegionCity = cv.RegionCity;
                    c.BuildingNumber = cv.BuildingNumber;
                    c.IDType = cv.IDType;
                    c.Street = cv.Street;
                    _context.Supplier.Add(c);
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

        // GET: SupplierController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                SuppliersViewModel cv = new SuppliersViewModel();
                var c = _context.Supplier.Find(id);
                if (c != null)
                {
                    cv.UniqueId = c.UniqueId;
                    cv.Code = c.Code;
                    cv.CreationDate = c.CreationDate;
                    cv.NameAr = c.NameAr;
                    cv.Address = c.Address;
                    cv.Tel = c.Tel;
                    cv.Mobile = c.Mobile;
                    cv.Email = c.Email;
                    cv.NationalID = c.NationalID;
                    cv.ClassType = c.ClassType;
                    cv.CountryCode = c.CountryCode;
                    cv.Governate = c.Governate;
                    cv.RegionCity = c.RegionCity;
                    cv.BuildingNumber = c.BuildingNumber;
                    cv.IDType = c.IDType;
                    cv.Street = c.Street;
                }
                return View(cv);
            }
            catch (Exception)
            {
                return View();

            }
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuppliersViewModel cv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Suppliers c = _context.Supplier.Find(id);
                    if (c != null)
                    {
                        c.Code = cv.Code;
                        c.CreationDate = cv.CreationDate;
                        c.NameAr = cv.NameAr;
                        c.Address = cv.Address;
                        c.Tel = cv.Tel;
                        c.Mobile = cv.Mobile;
                        c.Email = cv.Email;
                        c.NationalID = cv.NationalID;
                        c.ClassType = cv.ClassType;
                        c.CountryCode = cv.CountryCode;
                        c.Governate = cv.Governate;
                        c.RegionCity = cv.RegionCity;
                        c.BuildingNumber = cv.BuildingNumber;
                        c.IDType = cv.IDType;
                        c.Street = cv.Street;
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

        // GET: SupplierController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SupplierController/Delete/5
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
