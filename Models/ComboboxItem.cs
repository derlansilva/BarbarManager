using System;
using System.Collections.Generic;
using System.Text;

namespace Barbermanager.Models
{
    internal class ComboboxItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }
}
