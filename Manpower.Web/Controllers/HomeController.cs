using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Manpower.Web.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
        //upload certificates
        [HttpPost]
        public JsonResult UploadCertificate()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                fileName = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/applicant_certificate"), fileName));
                    //Message = "File uploaded";
                    flag = true;
                }
                catch (Exception)
                {
                    //Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = "", Status = flag } };
        }

        //image upload for Applicant
        [HttpPost]
        public JsonResult UploadApplicantImage()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                fileName = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/applicant_image"), fileName));
                    //Message = "File uploaded";
                    flag = true;
                }
                catch (Exception)
                {
                    //Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = "", Status = flag } };
        }

        [HttpPost]
        public JsonResult UploadClientCertificate()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                fileName = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/client_certificate"), fileName));
                    //Message = "File uploaded";
                    flag = true;
                }
                catch (Exception)
                {
                    //Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = "", Status = flag } };
        }
        [HttpPost]
        public JsonResult UploadPostCertificate()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                fileName = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/post_approval_certificate"), fileName));
                    //Message = "File uploaded";
                    flag = true;
                }
                catch (Exception)
                {
                    //Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = "", Status = flag } };
        }
        [HttpPost]
        public JsonResult UploadSales()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                fileName = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/sales_bill"), fileName));
                    //Message = "File uploaded";
                    flag = true;
                }
                catch (Exception)
                {
                    //Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = "", Status = flag } };
        }

        [HttpPost]
        public JsonResult UploadPurchase()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                fileName = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/purchase_bill"), fileName));
                    //Message = "File uploaded";
                    flag = true;
                }
                catch (Exception)
                {
                    //Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = "", Status = flag } };
        }

        [HttpPost]
        public JsonResult UploadExpense()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                fileName = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/expense_bill"), fileName));
                    //Message = "File uploaded";
                    flag = true;
                }
                catch (Exception)
                {
                    //Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = "", Status = flag } };
        }

        [HttpPost]
        public JsonResult UploadReceipt()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                fileName = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/receipt_bill"), fileName));
                    //Message = "File uploaded";
                    flag = true;
                }
                catch (Exception)
                {
                    //Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = "", Status = flag } };
        }

        [HttpPost]
        public JsonResult UploadPayment()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                fileName = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/payment_bill"), fileName));
                    //Message = "File uploaded";
                    flag = true;
                }
                catch (Exception)
                {
                    //Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = "", Status = flag } };
        }

        [HttpPost]
        public JsonResult UploadBill()
        {
            string Message, fileName;
            Message = fileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                fileName = file.FileName;
                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/post_bill"), fileName));
                    //Message = "File uploaded";
                    flag = true;
                }
                catch (Exception)
                {
                    //Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = "", Status = flag } };
        }

        ////passport upload for Applicant
        //[HttpPost]
        //public JsonResult UploadPassport()
        //{
        //    string Message, fileName;
        //    Message = fileName = string.Empty;
        //    bool flag = false;
        //    if (Request.Files != null)
        //    {
        //        var file = Request.Files[0];
        //        fileName = file.FileName;
        //        try
        //        {
        //            file.SaveAs(Path.Combine(Server.MapPath("~/Content/images/applicant_passport"), fileName));
        //            //Message = "File uploaded";
        //            flag = true;
        //        }
        //        catch (Exception)
        //        {
        //            //Message = "File upload failed! Please try again";
        //        }

        //    }
        //    return new JsonResult { Data = new { Message = "", Status = flag } };
        //}

        //image upload for Applicant       

    }
}