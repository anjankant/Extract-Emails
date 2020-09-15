using System;

namespace Extract_Emails
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IExtractEmails emails = new ExtractEmails();
            emails.ExtractingAllEmails(emails.GetContent("https://www.graycelltech.com/contact/"));
            Console.WriteLine("Hello World!");
        }
    }
}
