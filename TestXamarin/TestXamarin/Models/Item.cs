﻿using System;
using Xamarin.Forms;

namespace TestXamarin.Models
{
    [Serializable]
    public class Item : IItem
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }
    }
}