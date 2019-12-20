using PaymentTransaction.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaymentTransaction.Controllers
{
    public class PaymentTransactionController : Controller
    {
        internal static string ApiPath = ConfigurationManager.AppSettings["ApiPath"];
        // GET: PaymentTransaction
        public ActionResult Index(string InfoID)
        {
            ClientInformationModel CurBus = new ClientInformationModel();
            if (!string.IsNullOrEmpty(InfoID))
            {
                Session["InfoCode"] = InfoID;
                List<ClientInformationModel> Model = new List<ClientInformationModel>();

                string urlAction = "api/MembersApplication/GetClientInfoByCode?InfoCode=" + InfoID + "";
                Model = Api_Helper.GetDataFromApi<ClientInformationModel>(ApiPath, urlAction);
                CurBus = Model.SingleOrDefault(); 
            }
         
            return View(CurBus);
        }

        public ActionResult Proceed()
        {
            string InfoID = Session["InfoCode"].ToString();
            List<ClientInformationModel> Model = new List<ClientInformationModel>();

            string urlAction = "api/MembersApplication/GetClientInfoByCode?InfoCode=" + InfoID + "";
            Model = Api_Helper.GetDataFromApi<ClientInformationModel>(ApiPath, urlAction);

            Model[0].PayStatus = "2";
            urlAction = "api/MembersApplication/UpdateClientInformation";
            var returnval = Api_Helper.SaveProduct(ApiPath, urlAction, Model.SingleOrDefault());
            ClientInformationModel CurBus = PaymentSecurity.sign(Model.SingleOrDefault());
            return View(CurBus);
        }

        public ActionResult Success(string InfoID,string PaymentCode)
        {
            //List<ClientInformationModel> Model = new List<ClientInformationModel>();
           
            //string urlAction = "api/MembersApplication/GetClientInfoByCode?InfoCode=" + InfoID + "";
            //Model = Api_Helper.GetDataFromApi<ClientInformationModel>(ApiPath, urlAction);
            //ClientInformationModel CurBus = Model.SingleOrDefault();
            List<PaymentPostingModel> PayModel = new List<PaymentPostingModel>();
            string urlAction = "api/PaymentMethods/GetPaymentByCode?PaymentCode=" + PaymentCode + "";
            PayModel = Api_Helper.GetDataFromApi<PaymentPostingModel>(ApiPath, urlAction);
            PaymentPostingModel PayBus = PayModel.SingleOrDefault();
            return View(PayBus);
        }
    }
}