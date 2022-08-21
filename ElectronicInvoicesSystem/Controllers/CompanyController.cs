using ElectronicInvoicesSystem.Data;
using ElectronicInvoicesSystem.Models;
using ElectronicInvoicesSystem.ModelsView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ElectronicInvoicesSystem.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        private readonly DatabaseContext _context;
        public CompanyController(DatabaseContext context)
        {
            _context = context;
        }
        // GET: CompanyController
        public ActionResult Index()
        {
            List<CompanyViewModel> cv = new List<CompanyViewModel>();
            try
            {
                var cs = _context.Company.ToList();
                foreach (var c in cs)
                {
                    cv.Add(new CompanyViewModel()
                    {
                        UniqueId = c.UniqueId,  
                        NameAr = c.NameAr, 
                        CreationDate = c.CreationDate,
                        TaxAuthorityRegestrationNumber = c.TaxAuthorityRegestrationNumber,
                        Phone = c.Phone,                      
                        Email = c.Email, 
                        CountryCode = c.CountryCode,
                        Governate = c.Governate,
                        RegionCity = c.RegionCity,
                        BuildingNumber = c.BuildingNumber,   
                        TaxPayerActivityCode=c.TaxPayerActivityCode
                    });
                }

            }
            catch (Exception)
            {
                return View(cv);
            }
            return View(cv);
           
        }

        // GET: CompanyController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyController/Create
        public ActionResult Create()
        {
            return View(new CompanyViewModel());
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CompanyViewModel cv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Company c = new Company();
                    c.NameAr = cv.NameAr;
                    c.CreationDate = cv.CreationDate;                  
                    c.TaxAuthorityRegestrationNumber = cv.TaxAuthorityRegestrationNumber;
                    c.TaxPayerActivityCode = cv.TaxPayerActivityCode;
                    c.Phone = cv.Phone;
                    c.Email = cv.Email;
                    c.Client_ID = cv.Client_ID;
                    c.Client_Secret = cv.Client_Secret; 
                    c.TokenPassword = cv.TokenPassword;
                    c.ClassType = cv.ClassType;
                    c.CountryCode = cv.CountryCode;
                    c.Governate = cv.Governate;
                    c.RegionCity = cv.RegionCity;
                    c.BuildingNumber = cv.BuildingNumber;                 
                    c.Street = cv.Street;
                    _context.Company.Add(c);
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

        // GET: CompanyController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CompanyViewModel cv = new CompanyViewModel();
                var c = _context.Company.Find(id);
                if (c != null)
                {
                    cv.NameAr = c.NameAr;
                    cv.CreationDate = c.CreationDate;
                    cv.TaxAuthorityRegestrationNumber = c.TaxAuthorityRegestrationNumber;
                    cv.TaxPayerActivityCode = c.TaxPayerActivityCode;
                    cv.Phone = c.Phone;
                    cv.Email = c.Email;
                    cv.Client_ID = c.Client_ID;
                    cv.Client_Secret = c.Client_Secret;
                    cv.TokenPassword = c.TokenPassword;
                    cv.ClassType = c.ClassType;
                    cv.CountryCode = c.CountryCode;
                    cv.Governate = c.Governate;
                    cv.RegionCity = c.RegionCity;
                    cv.BuildingNumber = c.BuildingNumber;
                    cv.Street = c.Street;
                }
                return View(cv);
            }
            catch (Exception)
            {
                return View();

            }
        }

        // POST: CompanyController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CompanyViewModel cv)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Company c = _context.Company.Find(id);
                    if (c != null)
                    {
                        c.NameAr = cv.NameAr;
                        c.CreationDate = cv.CreationDate;
                        c.TaxAuthorityRegestrationNumber = cv.TaxAuthorityRegestrationNumber;
                        c.TaxPayerActivityCode = cv.TaxPayerActivityCode;
                        c.Phone = cv.Phone;
                        c.Email = cv.Email;
                        c.Client_ID = cv.Client_ID;
                        c.Client_Secret = cv.Client_Secret;
                        c.TokenPassword = cv.TokenPassword;
                        c.ClassType = cv.ClassType;
                        c.CountryCode = cv.CountryCode;
                        c.Governate = cv.Governate;
                        c.RegionCity = cv.RegionCity;
                        c.BuildingNumber = cv.BuildingNumber;
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

        // GET: CompanyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyController/Delete/5
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
