using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace HubSpotApiDotNet.Leads
{
    public enum TimePivot
    {
        NotSet = 0,
        InsertedAt = 1,
        FirstConvertedAt = 2,
        LastConvertedAt = 3,
        LastModifiedAt = 4,
        ClosedAt = 5
    }

    public class SearchCriteria
    {
        public string Keyword { get; set; }
        public string SortField { get; set; }
        public SortDirection Direction { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime StopDateUtc { get; set; }
        public TimePivot StartStopDateType { get; set; }
        public bool? ExcludeConversionEvents { get; set; }
        public bool? IncludeOptOutLeads { get; set; }
        public bool? IncludeOnlyEmailEligibleLeads { get; set; }
        public bool? IncludeOnlyBouncedLeads { get; set; }
        public bool? IncludeOnlyNonImportedLeads { get; set; }
        public List<string> SpecificLeadGuids { get; set; }

        public SearchCriteria()
        {
            this.Keyword = string.Empty;
            this.SortField = string.Empty;
            this.PageSize = 100;
            this.PageNumber = 1;
            this.Direction = SortDirection.NotSet;
            this.StartDateUtc = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            this.StopDateUtc = DateTime.UtcNow;
            this.StartStopDateType = TimePivot.NotSet;            
            this.SpecificLeadGuids = new List<string>();
        }

        public string ToQueryString()
        {
            StringBuilder sb = new StringBuilder();

            // Keyword
            if (this.Keyword.Trim().Length > 0)
            {
                AddParam(sb, "search", this.Keyword);                
            }

            // Sorting
            if (this.SortField.Trim().Length > 0)
            {
                AddParam(sb, "sort", this.SortField);
                if (this.Direction == SortDirection.Ascending) AddParam(sb, "dir", "asc");
                if (this.Direction == SortDirection.Descending) AddParam(sb, "dir", "desc");
            }

            // Paging
            if (this.PageSize >= 1)
            {
                AddParam(sb, "max", this.PageSize.ToString());
                if (this.PageNumber > 1)
                {
                    int offset = (this.PageNumber - 1) * PageSize;
                    AddParam(sb, "offset", offset.ToString());
                }
            }
            
            // Date Filter
            if (this.StartStopDateType != TimePivot.NotSet)
            {
                double start = Utilities.DateConverter.ToMillisecondEpoch(this.StartDateUtc);
                double stop = Utilities.DateConverter.ToMillisecondEpoch(this.StopDateUtc);
                AddParam(sb, "startTime", start.ToString());
                AddParam(sb, "stopTime", stop.ToString());
                switch (this.StartStopDateType)
                {
                    case TimePivot.ClosedAt:
                        AddParam(sb, "timePivot", "closedAt");
                        break;
                    case TimePivot.FirstConvertedAt:
                        AddParam(sb, "timePivot", "firstConvertedAt");
                        break;
                    case TimePivot.InsertedAt:
                        AddParam(sb, "timePivot", "insertedAt");
                        break;
                    case TimePivot.LastConvertedAt:
                        AddParam(sb, "timePivot", "lastConvertedAt");
                        break;
                    case TimePivot.LastModifiedAt:
                        AddParam(sb, "timePivot", "lastModifiedAt");
                        break;
                }
            }

            if (this.ExcludeConversionEvents.HasValue)
                AddParam(sb, "excludeConversionEvents", this.ExcludeConversionEvents.Value ? "true" : "false");
            if (this.IncludeOptOutLeads.HasValue)
                AddParam(sb, "optout", this.IncludeOptOutLeads.Value ? "true" : "false");
            if (this.IncludeOnlyEmailEligibleLeads.HasValue)
                AddParam(sb, "eligibleForEmail", this.IncludeOnlyEmailEligibleLeads.Value ? "true" : "false");
            if (this.IncludeOnlyBouncedLeads.HasValue)
                AddParam(sb, "bounced", this.IncludeOnlyBouncedLeads.Value ? "true" : "false");
            if (this.IncludeOnlyNonImportedLeads.HasValue)
                AddParam(sb, "isNotImported", this.IncludeOnlyNonImportedLeads.Value ? "true" : "false");

            int counter = 0;
            foreach (string s in this.SpecificLeadGuids)
            {
                AddParam(sb, "guids[" + counter.ToString() + "]", s);
                counter++;
            }

            return sb.ToString();
        }

        private void AddParam(StringBuilder sb, string name, string value)
        {
            sb.Append("&" + HttpUtility.UrlEncode(name) + "=");
            sb.Append(HttpUtility.UrlEncode(value));
        }
    }
    
}
