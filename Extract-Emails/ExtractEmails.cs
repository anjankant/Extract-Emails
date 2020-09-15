using System;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

namespace Extract_Emails
{
    public class ExtractEmails: IExtractEmails
    {
        public string GetContent(string URL)
        {
            HttpWebResponse response = null;
            StreamReader stream = null;
            try
            {
                //create a request object using the url passed in 
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(URL);
                webRequest.Timeout = 10000;

                //go get a response from the page 
                response = (HttpWebResponse)webRequest.GetResponse();

                //create a streamreader object from the response 
                stream = new StreamReader(response.GetResponseStream());

                //get the contents of the page as a string and return it 
                return stream.ReadToEnd();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                response.Close();
                stream.Close();
            }
        }

        public void ExtractingAllEmails(string content)
        {
            //defining here regular expression 
            string _pattern = @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@" + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\." + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|" + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";

            //define regex object 
            Regex _regExpr = new Regex(_pattern, RegexOptions.IgnoreCase);

            //getting the first matching  
            Match _match = _regExpr.Match(content);

            //extracting all emails thourgh through loop matches 
            while (_match.Success)
            {
                //displaying extracted email from matching
                Console.WriteLine("href match: " + _match.Groups[0].Value);

                //geting next match 
                _match = _match.NextMatch();
            }
        }
    }
}
