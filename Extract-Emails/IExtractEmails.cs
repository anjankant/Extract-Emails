using System;
using System.Collections.Generic;
using System.Text;

namespace Extract_Emails
{
   public interface IExtractEmails
    {
        string GetContent(string URL);
        void ExtractingAllEmails(string content);
    }
}
