using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HubSpotApiDotNet.Leads
{
    public class AnalyticsDetails
    {
        public bool AllViewsImported { get; set; }
        public double CountsModifiedAt { get; set; }
        public DateTime CountsModifiedAtUtc
        {
            get { return Utilities.DateConverter.FromMillisecondEpoch(this.CountsModifiedAt); }
            set { this.CountsModifiedAt = Utilities.DateConverter.ToMillisecondEpoch(value); }
        }
        public double FirstVisitAt { get; set; }
        public DateTime FirstVisitAtUtc
        {
            get { return Utilities.DateConverter.FromMillisecondEpoch(this.FirstVisitAt); }
            set { this.FirstVisitAt = Utilities.DateConverter.ToMillisecondEpoch(value); }
        }
        public string Id { get; set; }
        public double LastPageViewAt { get; set; }
        public DateTime LastPageViewAtUtc
        {
            get { return Utilities.DateConverter.FromMillisecondEpoch(this.LastPageViewAt); }
            set { this.LastPageViewAt = Utilities.DateConverter.ToMillisecondEpoch(value); }
        }
        public double LastVisitAt { get; set; }
        public DateTime LastVisitAtUtc
        {
            get { return Utilities.DateConverter.FromMillisecondEpoch(this.LastVisitAt); }
            set { this.LastVisitAt = Utilities.DateConverter.ToMillisecondEpoch(value); }
        }
        public string LeadGuid { get; set; }
        public int LeadId { get; set; }
        public int PageViewCount { get; set; }
        public int PortalId { get; set; }
        public string UserToken { get; set; }
        public int VisitCount { get; set; }
    }
}
