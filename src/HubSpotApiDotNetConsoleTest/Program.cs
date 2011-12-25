using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HubSpotApiDotNetConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            string key = ReadApiKey();
            if (key.Trim().Length < 1)
            {
                Console.WriteLine("MISSING API KEY!!\n\nCreate a text file called ApiKey.txt with your HubSpot APIKey on the first line.");
                Console.WriteLine();
                Console.WriteLine("FINISHED! Press any key to exit.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Got Api Key from ApiKey.txt");
            }

            Console.WriteLine("Search for a lead or type 'quit' to exit");

            string keyword = string.Empty;
            
            while(true)
            {

                Console.WriteLine();
                Console.Write("Search Leads: ");
                keyword = Console.ReadLine();
                keyword = keyword.Trim().ToLowerInvariant();
                if (keyword == "quit" || keyword == "exit" || keyword == "x" || keyword == "q")
                {
                    Console.WriteLine();
                    Console.WriteLine("FINISHED! Press any key to exit.");
                    Console.ReadKey();
                    return;
                }
                DoSearch(keyword, key);
            }

            
        }

        private static string ReadApiKey()
        {                        
            string appPath = System.Reflection.Assembly.GetExecutingAssembly().Location;         
            string directory = System.IO.Path.GetDirectoryName(appPath);
            string filePath = directory + "/ApiKey.txt";

            if (File.Exists(filePath))
            {
                foreach (string s in File.ReadLines(filePath))
                {
                    return s.Trim();
                }
            }
            else
            {
                Console.WriteLine("Missing File: " + filePath);
            }
            return string.Empty;
        }

        private static void DoSearch(string keyword, string apikey)
        {
            try
            {
                HubSpotApiDotNet.LeadsApi api = new HubSpotApiDotNet.LeadsApi(apikey);
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
                    Console.WriteLine(l.Email + ", " + l.FirstName + " " + l.LastName + ", " + l.Guid + ", " + l.Id);
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION: " + ex.Message + "\n" + ex.StackTrace);
            }
            Console.WriteLine();
        }
    }
}
