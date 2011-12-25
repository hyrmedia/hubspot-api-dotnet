using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HubSpotApiDotNet.Leads
{                
    public class LeadData
    {
        public string Address { get; set; }
        public AnalyticsDetails AnalyticsDetails { get; set; }
        public string City { get; set; }
        public double ClosedAt { get; set; }
        public DateTime ClosedAtUtc
        {
            get { return Utilities.DateConverter.FromMillisecondEpoch(this.ClosedAt); }
            set { this.ClosedAt = Utilities.DateConverter.ToMillisecondEpoch(value); }
        }
        public string Company { get; set; }
        public string Country { get; set; }
        public CrmDetails CrmDetails { get; set; }
        public double CustomerStatusModifiedAt { get; set; }
        public DateTime CustomerStatusModifiedAtUtc
        {
            get { return Utilities.DateConverter.FromMillisecondEpoch(this.CustomerStatusModifiedAt); }
            set { this.CustomerStatusModifiedAt = Utilities.DateConverter.ToMillisecondEpoch(value); }
        }
        public bool EligibleForEmail { get; set; }
        public string Email { get; set; }
        public bool EmailBounced { get; set; }
        public bool EmailOptOut { get; set; }
        public string Fax { get; set; }
        public string FirstCampaign { get; set; }
        public string FirstName { get; set; }
        public string FirstRefDomain { get; set; }
        public string FirstReferrer { get; set; }
        public string FirstURL { get; set; }
        public int FirstVisitSetAt { get; set; }
        public string FoundVia { get; set; }
        public string FullFoundViaString { get; set; }
        public string Guid { get; set; }
        public string Id { get; set; }
        public bool Imported { get; set; }
        public string Industry { get; set; }
        public double InsertedAt { get; set; }
        public DateTime InsertedAtUtc
        {
            get { return Utilities.DateConverter.FromMillisecondEpoch(this.InsertedAt); }
            set { this.InsertedAt = Utilities.DateConverter.ToMillisecondEpoch(value); }
        }
        public string IpAddress { get; set; }
        public bool IsCustomer { get; set; }
        public bool IsDeleted { get; set; }
        public string JobTitle { get; set; }
        public double LastConvertedAt { get; set; }
        public DateTime LastConvertedAtUtc
        {
            get { return Utilities.DateConverter.FromMillisecondEpoch(this.LastConvertedAt); }
            set { this.LastConvertedAt = Utilities.DateConverter.ToMillisecondEpoch(value); }
        }
        public double LastModifiedAt { get; set; }
        public DateTime LastModifiedAtUtc
        {
            get { return Utilities.DateConverter.FromMillisecondEpoch(this.LastModifiedAt); }
            set { this.LastModifiedAt = Utilities.DateConverter.ToMillisecondEpoch(value); }
        }
        public string LastName { get; set; }
        public LeadConversionEvent[] LeadConversionEvents { get; set; }
        public object[] LeadCustomerStatusModifyLogs { get; set; }
        public object[] LeadDeleteLogs { get; set; }
        public int LeadId { get; set; }
        public string LeadJsonLink { get; set; }
        public string LeadLink { get; set; }
        public bool LeadNurturingActive { get; set; }
        public int LeadNurturingCampaignId { get; set; }
        public string Message { get; set; }
        public int NumConversionEvents { get; set; }
        public string Phone { get; set; }
        public int PortalId { get; set; }
        public string PublicLeadLink { get; set; }
        public int RawScore { get; set; }
        public string Salutation { get; set; }
        public int Score { get; set; }
        public int SourceId { get; set; }
        public string SourceValue1 { get; set; }
        public string SourceValue2 { get; set; }
        public double SourceValueModifiedAt { get; set; }
        public DateTime SourceValueModifiedAtUtc
        {
            get { return Utilities.DateConverter.FromMillisecondEpoch(this.SourceValueModifiedAt); }
            set { this.SourceValueModifiedAt = Utilities.DateConverter.ToMillisecondEpoch(value); }
        }
        public string State { get; set; }
        public string TwitterHandle { get; set; }
        public string UserToken { get; set; }
        public string Website { get; set; }
        public string Zip { get; set; }
    }
}
