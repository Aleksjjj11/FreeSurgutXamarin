using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestXamarin.Models
{
    public class User : Item
    {
        public string UserName { get; }
        public List<Report> Reports { get; set; }
        public List<Achievement> Achievements { get; }

        public User(string name, string status, List<Achievement> achievements)
        {
            this.UserName = name;
            this.Description = status;
            this.Achievements = achievements;
        }
    }
}
