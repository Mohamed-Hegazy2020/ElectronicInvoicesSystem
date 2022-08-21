using ElectronicInvoicesSystem.Data;
using ElectronicInvoicesSystem.Models;
using ElectronicInvoicesSystem.ModelsView;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Tidal_ERP_System.Electronic_Invoice;
using Rotativa.AspNetCore;
using Microsoft.AspNetCore.Authorization;

namespace ElectronicInvoicesSystem.Controllers
{
    [Authorize]
    public class InvoiceMasterController : Controller
    {
        private readonly DatabaseContext _context;
        public InvoiceMasterController(DatabaseContext context)
        {
            _context = context;
        }
      
        public ActionResult Index()
        {
            List<InvoiceMasterViewModel> mv = new List<InvoiceMasterViewModel>();
            try
            {
                List<InvoiceMaster> m = _context.InvoiceMaster.ToList();
                mv = m.Select(x =>
                  {
                      InvoiceMasterViewModel l = new InvoiceMasterViewModel();

                      l.id = x.id;
                      l.code = x.code;
                      l.date = x.date;
                      l.invTotal = x.invTotal;
                      l.invDiscount = x.invDiscount;
                      l.invTax = x.invTax;
                      l.invNet = x.invNet;
                      l.invState = x.invState;
                      if (x.DocType == "I")
                      {
                          l.DocTypeName = "فاتورة";
                      }
                      if (x.DocType == "C")
                      {
                          l.DocTypeName = "إشعار داين";
                      }
                      if (x.DocType == "D")
                      {
                          l.DocTypeName = "إشعار مدين";
                      }
                      return l;

                  }).ToList();
                ViewBag.docType = "كل المستندات";
                return View(mv.OrderByDescending(o => o.date).Take(15));

            }
            catch (Exception)
            {
                throw;
            }

        }
      
        public ActionResult Details(int id)
        {
            try
            {
                InvoiceMasterViewModel InvoiceMaster = new InvoiceMasterViewModel();
                List<InvoiceDetailsViewModel> ddv = new List<InvoiceDetailsViewModel>();
                var invMaster = _context.InvoiceMaster.Where(x => x.id == id).FirstOrDefault();
                if (invMaster != null)
                {
                    InvoiceMaster.id = invMaster.id;
                    InvoiceMaster.code = invMaster.code;
                    InvoiceMaster.date = invMaster.date;
                    InvoiceMaster.customerId = invMaster.customerId;
                    InvoiceMaster.curuncyId = invMaster.curuncyId;
                    InvoiceMaster.invTotal = invMaster.invTotal;
                    InvoiceMaster.invDiscount = invMaster.invDiscount;
                    InvoiceMaster.invTotalAfterDiscount = invMaster.invTotalAfterDiscount;
                    InvoiceMaster.invTax = invMaster.invTax;
                    InvoiceMaster.invNet = invMaster.invNet;
                    InvoiceMaster.invState = invMaster.invState;
                    InvoiceMaster.uuid = invMaster.uuid;
                    InvoiceMaster.DocType = invMaster.DocType;
                    InvoiceMaster.customerName = InvoiceMaster.customerId != null ? _context.Customer.Where(x => x.UniqueId == InvoiceMaster.customerId).FirstOrDefault().NameAr : "";
                    InvoiceMaster.curuncyName = InvoiceMaster.curuncyId != null ? _context.Currency.Where(x => x.UniqueId == InvoiceMaster.curuncyId).FirstOrDefault().NameAr : "";
                    if (InvoiceMaster.DocType == "I")
                    {
                        InvoiceMaster.DocTypeName = "فاتورة";
                    }
                    if (InvoiceMaster.DocType == "C")
                    {
                        InvoiceMaster.DocTypeName = "إشعار داين";
                    }
                    if (InvoiceMaster.DocType == "D")
                    {
                        InvoiceMaster.DocTypeName = "إشعار مدين";
                    }

                    var dd = _context.InvoiceDetails.Where(d => d.masterId == id).ToList();
                    ddv = dd.Select(x =>
                    {
                        InvoiceDetailsViewModel l = new InvoiceDetailsViewModel();
                        l.itemName = _context.Item.Where(i => i.UniqueId == x.itemId).FirstOrDefault().NameAr;
                        l.unitName = _context.Unit.Where(i => i.UniqueId == x.unitId).FirstOrDefault().NameAr;
                        l.Qty = x.Qty;
                        l.price = x.price;
                        l.discountValue = x.discountValue;
                        l.taxValue = x.taxValue;
                        l.itemNetValue = x.itemNetValue;

                        return l;
                    }).ToList();
                    InvoiceMaster.InvoiceDetails = ddv;



                }
                return View(InvoiceMaster);

            }
            catch (Exception)
            {
                return View(new InvoiceMasterViewModel());

            }

        }
      
        public ActionResult Create()
        {

            InvoiceMasterViewModel inv = new InvoiceMasterViewModel();
            try
            {

                if (_context.InvoiceMaster.Any())
                {
                    var maxCode = _context.InvoiceMaster.Max(x => x.code);
                    inv.code = maxCode + 1;
                }
                else
                {
                    inv.code = 1;
                }
                inv.customers = _context.Customer.ToList();
                inv.Suppliers = _context.Supplier.ToList();
                inv.Currences = _context.Currency.ToList();
                inv.Items = _context.Item.ToList();
                inv.Units = _context.Unit.ToList();
                if (EInvoice_Helper._accessToken == null)
                {
                    EInvoice_Helper.FetchToken();
                }
                return View(inv);
            }
            catch (Exception)
            {

                return View(inv);
            }

        }
      
        [HttpPost]
        public JsonResult Create(InvoiceMasterViewModel invMaster, List<InvoiceDetailsViewModel> InvoiceDetailes)
        {
            try
            {
                if (invMaster != null && InvoiceDetailes.Count > 0)
                {
                    using (var t = _context.Database.BeginTransaction())
                    {
                        string msg = "";
                        string validationMsg = "";
                        validationMsg += invMaster.DocType == "C" ? ValidateSuplierForEInvoice(invMaster.customerId) : ValidateCustomerForEInvoice(invMaster.customerId);
                        validationMsg += ValidateCompanyForEInvoice();
                        validationMsg += ValidateCuruncyForEInvoice(invMaster.curuncyId);
                        if (validationMsg != "")
                        {
                            return Json(new { result = validationMsg });
                        }

                        var currencySoldCode = _context.Currency.FirstOrDefault().CuruncyTaxAuthorityCode;
                        List<EInvoiceData> documents;
                        InvoiceMaster InvoiceMaster = new InvoiceMaster();
                        InvoiceMaster.code = invMaster.code;
                        InvoiceMaster.date = invMaster.date;
                        InvoiceMaster.customerId = invMaster.customerId;
                        InvoiceMaster.curuncyId = invMaster.curuncyId;
                        InvoiceMaster.invTotal = invMaster.invTotal;
                        InvoiceMaster.invDiscount = invMaster.invDiscount;
                        InvoiceMaster.invTotalAfterDiscount = invMaster.invTotalAfterDiscount;
                        InvoiceMaster.invTax = invMaster.invTax;
                        InvoiceMaster.invNet = invMaster.invNet;
                        InvoiceMaster.invState = invMaster.invState;
                        InvoiceMaster.uuid = invMaster.uuid;
                        InvoiceMaster.DocType = invMaster.DocType;
                        _context.InvoiceMaster.Add(InvoiceMaster);
                        _context.SaveChanges();
                        documents = new List<EInvoiceData>();
                        documents = getEInvoiceData(documents, 0, InvoiceMaster.customerId, (int)InvoiceMaster.code, Convert.ToDouble(InvoiceMaster.invDiscount), Convert.ToDouble(InvoiceMaster.invTotal), Convert.ToDouble(InvoiceMaster.invTotalAfterDiscount), Convert.ToDouble(InvoiceMaster.invNet), Convert.ToDouble(InvoiceMaster.invTax), "T1", InvoiceMaster.DocType);

                        foreach (var item in InvoiceDetailes)
                        {
                            InvoiceDetails Invd = new InvoiceDetails();
                            Invd.masterId = InvoiceMaster.id;
                            Invd.itemId = item.itemId;
                            Invd.Qty = item.Qty;
                            Invd.unitId = item.unitId;
                            Invd.price = item.price;
                            Invd.itemValue = item.itemValue;
                            Invd.discountRate = item.discountRate;
                            Invd.discountValue = item.discountValue;
                            Invd.taxType = item.taxType;
                            Invd.taxRate = item.taxRate;
                            Invd.taxValue = item.taxValue;
                            Invd.itemNetValue = item.itemNetValue;
                            _context.InvoiceDetails.Add(Invd);


                            documents[0].invoiceLines.Add(new invoiceLines
                            {
                                description = _context.Item.Where(x => x.UniqueId == Invd.itemId).FirstOrDefault().NameAr,
                                itemType = _context.Item.Where(x => x.UniqueId == Invd.itemId).FirstOrDefault().ItemTaxAuthorityType,
                                itemCode = _context.Item.Where(x => x.UniqueId == Invd.itemId).FirstOrDefault().ItemTaxAuthorityCode,
                                unitType = _context.Unit.Where(c => c.UniqueId == Invd.unitId).FirstOrDefault().UnitTaxAuthorityCode,
                                quantity = (double)Invd.Qty,
                                internalCode = _context.Item.Where(x => x.UniqueId == Invd.itemId).FirstOrDefault().Code,
                                salesTotal = (double)(Invd.itemValue),
                                total = (double)(Invd.itemValue - Invd.discountValue + Invd.taxValue),
                                valueDifference = 0,
                                totalTaxableFees = 0,
                                netTotal = (double)(Invd.itemValue - Invd.discountValue),
                                itemsDiscount = 0,
                                unitValue = new unitValue { currencySold = currencySoldCode, amountEGP = (double)Invd.price, amountSold = currencySoldCode != "EGP" ? (double)Invd.price : 0, currencyExchangeRate = currencySoldCode != "EGP" ? 1 : 0 },
                                discount = new discount { rate = Invd.discountRate, amount = Invd.Qty * Invd.price * Invd.discountRate / 100 },
                                taxableItems = new List<taxableItems>() { new taxableItems() { taxType = "T1", amount = (Invd.itemValue - Invd.discountValue) * Invd.taxRate / 100, subType = "V009", rate = Invd.taxRate } },

                            });
                        }
                        Task<SubmissionDocumentResult> Result = EInvoice_Helper.sendInvoiceToApi(documents);//ارسال الفاتورة
                        if (Result != null && Result.Result.submissionId != null && Result.Result.acceptedDocuments != null && Result.Result.acceptedDocuments.Count > 0)
                        {
                            Task<DocumentDetailsResult> docState = EInvoice_Helper.GetInvoiceDetailsFromApi(Result.Result.acceptedDocuments.FirstOrDefault().uuid);//حالة الفاتورة
                            InvoiceMaster.uuid = Result.Result.acceptedDocuments.FirstOrDefault().uuid;
                            InvoiceMaster.invState = docState.Result != null ? docState.Result.status : "جاري المراجعة";
                            if (docState.Result != null)
                            {
                                
                                if (docState.Result.status== "Valid")
                                {
                                    InvoiceMaster.invState = "Valid";
                                }
                                else if (docState.Result.status == "Invalid")
                                {
                                    InvoiceMaster.invState = "Invalid";
                                }
                                else if (docState.Result.status == "Canceled")
                                {
                                    InvoiceMaster.invState = "Canceled";
                                }
                                else if (docState.Result.status == "Rejected")
                                {
                                    InvoiceMaster.invState = "Rejected";
                                }
                                else
                                {
                                   InvoiceMaster.invState = "notConfermed";
                                }


                            }
                            _context.SaveChanges();
                            t.Commit();
                            msg += "تم الارسال";


                        }
                        if (Result.Result.submissionId == null && Result.Result.rejectedDocuments != null && Result.Result.rejectedDocuments.Count > 0)
                        {
                            msg = Result.Result.rejectedDocuments.FirstOrDefault().error.message + "\n";
                            if (Result.Result.rejectedDocuments.FirstOrDefault().error.details.Count > 0)
                            {
                                foreach (var m in Result.Result.rejectedDocuments.FirstOrDefault().error.details)
                                {
                                    msg += m.message + "\n";
                                }
                            }

                        }
                        if (Result.Result.submissionId != null && Result.Result.acceptedDocuments == null && Result.Result.rejectedDocuments == null)
                        {
                            msg += Result.Result.submissionId;
                        }
                        return Json(new { result = msg });
                    }

                }
                else
                {
                    return Json(new { result = "Select Data" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { result = ex.Message });
            }
        }

        public List<EInvoiceData> getEInvoiceData(List<EInvoiceData> EInvoiceData, int branchID, int customerid, int internalID, double totalDiscountAmount, double totalSalesAmount, double netAmount, double totalAmount, double TaxAmount, string taxType, string documentType)
        {
            Customers customer = new Customers();
            var company = _context.Company.Select(a => new { a.TaxAuthorityRegestrationNumber, a.NameAr, a.CountryCode, a.Governate, a.RegionCity, a.Street, a.BuildingNumber, a.ClassType, a.TaxPayerActivityCode }).FirstOrDefault();
            //var branch = _context.Dim_Branch.AsNoTracking().Where(x => x.UniqueId == branchID).Select(a => new { a.BranchTaxAuthorityCode }).FirstOrDefault();

            if (documentType == "D")
            {
                customer = _context.Supplier.AsEnumerable().Where(x => x.UniqueId == customerid).Select(a => new Customers { NationalID = a.NationalID, NameAr = a.NameAr, CountryCode = a.CountryCode, Governate = a.Governate, RegionCity = a.RegionCity, Street = a.Street, BuildingNumber = a.BuildingNumber, ClassType = a.ClassType }).FirstOrDefault();
            }
            else
            {
                customer = _context.Customer.AsEnumerable().Where(x => x.UniqueId == customerid).Select(a => new Customers { NationalID = a.NationalID, NameAr = a.NameAr, CountryCode = a.CountryCode, Governate = a.Governate, RegionCity = a.RegionCity, Street = a.Street, BuildingNumber = a.BuildingNumber, ClassType = a.ClassType }).FirstOrDefault();
            }
            EInvoiceData.Add(new EInvoiceData()
            {
                //بيانات البائع //بيانات الشركة
                issuer = new issuer
                {
                    address = new address
                    {
                        branchID = "0",
                        country = company.CountryCode,
                        governate = company.Governate,
                        regionCity = company.RegionCity,
                        street = company.Street,
                        buildingNumber = company.BuildingNumber,
                        postalCode = "",
                        floor = "",
                        room = "",
                        landmark = "",
                        additionalInformation = ""
                    },
                    type = company.ClassType,
                    id = company.TaxAuthorityRegestrationNumber,
                    name = company.NameAr

                },
                //المشتري-العميل
                receiver = new receiver
                {
                    address = new address
                    {
                        branchID = "0",
                        country = customer.CountryCode,
                        governate = customer.Governate,
                        regionCity = customer.RegionCity,
                        street = customer.Street,
                        buildingNumber = customer.BuildingNumber,
                        postalCode = "",
                        floor = "",
                        room = "",
                        landmark = "",
                        additionalInformation = ""
                    },
                    type = customer.ClassType,
                    id = customer.NationalID,
                    name = customer.NameAr
                },
                documentType = documentType,
                documentTypeVersion = "1.0",
                dateTimeIssued = DateTime.Now.ToUniversalTime().ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'"),
                taxpayerActivityCode = company.TaxPayerActivityCode,
                internalID = internalID.ToString(),
                purchaseOrderReference = "",
                purchaseOrderDescription = "",
                salesOrderReference = "",
                salesOrderDescription = "",
                proformaInvoiceNumber = "",

                totalDiscountAmount = totalDiscountAmount,
                totalSalesAmount = totalSalesAmount,
                netAmount = netAmount,
                totalAmount = totalAmount,
                extraDiscountAmount = 0,
                totalItemsDiscountAmount = 0,
                invoiceLines = new List<invoiceLines>(),
                taxTotals = new List<taxTotals>(){new taxTotals{ taxType = taxType, amount=(decimal)TaxAmount}
                }
            });


            return EInvoiceData;
        }

        public string ValidateCustomerForEInvoice(int cid)
        {
            string msg = "";
            var c = _context.Customer.Where(x => x.UniqueId == cid).FirstOrDefault();
            if (c != null)
            {
                if (c.NationalID == null || c.NationalID == "")
                {
                    msg += "يجب ادخال الرقم القومي للعميل \n";
                }
                if (c.CountryCode == null || c.CountryCode == "")
                {
                    msg += "يجب ادخال الدولة للعميل \n";
                }
                if (c.Governate == null || c.Governate == "")
                {
                    msg += "يجب ادخال المحافظة \n";
                }
                if (c.RegionCity == null || c.RegionCity == "")
                {
                    msg += "يجب ادخال المنطقة \n";
                }
                if (c.Street == null || c.Street == "")
                {
                    msg += "يجب ادخال الشارع \n";
                }
                if (c.BuildingNumber == null || c.BuildingNumber == "")
                {
                    msg += "يجب ادخال رقم المبني";
                }

            }
            else
            {
                msg = "يجب اختيار عميل";
            }

            return msg;


        }

        public string ValidateSuplierForEInvoice(int cid)
        {
            string msg = "";
            var c = _context.Supplier.Where(x => x.UniqueId == cid).FirstOrDefault();
            if (c != null)
            {
                if (c.NationalID == null || c.NationalID == "")
                {
                    msg += "يجب ادخال الرقم القومي للمورد \n";
                }
                if (c.CountryCode == null || c.CountryCode == "")
                {
                    msg += "يجب ادخال الدولة للمورد \n";
                }
                if (c.Governate == null || c.Governate == "")
                {
                    msg += "يجب ادخال المحافظة \n";
                }
                if (c.RegionCity == null || c.RegionCity == "")
                {
                    msg += "يجب ادخال المنطقة \n";
                }
                if (c.Street == null || c.Street == "")
                {
                    msg += "يجب ادخال الشارع \n";
                }
                if (c.BuildingNumber == null || c.BuildingNumber == "")
                {
                    msg += "يجب ادخال رقم المبني";
                }

            }
            else
            {
                msg = "يجب اختيار للمورد";
            }

            return msg;


        }

        public string ValidateCompanyForEInvoice()
        {
            string msg = "";
            var c = _context.Company.FirstOrDefault();
            if (c != null)
            {
                if (c.TaxAuthorityRegestrationNumber == null || c.TaxAuthorityRegestrationNumber == "")
                {
                    msg += "يجب ادخال رقم تسجيل الشركة \n";
                }
                if (c.TaxPayerActivityCode == null || c.TaxPayerActivityCode == "")
                {
                    msg += "يجب ادخال رقم نشاط الشركة \n";
                }
                if (c.Governate == null || c.Governate == "")
                {
                    msg += "يجب ادخال المحافظة \n";
                }
                if (c.RegionCity == null || c.RegionCity == "")
                {
                    msg += "يجب ادخال المنطقة \n";
                }
                if (c.Street == null || c.Street == "")
                {
                    msg += "يجب ادخال الشارع \n";
                }
                if (c.BuildingNumber == null || c.BuildingNumber == "")
                {
                    msg += "يجب ادخال رقم المبني";
                }

            }
            else
            {
                msg = "يجب ادخال بيانات الشركة";
            }

            return msg;


        }

        public string ValidateCuruncyForEInvoice(int cid)
        {
            string msg = "";
            var c = _context.Currency.Where(x => x.UniqueId == cid).FirstOrDefault();
            if (c != null)
            {
                if (c.CuruncyTaxAuthorityCode == null || c.CuruncyTaxAuthorityCode == "")
                {
                    msg += "يجب ادخال كود العملة العالمي لمصلحة الضرائب \n";
                }
            }
            else
            {
                msg = "يجب اختيار العملة";
            }

            return msg;


        }


        public ActionResult Refresh(int id)
        {
            string invState = "";
            try
            {
                var inv = _context.InvoiceMaster.Where(x => x.id == id).FirstOrDefault();
                if (inv != null && inv.uuid != null && inv.uuid != "")
                {
                    Task<DocumentDetailsResult> docState = EInvoice_Helper.GetInvoiceDetailsFromApi(inv.uuid);//حالة الفاتورة                   
                    inv.invState = docState.Result != null ? docState.Result.status : "جاري المراجعة";
                    _context.SaveChanges();
                    invState = inv.invState;
                }
                return RedirectToAction(nameof(Index), inv);
                
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));
              
            }

        }

        public ActionResult CancelDocument(int id)
        {           
            try
            {
                var inv = _context.InvoiceMaster.Where(x => x.id == id).FirstOrDefault();
                if (inv != null && inv.uuid != null && inv.uuid != "")
                {
                    Task<bool> docState = EInvoice_Helper.CancelInvoiceToApi(inv.uuid,"بيانات خاطئة");//إلغاء مستند
                    if (EInvoice_Helper.CancelInvoiceToApi(inv.uuid, "بيانات خاطئة").Result)
                    {
                        inv.invState = "ملغي";
                        _context.SaveChanges();                      
                    }                                                                            

                   
                }
                return RedirectToAction(nameof(Index));              
            }
            catch (Exception)
            {
                return RedirectToAction(nameof(Index));                
            }

        }
     
        public ActionResult Edit(int id)
        {
            return View();
        }
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
       
        public ActionResult Delete(int id)
        {
            return View();
        }
      
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

        [HttpPost]
        public JsonResult getMax()
        {
            try
            {
                int num = 0;
                if (_context.InvoiceMaster.Any())
                {
                    var maxCode = _context.InvoiceMaster.Max(x => x.code);
                    num = maxCode + 1;
                }
                else
                {
                    num = 1;
                }
                return Json(new { result = num });
            }
            catch (Exception)
            {
                return Json(new { result = 0 });

            }


        }

        public ActionResult getCustomersOrSupplers(string docType)
        {
            if (docType == "D")
            {
                return Json(_context.Supplier.Select(x => new 
                {
                    UniqueId= x.UniqueId,
                    NameAr = x.NameAr
                }).ToList());

            }
            else
            {
                return Json(_context.Customer.Select(x => new 
                {
                    UniqueId = x.UniqueId,
                    NameAr = x.NameAr
                }).ToList());

            }

        } 
        
        public ActionResult getDocumentByCode(int docCode)
        {
            if (docCode > 0)
            {
                var m = _context.InvoiceMaster.Where(x => x.code == docCode).ToList();
                List<InvoiceMasterViewModel> mv = new List<InvoiceMasterViewModel>();
                mv = m.Select(x =>
                {
                    InvoiceMasterViewModel l = new InvoiceMasterViewModel();

                    l.id = x.id;
                    l.code = x.code;
                    l.date = x.date;
                    l.invTotal = x.invTotal;
                    l.invDiscount = x.invDiscount;
                    l.invTax = x.invTax;
                    l.invNet = x.invNet;
                    l.invState = x.invState;
                    if (x.DocType == "I")
                    {
                        l.DocTypeName = "فاتورة";
                    }
                    if (x.DocType == "C")
                    {
                        l.DocTypeName = "إشعار داين";
                    }
                    if (x.DocType == "D")
                    {
                        l.DocTypeName = "إشعار مدين";
                    }
                    return l;

                }).ToList();
                return Json(mv.OrderByDescending(o => o.date));

            }
            else if (docCode == 0)
            {
                var m = _context.InvoiceMaster.ToList();
                List<InvoiceMasterViewModel> mv = new List<InvoiceMasterViewModel>();
                mv = m.Select(x =>
                {
                    InvoiceMasterViewModel l = new InvoiceMasterViewModel();

                    l.id = x.id;
                    l.code = x.code;
                    l.date = x.date;
                    l.invTotal = x.invTotal;
                    l.invDiscount = x.invDiscount;
                    l.invTax = x.invTax;
                    l.invNet = x.invNet;
                    l.invState = x.invState;
                    if (x.DocType == "I")
                    {
                        l.DocTypeName = "فاتورة";
                    }
                    if (x.DocType == "C")
                    {
                        l.DocTypeName = "إشعار داين";
                    }
                    if (x.DocType == "D")
                    {
                        l.DocTypeName = "إشعار مدين";
                    }
                    return l;

                }).ToList();
                return Json(mv.OrderByDescending(o => o.date).Take(15));
            }
            else
            {
                return Json(new InvoiceMasterViewModel());

            }

        }

        [HttpGet]
        public ActionResult getDocumentByType(string docType)
        {
            ViewBag.docType = "";
            if (!string.IsNullOrWhiteSpace(docType) && docType!="a")
            {               
                var m = _context.InvoiceMaster.Where(x => x.DocType == docType).ToList();
                List<InvoiceMasterViewModel> mv = new List<InvoiceMasterViewModel>();
                mv = m.Select(x =>
                {
                    InvoiceMasterViewModel l = new InvoiceMasterViewModel();

                    l.id = x.id;
                    l.code = x.code;
                    l.date = x.date;
                    l.invTotal = x.invTotal;
                    l.invDiscount = x.invDiscount;
                    l.invTax = x.invTax;
                    l.invNet = x.invNet;
                    l.invState = x.invState;
                    if (x.DocType == "I")
                    {
                        l.DocTypeName = "فاتورة";

                    }
                    if (x.DocType == "C")
                    {
                        l.DocTypeName = "إشعار داين";
                    }
                    if (x.DocType == "D")
                    {
                        l.DocTypeName = "إشعار مدين";
                    }
                    return l;

                }).ToList();
                ViewBag.docType =" مستندات  " + mv.FirstOrDefault().DocTypeName;
                return View("Index", mv.OrderByDescending(o => o.date));              

            }
            else if (!string.IsNullOrWhiteSpace(docType) && docType == "a")
            {
                ViewBag.docType = "كل المستندات";
                var m = _context.InvoiceMaster.ToList();
                List<InvoiceMasterViewModel> mv = new List<InvoiceMasterViewModel>();
                mv = m.Select(x =>
                {
                    InvoiceMasterViewModel l = new InvoiceMasterViewModel();

                    l.id = x.id;
                    l.code = x.code;
                    l.date = x.date;
                    l.invTotal = x.invTotal;
                    l.invDiscount = x.invDiscount;
                    l.invTax = x.invTax;
                    l.invNet = x.invNet;
                    l.invState = x.invState;
                    if (x.DocType == "I")
                    {
                        l.DocTypeName = "فاتورة";
                    }
                    if (x.DocType == "C")
                    {
                        l.DocTypeName = "إشعار داين";
                    }
                    if (x.DocType == "D")
                    {
                        l.DocTypeName = "إشعار مدين";
                    }
                    return l;

                }).ToList();
                return View("Index", mv.OrderByDescending(o => o.date));
              
            }
            else
            {
                return NotFound();

            }

        }

        public ActionResult PrintPdf<T>(int id,T data,string viewName)
        {
            var report = new ViewAsPdf(viewName, data)
            {
                PageMargins = { Left = 5, Bottom = 5, Right = 5, Top = 5 },
                //FileName = "Document_" + DateTime.Now + ".pdf",
                PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                PageSize = Rotativa.AspNetCore.Options.Size.A4,
                IsGrayScale = true,
               



            };
            return report;

        }

        public ActionResult PrintViewToPdf(int id)
        {
            try
            {
                InvoiceMasterViewModel InvoiceMaster = new InvoiceMasterViewModel();
                List<InvoiceDetailsViewModel> ddv = new List<InvoiceDetailsViewModel>();
                var invMaster = _context.InvoiceMaster.Where(x => x.id == id).FirstOrDefault();
                if (invMaster != null)
                {
                    InvoiceMaster.id = invMaster.id;
                    InvoiceMaster.code = invMaster.code;
                    InvoiceMaster.date = invMaster.date;
                    InvoiceMaster.customerId = invMaster.customerId;
                    InvoiceMaster.curuncyId = invMaster.curuncyId;
                    InvoiceMaster.invTotal = invMaster.invTotal;
                    InvoiceMaster.invDiscount = invMaster.invDiscount;
                    InvoiceMaster.invTotalAfterDiscount = invMaster.invTotalAfterDiscount;
                    InvoiceMaster.invTax = invMaster.invTax;
                    InvoiceMaster.invNet = invMaster.invNet;
                    InvoiceMaster.invState = invMaster.invState;
                    InvoiceMaster.uuid = invMaster.uuid;
                    InvoiceMaster.DocType = invMaster.DocType;
                    InvoiceMaster.customerName = InvoiceMaster.customerId != null ? _context.Customer.Where(x => x.UniqueId == InvoiceMaster.customerId).FirstOrDefault().NameAr : "";
                    InvoiceMaster.curuncyName = InvoiceMaster.curuncyId != null ? _context.Currency.Where(x => x.UniqueId == InvoiceMaster.curuncyId).FirstOrDefault().NameAr : "";
                    InvoiceMaster.companyName = _context.Company.FirstOrDefault().NameAr;

                    if (InvoiceMaster.DocType == "I")
                    {
                        InvoiceMaster.DocTypeName = "فاتورة";
                    }
                    if (InvoiceMaster.DocType == "C")
                    {
                        InvoiceMaster.DocTypeName = "إشعار داين";
                    }
                    if (InvoiceMaster.DocType == "D")
                    {
                        InvoiceMaster.DocTypeName = "إشعار مدين";
                    }

                    var dd = _context.InvoiceDetails.Where(d => d.masterId == id).ToList();
                    ddv = dd.Select(x =>
                    {
                        InvoiceDetailsViewModel l = new InvoiceDetailsViewModel();
                        l.itemName = _context.Item.Where(i => i.UniqueId == x.itemId).FirstOrDefault().NameAr;
                        l.unitName = _context.Unit.Where(i => i.UniqueId == x.unitId).FirstOrDefault().NameAr;
                        l.Qty = x.Qty;
                        l.price = x.price;
                        l.discountValue = x.discountValue;
                        l.taxValue = x.taxValue;
                        l.itemNetValue = x.itemNetValue;

                        return l;
                    }).ToList();
                    InvoiceMaster.InvoiceDetails = ddv;
                }            
                //var report = new  ViewAsPdf("DocumentViewPdf", InvoiceMaster)
                //{
                //    PageMargins = { Left = 10, Bottom = 10, Right = 10, Top = 10 },
                //    FileName = "Document_" + invMaster.code + ".pdf",
                //    PageOrientation = Rotativa.AspNetCore.Options.Orientation.Landscape,
                //    PageSize = Rotativa.AspNetCore.Options.Size.A4,
                     

                //};
                return PrintPdf(id, InvoiceMaster, "DocumentViewPdf");

            }
            catch (Exception)
            {
                return View(new InvoiceMasterViewModel());

            }
         
        }

        [HttpGet]
        public ActionResult DocumentsRpt()
        {
            DocumentsMasterRpt inv = new DocumentsMasterRpt();
            try
            {               
                inv.customers = _context.Customer.ToList();
                inv.customers.Insert(0,new Customers() {UniqueId=0,NameAr="الكل" });
                return View(inv);
            }
            catch (Exception)
            {
                return View(inv);
            }
          
        }

        public ActionResult DocumentsRpt(int code, DateTime fdate, DateTime tdate, int customerId, string DocType, string DocState)
        {
            try
            {
                List <DocumentsMasterRpt> ds = new List<DocumentsMasterRpt>();
                //List<InvoiceDetailsViewModel> ddv = new List<InvoiceDetailsViewModel>();
                var invMaster = _context.InvoiceMaster.Where(x => x.date >=fdate && x.date<=tdate).ToList();
                if (code>0)
                {
                    invMaster = invMaster.Where(x=>x.code==code).ToList();
                }
                if (customerId > 0)
                {
                    invMaster = invMaster.Where(x => x.customerId == customerId).ToList();
                }
                if (DocType != "a")
                {
                    invMaster = invMaster.Where(x => x.DocType == DocType).ToList();
                }
                if (DocState !="a")
                {
                    invMaster = invMaster.Where(x => x.invState == DocState).ToList();
                }

                if (invMaster != null)
                {              

                    ds= invMaster.Select(d =>
                    {
                        DocumentsMasterRpt l = new DocumentsMasterRpt();
                        l.code = d.code;
                        l.docDate = d.date;
                        l.companyName = _context.Company.FirstOrDefault().NameAr;
                        l.customerName = d.customerId != null ? _context.Customer.Where(x => x.UniqueId == d.customerId).FirstOrDefault().NameAr : "";
                        l.curuncyName = d.curuncyId != null ? _context.Currency.Where(x => x.UniqueId == d.curuncyId).FirstOrDefault().NameAr : "";
                        l.invTotal = d.invTotal;
                        l.invDiscount = d.invDiscount;
                        l.invTax = d.invTax;
                        l.invNet = d.invNet;
                        if (d.DocType=="I")
                        {
                            l.DocTypeName = "فاتورة";
                        }
                        if (d.DocType == "C")
                        {
                            l.DocTypeName = "إشعار دائن";
                        }
                        if (d.DocType == "D")
                        {
                            l.DocTypeName = "إشعار مدين";
                        }

                        if (d.invState == "Valid")
                        {
                            l.DocStateName = "صالح";
                        }
                        if (d.invState == "Invalid")
                        {
                            l.DocStateName = "غير صالح";
                        }
                        if (d.invState == "Canceled")
                        {
                            l.DocStateName = "ملغي";
                        } 
                        if (d.invState == "notConfermed")
                        {
                            l.DocStateName = "لم يحدد بعد";
                        }                

                        return l;
                    }).ToList();


                }
                return Json(ds);

            }
            catch (Exception)
            {
                return Json("");

            }

        }

        public ActionResult DocumentsRptPrint(DocumentsMasterRpt r)
        {
            try
            {
                List<DocumentsMasterRpt> ds = new List<DocumentsMasterRpt>();              
                var invMaster = _context.InvoiceMaster.Where(x => x.date >= r.fDate && x.date <= r.tDate).ToList();
              
                if (r.code > 0)
                {
                    invMaster = invMaster.Where(x => x.code == r.code).ToList();
                }
                if (r.customerId > 0)
                {
                    invMaster = invMaster.Where(x => x.customerId == r.customerId).ToList();
                }
                if (r.DocType != "a")
                {
                    invMaster = invMaster.Where(x => x.DocType == r.DocType).ToList();
                }
                if (r.DocState != "a")
                {
                    invMaster = invMaster.Where(x => x.invState == r.DocState).ToList();
                }

                if (invMaster != null)
                {
                    
                    string customerNameFilter = "";                   
                    string codeFilter = r.code>0? r.code.ToString():"الكل";
                    string DocTypeNameFilter = "";
                    string DocStateNameFilter = "";
                    if (r.customerId > 0)
                    {
                         customerNameFilter = _context.Customer.Where(x => x.UniqueId == r.customerId).FirstOrDefault() != null ? _context.Customer.Where(x => x.UniqueId == r.customerId).FirstOrDefault().NameAr : "";
                        
                    }
                    else
                    {
                        customerNameFilter = "الكل";
                    }
                    if (r.DocType == "a")
                    {
                        DocTypeNameFilter = "الكل";
                    }
                    if (r.DocType == "I")
                    {
                        DocTypeNameFilter = "فاتورة";
                    }
                    if (r.DocType == "C")
                    {
                        DocTypeNameFilter = "إشعار دائن";
                    }
                    if (r.DocType == "D")
                    {
                        DocTypeNameFilter = "إشعار مدين";
                    }

                    if (r.DocState == "a")
                    {
                        DocStateNameFilter = "الكل";
                    }
                    if (r.DocState == "Valid")
                    {
                        DocStateNameFilter = "صالح";
                    }
                    if (r.DocState == "Invalid")
                    {
                        DocStateNameFilter = "غير صالح";
                    }
                    if (r.DocState == "Canceled")
                    {
                        DocStateNameFilter = "ملغي";
                    }
                    if (r.DocState == "notConfermed")
                    {
                        DocStateNameFilter = "لم يحدد بعد";
                    }


                    ds = invMaster.Select(d =>
                    {
                        DocumentsMasterRpt l = new DocumentsMasterRpt();

                        l.code = d.code;
                        l.docDate = d.date;
                        l.companyName = _context.Company.FirstOrDefault().NameAr;
                        l.customerName = d.customerId != null ? _context.Customer.Where(x => x.UniqueId == d.customerId).FirstOrDefault().NameAr : "";
                        l.curuncyName = d.curuncyId != null ? _context.Currency.Where(x => x.UniqueId == d.curuncyId).FirstOrDefault().NameAr : "";
                        l.invTotal = d.invTotal;
                        l.invDiscount = d.invDiscount;
                        l.invTax = d.invTax;
                        l.invNet = d.invNet;
                        l.fDate = r.fDate;
                        l.tDate = r.tDate;
                        l.codeFilter = codeFilter;
                        l.customerNameFilter = customerNameFilter;
                        l.DocStateNameFilter = DocStateNameFilter;
                        l.DocTypeNameFilter = DocTypeNameFilter;

                        if (d.DocType == "I")
                        {
                            l.DocTypeName = "فاتورة";
                        }
                        if (d.DocType == "C")
                        {
                            l.DocTypeName = "إشعار دائن";
                        }
                        if (d.DocType == "D")
                        {
                            l.DocTypeName = "إشعار مدين";
                        }

                        if (d.invState == "Valid")
                        {
                            l.DocStateName = "صالح";
                        }
                        if (d.invState == "Invalid")
                        {
                            l.DocStateName = "غير صالح";
                        }
                        if (d.invState == "Canceled")
                        {
                            l.DocStateName = "ملغي";
                        }
                        if (d.invState == "notConfermed")
                        {
                            l.DocStateName = "لم يحدد بعد";
                        }

                        return l;
                    }).ToList();

                   
                }
             
                return PrintPdf(0, ds, "DocumentsRptPrint");

            }
            catch (Exception)
            {
                return Json("");

            }

        }


    }
}
