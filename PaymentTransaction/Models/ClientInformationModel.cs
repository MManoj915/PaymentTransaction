using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PaymentTransaction.Models
{
    public class ClientInformationModel
    {
        public string InfoCode { get; set; }

        public string Sponsor_Code { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailId { get; set; }

        public string MobileNo { get; set; }

        public string Country { get; set; }

        public string TransactionType { get; set; }

        public string RefNo { get; set; }

        public string TransactionUid { get; set; }

        public DateTime RequestDate { get; set; }

        public double Amount { get; set; }

        public string Currency { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public string PaymentGuid { get; set; }

        public List<ClientInformationDtlModel> ApplicationList { get; set; }

        public string Message { get; set; }

        public string Access_Key { get; set; }

        public string Profile_ID { get; set; }

        public string Signed_Field_Names { get; set; }

        public string UnSigned_Field_Names { get; set; }

        public string Signed_Date_Time { get; set; }

        public string Locale { get; set; }

        public string Signature { get; set; }

        public string PayStatus { get; set; }
        public string PayUrl { get; set; }

        public long TimeDifference { get; set; }

    }
}



