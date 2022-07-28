using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using ElectronicInvoicesSystem.Data;
using ElectronicInvoicesSystem.Models;

namespace Tidal_ERP_System.Electronic_Invoice
{
    public class EInvoice_Helper
    {
        public static AccessTokenClass _accessToken;
        public static string _clientId;
        public static string _clientSecret;
        public static HttpClient _SystemAPIHttpClient = new HttpClient();
        public static HttpClient _IdentityServiceHttpClient = new HttpClient();
        public EInvoice_Helper()
        {                     
        }
        public static async void FetchToken()
        {
            try
            {
                using (_IdentityServiceHttpClient = new HttpClient())
                {
                    _IdentityServiceHttpClient.BaseAddress = new Uri("https://id.preprod.eta.gov.eg");
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    _IdentityServiceHttpClient.DefaultRequestHeaders.Clear();

                    var credentials = new List<KeyValuePair<string, string>>();
                    credentials.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                    credentials.Add(new KeyValuePair<string, string>("client_id", "b93c6a18-8233-432a-a81e-b9984531799f"));
                    credentials.Add(new KeyValuePair<string, string>("client_secret", "60877c9f-a821-4662-92c3-5565f8479547"));

                    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/connect/token");
                    var content = new FormUrlEncodedContent(credentials);
                    requestMessage.Content = content;

                    requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/x-www-form-urlencoded");

                    using (var response = await _IdentityServiceHttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false))
                    {                      
                        string responseBody = await response.Content.ReadAsStringAsync();
                        AccessTokenClass accessToken = JsonConvert.DeserializeObject<AccessTokenClass>(responseBody);
                        _accessToken = accessToken;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public async static Task<SubmissionDocumentResult> sendInvoiceToApi(List<EInvoiceData> documents)
        {
            try
            {
                using (_SystemAPIHttpClient = new HttpClient())
                {
                    Signer s=new Signer();
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;                  
                    _SystemAPIHttpClient.BaseAddress = new Uri("https://api.preprod.invoicing.eta.gov.eg");
                    _SystemAPIHttpClient.DefaultRequestHeaders.Accept.Clear();
                    _SystemAPIHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    _SystemAPIHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken.access_token != null ? _accessToken.access_token : "");
                    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/v1.0/documentsubmissions");

                    var JsonInvoice = JsonConvert.SerializeObject(documents.FirstOrDefault());//convert document to json

                    var signedInvoice = s.SignInvoice(JsonInvoice);//sign document
                    SubmissionDocumentResult result = new SubmissionDocumentResult();
                    if (signedInvoice==string.Empty)
                    {
                        result.submissionId = "! حدث خطأ أثناء توقيع الفاتورة"+"\nتأكد من توصيل توكن التوقيع بالجهاز\nوكلمة المرور صحيحة \n";

                    }
                    else
                    {
                        var content = new System.Net.Http.StringContent(signedInvoice, Encoding.UTF8, "application/json");
                        requestMessage.Content = content;
                        requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                        var response = await _SystemAPIHttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);// send document                                            
                        if (response.IsSuccessStatusCode)
                        { 
                            var responseVal = response.Content.ReadAsStringAsync();                           
                            result = JsonConvert.DeserializeObject<SubmissionDocumentResult>(responseVal.Result);
                        }
                        else
                        {
                            result.submissionId = response.StatusCode.ToString();    
                        }

                    }                      
                    return result;
                }

            }
            catch (Exception ex)
            {
                return new SubmissionDocumentResult();
            }
        }

        public async static Task<bool> CancelInvoiceToApi(string documentUUID,string reson)
        {
            try
            {
                using (_SystemAPIHttpClient = new HttpClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    _SystemAPIHttpClient.BaseAddress = new Uri("https://api.preprod.invoicing.eta.gov.eg");
                    _SystemAPIHttpClient.DefaultRequestHeaders.Accept.Clear();
                    _SystemAPIHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    _SystemAPIHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken.access_token != null ? _accessToken.access_token : "");

                    var stringjsonData = @"{'status': 'cancelled', 'reason':'"+ reson +"'}";
                    var requestMessage = new HttpRequestMessage(HttpMethod.Put, "/api/v1.0/documents/state/" + documentUUID + "/state");//9SDEAZRZ8MCCVPK55NYP4Y5G10/state

                    var content = new System.Net.Http.StringContent(stringjsonData, Encoding.UTF8, "application/json");
                    requestMessage.Content = content;
                    requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                    var response = await _SystemAPIHttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
                    return response.IsSuccessStatusCode ? true : false;          

                }

            }
            catch (Exception ex)
            {              
                return false;
            }
        }

        public async static Task<DocumentDetailsResult> GetInvoiceDetailsFromApi(string documentUUID)
        {
            try
            {
                using (_SystemAPIHttpClient = new HttpClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    _SystemAPIHttpClient.BaseAddress = new Uri("https://api.preprod.invoicing.eta.gov.eg");
                    _SystemAPIHttpClient.DefaultRequestHeaders.Accept.Clear();
                    _SystemAPIHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    _SystemAPIHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken.access_token != null ? _accessToken.access_token : "");
                    DocumentDetailsResult result = new DocumentDetailsResult();
                    var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/api/v1.0/documents/" + documentUUID + "/details");
                    var response = await _SystemAPIHttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false); 
                    if (response.IsSuccessStatusCode)
                    {
                        var responseVal = response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<DocumentDetailsResult>(responseVal.Result);
                    }              
                    return result;
                }

            }
            catch (Exception ex)
            {               
                return null;
            }
        }

        public static List<EInvoiceData> getEInvoiceData(List<EInvoiceData> EInvoiceData, int branchID, int customerid, int internalID, double totalDiscountAmount, double totalSalesAmount, double netAmount, double totalAmount, double TaxAmount, string taxType, string documentType, DatabaseContext context)
        {
            Customers customer = new Customers();
            var company = context.Company.Select(a => new { a.TaxAuthorityRegestrationNumber, a.NameAr, a.CountryCode, a.Governate, a.RegionCity, a.Street, a.BuildingNumber, a.ClassType ,a.TaxPayerActivityCode}).FirstOrDefault();
            //var branch = context.Dim_Branch.AsNoTracking().Where(x => x.UniqueId == branchID).Select(a => new { a.BranchTaxAuthorityCode }).FirstOrDefault();
        
            if (documentType=="D")
            {
                customer = context.Supplier.AsEnumerable().Where(x => x.UniqueId == customerid).Select(a => new Customers { NationalID=a.NationalID,NameAr =a.NameAr,CountryCode =a.CountryCode, Governate=a.Governate, RegionCity=a.RegionCity, Street=a.Street, BuildingNumber=a.BuildingNumber,ClassType= a.ClassType }).FirstOrDefault();
            }
            else
            {
                customer = context.Customer.AsEnumerable().Where(x => x.UniqueId == customerid).Select(a => new Customers { NationalID = a.NationalID, NameAr = a.NameAr, CountryCode = a.CountryCode, Governate = a.Governate, RegionCity = a.RegionCity, Street = a.Street, BuildingNumber = a.BuildingNumber, ClassType = a.ClassType }).FirstOrDefault();
            }
            EInvoiceData.Add(new EInvoiceData()
            {
                //بيانات البائع //بيانات الشركة
                issuer = new issuer
                {
                    address = new address
                    {
                        branchID = "01",
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


        public async static Task<bool> GenerateEGSCode(itemCode itm)
        {
            try
            {
                using (_SystemAPIHttpClient = new HttpClient())
                {                   
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    _SystemAPIHttpClient.BaseAddress = new Uri("https://api.preprod.invoicing.eta.gov.eg");
                    _SystemAPIHttpClient.DefaultRequestHeaders.Accept.Clear();
                    _SystemAPIHttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    _SystemAPIHttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken.access_token != null ? _accessToken.access_token : "");
                    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/v1.0/codetypes/requests/codes");

                    var items = JsonConvert.SerializeObject(itm);//convert document to json                   
                    SubmissionDocumentResult result = new SubmissionDocumentResult();
                    var content = new System.Net.Http.StringContent(items, Encoding.UTF8, "application/json");
                    requestMessage.Content = content;
                    requestMessage.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var response = await _SystemAPIHttpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);//send document   

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                   
                }

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
