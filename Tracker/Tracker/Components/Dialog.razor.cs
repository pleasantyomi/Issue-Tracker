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
        public Issue currentIssue;

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

        public void Show(Issue issue = null)
        {
        if (issue != null)
        {
            currentIssue = issue;
        }
        else
        {
            currentIssue = new Issue();
        }

        isVisible = true;
        }

        public void Hide(){
            isVisible = false;
            StateHasChanged();
        }

        public void SaveIssue()
        {
        if (currentIssue.Id == 0)
        {
            OnIssueCreated.InvokeAsync(currentIssue);
        }
        Hide();
        }
    }
}