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
    public class CustomerController : Controller
    {
        private readonly DatabaseContext _context;
        public CustomerController(DatabaseContext context)
        {
            _context = context;

        }

        // GET: CustomerController
        public ActionResult Index()
        {

            List<CustomersViewModel> cv = new List<CustomersViewModel>();
            try
            {
                var cs = _context.Customer.ToList();
                foreach (var c in cs)
                {
                    cv.Add(new CustomersViewModel()
                    {
                        UniqueId = c.UniqueId,
                        Code = c.Code,
                        CreationDate = c.CreationDate,
                        NameEn = c.NameEn,
                        NameAr = c.NameAr,
                        Address = c.Address,
                        Tel = c.Tel,
                        Mobile = c.Mobile,
                        Email = c.Email,
                        TaxRegesterNumber = c.TaxRegesterNumber,
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

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View(new CustomersViewModel());
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomersViewModel cv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customers c = new Customers();
                    c.Code = cv.Code;
                    c.CreationDate = cv.CreationDate;
                    c.NameEn = cv.NameEn;
                    c.NameAr = cv.NameAr;
                    c.Address = cv.Address;
                    c.Tel = cv.Tel;
                    c.Mobile = cv.Mobile;
                    c.Email = cv.Email;
                    c.TaxRegesterNumber = cv.TaxRegesterNumber;
                    c.NationalID = cv.NationalID;
                    c.ClassType = cv.ClassType;
                    c.CountryCode = cv.CountryCode;
                    c.Governate = cv.Governate;
                    c.RegionCity = cv.RegionCity;
                    c.BuildingNumber = cv.BuildingNumber;
                    c.IDType = cv.IDType;
                    c.Street = cv.Street;
                    _context.Customer.Add(c);
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

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CustomersViewModel cv = new CustomersViewModel();
                var c = _context.Customer.Find(id);
                if (c != null)
                {
                    cv.UniqueId = c.UniqueId;
                    cv.Code = c.Code;
                    cv.CreationDate = c.CreationDate;
                    cv.NameEn = c.NameEn;
                    cv.NameAr = c.NameAr;
                    cv.Address = c.Address;
                    cv.Tel = c.Tel;
                    cv.Mobile = c.Mobile;
                    cv.Email = c.Email;
                    cv.TaxRegesterNumber = c.TaxRegesterNumber;
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

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomersViewModel cv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Customers c = _context.Customer.Find(id);
                    if (c != null)
                    {
                        c.Code = cv.Code;
                        c.CreationDate = cv.CreationDate;
                        c.NameEn = cv.NameEn;
                        c.NameAr = cv.NameAr;
                        c.Address = cv.Address;
                        c.Tel = cv.Tel;
                        c.Mobile = cv.Mobile;
                        c.Email = cv.Email;
                        c.TaxRegesterNumber = cv.TaxRegesterNumber;
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

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
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
