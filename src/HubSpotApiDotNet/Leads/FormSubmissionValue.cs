using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HubSpotApiDotNet.Leads
{
    public class FormSubmissionValue
    {
        public string ConversionGuid { get; set; }
        public double ConvertDate { get; set; }
        public DateTime ConvertDateUtc
        {
            get { return Utilities.DateConverter.FromMillisecondEpoch(this.ConvertDate); }
            set { this.ConvertDate = Utilities.DateConverter.ToMillisecondEpoch(value); }
        }
        public string FieldLabel { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }
        public string FormGuid { get; set; }
        public int FormId { get; set; }
        public string FormName { get; set; }
        public object Id { get; set; }
        public string LeadGuid { get; set; }
        public int PortalId { get; set; }
    }
}
