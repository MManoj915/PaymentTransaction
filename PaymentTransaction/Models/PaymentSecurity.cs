using System;
using System.Collections.Generic;
using System.Linq;
using System.Web; 
using System.Text;
using System.Security.Cryptography;

namespace PaymentTransaction.Models
{
    public static class PaymentSecurity
    {
        private const String SECRET_KEY = "4b06a0e1fd144d27b5eb370f6389bd99ceb04b1fbf4642c7bf07f772720164f69c2a65e13b08480c9859c1adf7b5178dcb1e48169dba466292bc7f9ebc3e47a99b577ed38c80454d9f6a07dd21d6695a9b5583cd2bf646a8b128be16da408a8e3c11c8ee85c94ee592ab1f11112360704d3220d351aa422faa4c70a1e4445db0";
        private const string PROFILE_ID = "94B76BA3-687C-46A9-ADB7-5FF86AC7A3D9";
        private const string ACCESS_KEY = "a5414e5b89663bb88c4bddc68fed9127";
        private const string SIGNED_FIELD_NAMES = "access_key,profile_id,transaction_uuid,bill_to_forename,bill_to_surname,bill_to_email,bill_to_phone,bill_to_address_country,signed_field_names,unsigned_field_names,signed_date_time,locale,transaction_type,reference_number,amount,currency";

        public static ClientInformationModel sign(ClientInformationModel model)
        {
            model.Access_Key = ACCESS_KEY;
            model.Profile_ID = PROFILE_ID;
            model.Signed_Field_Names = SIGNED_FIELD_NAMES;
            model.Signed_Date_Time = getUTCDateTime();
            model.Locale = "en";
            model.Signature = sign(buildDataToSign(model), SECRET_KEY);
            return model;
        }

        private static string sign(String data, String secretKey)
        {
            UTF8Encoding encoding = new System.Text.UTF8Encoding();
            byte[] keyByte = encoding.GetBytes(secretKey);

            HMACSHA256 hmacsha256 = new HMACSHA256(keyByte);
            byte[] messageBytes = encoding.GetBytes(data);
            return Convert.ToBase64String(hmacsha256.ComputeHash(messageBytes));
        }
        private static String buildDataToSign(IDictionary<string, string> paramsArray)
        {
            String[] signedFieldNames = paramsArray["signed_field_names"].Split(',');
            IList<string> dataToSign = new List<string>();

            foreach (String signedFieldName in signedFieldNames)
            {
                dataToSign.Add(signedFieldName + "=" + paramsArray[signedFieldName]);
            }
            return commaSeparate(dataToSign);
        }
        private static String buildDataToSign(ClientInformationModel model)
        {
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("access_key", model.Access_Key);
            dict.Add("profile_id", model.Profile_ID);
            dict.Add("transaction_uuid", model.TransactionUid);
            dict.Add("bill_to_forename", model.FirstName);
            dict.Add("bill_to_surname", model.LastName);
            dict.Add("bill_to_email", model.EmailId);
            dict.Add("bill_to_phone", model.MobileNo);
            dict.Add("bill_to_address_country", model.Country);
            dict.Add("signed_field_names", model.Signed_Field_Names);
            dict.Add("unsigned_field_names", model.UnSigned_Field_Names);
            dict.Add("signed_date_time", model.Signed_Date_Time);
            dict.Add("locale", model.Locale);
            dict.Add("transaction_type", model.TransactionType);
            dict.Add("reference_number", model.RefNo);
            dict.Add("amount", model.Amount.ToString());
            dict.Add("currency", model.Currency);
            return buildDataToSign(dict);
        }

        private static String commaSeparate(IList<string> dataToSign)
        {
            return String.Join(",", dataToSign);
        }

        public static String getUTCDateTime()
        {
            DateTime time = DateTime.Now.ToUniversalTime();
            return time.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
        }
    }
}