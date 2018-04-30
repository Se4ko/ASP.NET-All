using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _3.InformationalApp.Data
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Artist { get; set; }

        public int Year { get; set; }
    }
}