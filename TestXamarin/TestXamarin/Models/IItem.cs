using System;
using System.Collections.Generic;
using System.Text;

namespace TestXamarin.Models
{
    interface IItem
    {
        string Id { get; set; }
        string Text { get; set; }
        string Description { get; set; }
    }
}
