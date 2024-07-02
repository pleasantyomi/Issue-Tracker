using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Components
{
    public partial class Dialog
    {

        public bool isVisible { get; set; }

        public void Show(){
            isVisible = true;
            StateHasChanged();
        }

        public void Hide(){
            isVisible = false;
            StateHasChanged();
        }

    }
}