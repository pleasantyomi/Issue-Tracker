using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Tracker.Components;
using Tracker.Pages;

namespace Tracker.Components
{
    public partial class Dialog{
    [Parameter] public EventCallback<Issue> OnIssueCreated { get; set; }
    private QuillEditor quillEditor;
    private bool isVisible;
    private Issue currentIssue;

    public void Show(Issue issue = null)
    {
        currentIssue = issue ?? new Issue();
        isVisible = true;
        StateHasChanged();
    }

    public void Hide()
    {
        isVisible = false;
        StateHasChanged();
    }

    private async Task CreateOrUpdateIssue()
    {
        currentIssue.description = await quillEditor.GetContent();
        await OnIssueCreated.InvokeAsync(currentIssue);
        Hide();
    }

    }
}