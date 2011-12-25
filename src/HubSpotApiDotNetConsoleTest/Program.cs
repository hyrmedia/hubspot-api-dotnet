using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HubSpotApiDotNetConsoleTest
{
    class Program
    {
        private static string _Key { get; set; }
        private static string _FormUrl { get; set; }

        static void Main(string[] args)
        {
            if (!ReadSettings())
            {
                return;
            }
                            
            MainMenu();

            Console.WriteLine("");
            Console.WriteLine("Finished! Press Any Key to Exit");
            Console.ReadKey();
        }

        private static bool ReadSettings()
        {
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string directory = System.IO.Path.GetDirectoryName(appPath);
            string filePath = directory + "/Settings.txt";

            if (File.Exists(filePath))
            {
                foreach (string s in File.ReadLines(filePath))
                {
                    string[] parts = s.Split('|');
                    if (parts.Length > 1)
                    {
                        if (parts[0].Trim().ToLowerInvariant() == "key")
                        {
                            _Key = parts[1].Trim();

                            if (_Key.Length < 1)
                            {
                                Console.WriteLine("MISSING API KEY!!\n\nCreate a text file called ApiKey.txt with your HubSpot APIKey on the first line.");
                                Console.WriteLine();
                                return false;
                            }
                            else
                            {
                                Console.WriteLine("Got Api Key from ApiKey.txt");
                            }
                        }
                        if (parts[0].Trim().ToLowerInvariant() == "form")
                        {
                            _FormUrl = parts[1].Trim();
                        }
                    }

                }
            }
            else
            {
                Console.WriteLine("Missing File: " + filePath);
                return false;
            }
            return true;
        }

        private static void MainMenu()
        {
            Console.WriteLine("HubSpot API Wrapper: Test Console");
            

            while(true)
            {
                Console.WriteLine("");
                Console.WriteLine("Press 1 for search, Press 2 to create sample lead, q to quit");
                Console.WriteLine("");
                Console.Write("> ");
                string cmd = Console.ReadLine();
                switch(cmd.Trim().ToLowerInvariant())
                {
                    case "1":
                        SearchLeadMode();
                        break;
                    case "2":
                        CreateLeadMode();
                        break;
                    case "q":
                    case "x":
                    case "exit":
                    case "0":
                    case "quit":
                        return;
                    default:
                        Console.WriteLine("\nERROR: Unknown Command. Please Try Again!");
                        break;                            
                }                   
            }
        }

        private static void SearchLeadMode()
        {
            Console.WriteLine("");
            Console.WriteLine("Search for a lead or type 'q' to exit");

            string keyword = string.Empty;

            while (true)
            {

                Console.WriteLine();
                Console.Write("Search Leads> ");
                keyword = Console.ReadLine();
                keyword = keyword.Trim().ToLowerInvariant();
                if (keyword == "quit" || keyword == "exit" || keyword == "x" || keyword == "q" || keyword == "e")
                {
                    return;
                }
                DoSearch(keyword);
            }
        }
        private static void DoSearch(string keyword)
        {
            try
            {
                HubSpotApiDotNet.LeadsApi api = new HubSpotApiDotNet.LeadsApi(_Key);
                List<HubSpotApiDotNet.Leads.LeadData> leads = api.Search(new HubSpotApiDotNet.Leads.SearchCriteria() { Keyword = keyword });
                if (leads == null)
                {
                    Console.WriteLine("Result was NULL!");
                    return;
                }
                Console.WriteLine("Found " + leads.Count.ToString() + " Leads");
                Console.WriteLine("-------------------------------------------");
                foreach (var l in leads)
                {
                    Console.WriteLine(l.Email + ", " + l.FirstName + " " + l.LastName);
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION: " + ex.Message + "\n" + ex.StackTrace);
            }
            Console.WriteLine();
        }

        private static void CreateLeadMode()
        {
            Console.WriteLine("");
            Console.WriteLine("Type and Email to Create a lead or type 'q' to exit");

            string keyword = string.Empty;

            while (true)
            {

                Console.WriteLine();
                Console.Write("Create Lead> ");
                keyword = Console.ReadLine();
                keyword = keyword.Trim().ToLowerInvariant();
                if (keyword == "quit" || keyword == "exit" || keyword == "x" || keyword == "q" || keyword == "e")
                {
                    return;
                }
                CreateSampleLead(keyword);
            }
        }
        private static void CreateSampleLead(string email)
        {
            try
            {
                HubSpotApiDotNet.LeadsApi api = new HubSpotApiDotNet.LeadsApi(_Key);

                HubSpotApiDotNet.Leads.CreateLeadRequest createRequest = new HubSpotApiDotNet.Leads.CreateLeadRequest("", "0.0.0.0");
                createRequest.Email = email;
                createRequest.FirstName = "Sample";
                createRequest.LastName = "SampleLast";
                createRequest.State = "ZZ";
                createRequest.Message = "Fake Lead!";

                bool result = api.CreateNewLead(_FormUrl, createRequest);
                if (result)
                {
                    Console.WriteLine("Create Lead Returned True!");
                }
                else
                {
                    Console.WriteLine("Create Failed");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION: " + ex.Message + "\n" + ex.StackTrace);
            }            
        }
    }
}
