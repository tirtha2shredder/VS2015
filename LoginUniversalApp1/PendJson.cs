using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUniversalApp1
{
    class PendJson
    {
        public String subject { get; set; }
        public String loc { get; set; }
        public PendJson(String subject,String loc)
        {
            this.subject = subject;
            this.loc = loc;
        }
    }
}
