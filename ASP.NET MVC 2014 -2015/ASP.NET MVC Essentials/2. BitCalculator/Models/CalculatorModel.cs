using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _2.BitCalculator.Models
{
    public class CalculatorModel
    {
        public decimal Value { get; set; }
        public List<SelectListItem> Types { get; set; }
        public List<SelectListItem> Kilos { get; set; }
        public string SelectedType { get; set; }
        public string SelectedKilo { get; set; }
        public Dictionary<string, string> Result { get; set; }
    }
}