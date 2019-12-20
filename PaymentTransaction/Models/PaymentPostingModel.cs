using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentTransaction.Models
{
    public class PaymentPostingModel
    {
        public string PaymentCode { get; set; }

        public string Sponsor_Code { get; set; }

        public int PaymentNo { get; set; }

        public string PaymentDate { get; set; }

        public int PaymentMethod { get; set; }

        public int BankCode { get; set; }

        public string Cheque_No { get; set; }

        public string Cheque_Date { get; set; }

        public string EncryptRequest { get; set; }

        public string EncryptResponse { get; set; }

        public string MerchantorderNo { get; set; }

        public string Currency { get; set; }

        public string PayMode { get; set; }

        public string CardType { get; set; }

        public int TransactionType { get; set; }

        public string ReferenceNumber { get; set; }

        public DateTime TrxDate { get; set; }

        public DateTime CardenrollmentResponse { get; set; }

        public string EciIndicator { get; set; }

        public string GtwTraceNo { get; set; }

        public string GtwIdentifier { get; set; }

        public string AuthoCode { get; set; }

        public string StatusFlag { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorMessage { get; set; }

        public double TotalAmount { get; set; }

        public string Remarks { get; set; }

        public DateTime FinApprovalOn { get; set; }

        public string FinApprovalBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public int AuthorizedStatus { get; set; }



        public string AuthorizedStatusName { get; set; }

        public string PaymentMethodName { get; set; }

        public string BankName { get; set; }

        public string Sponsor_ID { get; set; }

        public string SponsorName { get; set; }

        public string SponsorEmailID { get; set; }

        public string SponsorMobileNo { get; set; }


        public string ReturnMessage { get; set; }

        public string ReturnCode { get; set; }

        public string Message { get; set; }

        public string DocumentName { get; set; }

        public string RefNo { get; set; }
         
        public int IsCashAllow { get; set; }

        public int IsChequeAllow { get; set; }

        public int IsCreditCardAllow { get; set; }

        public int IsBankTransferAllow { get; set; }

        public int FilterType { get; set; }

        public string FilterCode { get; set; }

        public string BranchCode { get; set; }

        public string PaymentGuid { get; set; }

        public string First_Name { get; set; }

        public string Last_Name { get; set; }

        public string PaySource { get; set; }
    }
}