using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Components;

namespace Tracker.Pages
{
    public partial class Home
    {
        public Dialog dialog;

        public void OpenDialog(){
            Console.WriteLine("Button triggered");
            dialog.Show();
        }

        public void CloseDialog(){
            dialog.Hide();
        }
        
    }
}