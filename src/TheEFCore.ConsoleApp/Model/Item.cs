using System;
using System.Collections.Generic;

#nullable disable

namespace TheEFCore.ConsoleApp.Model
{
    public partial class Item
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
