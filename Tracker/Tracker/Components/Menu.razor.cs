using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Components
{
    public partial class Menu
    {
        public bool ShowMenu { get; set; }
        public void Show(){
            ShowMenu = true;
            StateHasChanged();
        }
        public void Hide(){
            ShowMenu = false;
            StateHasChanged();
        }
    }
}