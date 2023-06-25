using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Mail
{
    /// <summary>
    /// کلاس تمیز
    /// </summary>
    public class EmailRequest
    {
        // Begin Email 


        public string Host { get; set; }
        public int Port { get; } = 587;
        public string User { get; set; }
        public string Pass { get; set; }
        public string DisplayName { get; set; }
        public string From { get; set; }


        /// //////////////////////
        //  Destination Email

        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsBodyHtml { get; set; } = false;
    }
}
