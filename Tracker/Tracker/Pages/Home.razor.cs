using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Components;
using Tracker.Pages;

namespace Tracker.Pages
{
    public partial class Home
    {
        public Dialog dialog;
        public List<Issue>Issues = new List<Issue>();

        public void OpenDialog(){
            Console.WriteLine("Button triggered");
            dialog.Show();
        }

        public void CloseDialog(){
            dialog.Hide();
        }

        public void HandleNewIssue(Issue newIssue){
            Issues.Add(newIssue);
            StateHasChanged();
        }

        public void ToggleMenu(Issue issue){
            issue.IsMenuOpen = !issue.IsMenuOpen;
        }

        public void EditIssue(Issue issue){
            dialog.Show(issue);

        }

        public void DeleteIssue(Issue issue){
            Issues.Remove(issue);
        }
        
    }
}