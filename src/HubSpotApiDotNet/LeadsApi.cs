﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HubSpotApiDotNet
{
    public class LeadsApi
    {
        private const string URL_SEARCH = "https://hubapi.com/leads/v1/list?hapikey={0}";

        private string _ApiKey;

        public LeadsApi(string apiKey)
        {
            this._ApiKey = apiKey;
        }

        public List<Leads.LeadData> Search(Leads.SearchCriteria criteria)
        {            
            List<Leads.LeadData> result = new List<Leads.LeadData>();

            string destination = string.Format(URL_SEARCH, _ApiKey) + criteria.ToQueryString();
            string jsonResult = Utilities.HttpUtils.SendRequestByGet(destination);

            dynamic leadsDynamic = Utilities.DynamicJson.Parse(jsonResult);
            if (leadsDynamic != null)
            {
                foreach (var ld in leadsDynamic)
                {
                    Leads.LeadData l = new Leads.LeadData(ld);                    
                    result.Add(l);
                }
            }
            return result;
        }

        public bool CreateNewLead(string formUrl, Leads.CreateLeadRequest request)
        {
            bool result = false;

            string destination = formUrl;
            string postData = request.ToPostData();
            string jsonResult = Utilities.HttpUtils.SendRequestByPost(destination, postData);
            result = true;

            return result;
        }
    }
}
