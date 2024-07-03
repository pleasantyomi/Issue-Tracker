using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Tracker.Components;
using Tracker.Pages;

namespace Tracker.Components
{
    public partial class Dialog
    {
        public bool isVisible { get; set; }
        public string IssueType { get; set; }
        public string Summary { get; set; }
        public string IssueDescription { get; set;}
        public string IssueState { get; set; }
        public string DueDate { get; set; }
        [Parameter]
        public EventCallback<Issue> OnIssueCreated { get; set; }

        public async Task CreateNewIssue(){
            var newIssue = new Issue{
                type = IssueType,
                summary = Summary,
                description = IssueDescription,
                state = IssueState,
                date = DueDate,
            };

            await OnIssueCreated.InvokeAsync(newIssue);
            Hide();
        }

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