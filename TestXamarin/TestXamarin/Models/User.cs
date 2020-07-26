using System;
using System.Collections.Generic;
using System.Text;

namespace TestXamarin.Models
{
    class User : Item
    {
        public string UserName { get; }
        public List<Report> Reports { get; }
        public List<Achievement> Achievements { get; }

    }
}
