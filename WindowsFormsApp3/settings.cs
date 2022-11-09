using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApp3
{
    internal class Settings
    {
        public class NetWork
        {
            public DateTimeOffset Date { get; set; }
            public string IP_adress { get; set; }
        }

        public void SaveSetting()
        {
            var settings = new NetWork
            {
                Date = DateTimeOffset.Now,
                IP_adress = "192.168.0.3"
            };
        }

    }
}
