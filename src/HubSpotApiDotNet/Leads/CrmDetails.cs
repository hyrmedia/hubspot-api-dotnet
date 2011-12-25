using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HubSpotApiDotNet.Leads
{
    public class CrmDetails
    {
        public int AnnualRevenue { get; set; }
        public int CloseProbability { get; set; }
        public int CrmType { get; set; }
        public int EstimatedRevenue { get; set; }
        public string Id { get; set; }
        public string NextAction { get; set; }
        public int NextActionAssignedTo { get; set; }
        public string NextActionAssignedToEmail { get; set; }
        public int NextActionDue { get; set; }
        public int NumEmployees { get; set; }
        public string Status { get; set; }
    }
}
