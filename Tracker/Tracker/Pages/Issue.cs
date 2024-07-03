using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Pages;
using Tracker.Components;

namespace Tracker.Pages
{
    public class Issue
    {
        public string type { get; set; }
        public string summary { get; set; }
        public string description { get; set; }
        public string state { get; set; }
        public string date { get; set; }
    }

}