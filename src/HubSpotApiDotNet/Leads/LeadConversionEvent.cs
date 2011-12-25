using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HubSpotApiDotNet.Leads
{
    public class LeadConversionEvent
    {
        public double ConvertDate { get; set; }
        public DateTime ConvertDateUtc
        {
            get { return Utilities.DateConverter.FromMillisecondEpoch(this.ConvertDate); }
            set { this.ConvertDate = Utilities.DateConverter.ToMillisecondEpoch(value); }
        }
        public string FormGuid { get; set; }
        public int FormId { get; set; }
        public string FormName { get; set; }
        public FormSubmissionValue[] FormSubmissionValues { get; set; }
        public string Guid { get; set; }
        public string Id { get; set; }
        public string LeadGuid { get; set; }
        public string PageName { get; set; }
        public string PageType { get; set; }
        public string PageUrl { get; set; }
        public int PortalId { get; set; }
    }
}
