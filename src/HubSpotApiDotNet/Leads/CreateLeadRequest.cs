using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HubSpotApiDotNet.Leads
{
    public class CreateLeadRequest
    {
        public string IPAddress { get; private set; }
        public string UserToken { get; private set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string TwitterHandle { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string JobTitle { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public string Message { get; set; }
        public string WebSite { get; set; }
        public int? NumberEmployees { get; set; }
        public double? AnnualRevenue { get; set; }
        public DateTime? CloseDateUtc { get; set; }

        public CreateLeadRequest(string userToken, string ipAddress)
        {
            this.UserToken = userToken;
            this.IPAddress = ipAddress;

            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Email = string.Empty;
            this.TwitterHandle = string.Empty;
            this.Phone = string.Empty;
            this.Fax = string.Empty;
            this.Company = string.Empty;
            this.Address = string.Empty;
            this.JobTitle = string.Empty;
            this.City = string.Empty;
            this.State = string.Empty;
            this.ZipCode = string.Empty;
            this.Country = string.Empty;
            this.Message = string.Empty;
            this.WebSite = string.Empty;
        }

        public string ToPostData()
        {
            StringBuilder sb = new StringBuilder();

            // Required
            AddParam(sb, "IPAddress", this.IPAddress);
            AddParam(sb, "UserToken", this.UserToken);

            // Optional
            AddParam(sb, "FirstName", this.FirstName);
            AddParam(sb, "LastName", this.LastName);
            AddParam(sb, "Email", this.Email);
            AddParam(sb, "TwitterHandle", this.TwitterHandle);
            AddParam(sb, "Phone", this.Phone);
            AddParam(sb, "Fax", this.Fax);
            AddParam(sb, "Company", this.Company);
            AddParam(sb, "Address", this.Address);
            AddParam(sb, "JobTitle", this.JobTitle);
            AddParam(sb, "City", this.City);
            AddParam(sb, "State", this.State);
            AddParam(sb, "ZipCode", this.ZipCode);
            AddParam(sb, "Country", this.Country);
            AddParam(sb, "Message", this.Message);
            AddParam(sb, "WebSite", this.WebSite);

            return sb.ToString();
        }
                
        private void AddParam(StringBuilder sb, string name, string value)
        {
            string cleanValue = value.Trim();
            if (cleanValue.Length > 500) return;
            if (cleanValue == string.Empty) return;

            sb.Append("&" + HttpUtility.UrlEncode(name) + "=");
            sb.Append(HttpUtility.UrlEncode(value));
        }
    }
}
