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
    public List<Issue> Issues = new List<Issue>
    {
        new Issue {Id = 1, type = "Bug", summary = "Fix a bug", description = "The primary button isn't working", state = "New", date = DateTime.Now.AddDays(8)},
        new Issue {Id = 2, type = "Story", summary = "On the way to Tranarc", description = "The primary button isn't working", state = "Pending", date = DateTime.Now.AddDays(5)},
        new Issue {Id = 3, type = "Task", summary = "Build a bot", description = "The primary button isn't working", state = "Completed", date = DateTime.Now.AddDays(3)},
    };
    public string searchQuery = "";

    public IEnumerable<Issue> FilteredIssues =>
        string.IsNullOrWhiteSpace(searchQuery)
            ? Issues
            : Issues.Where(i => i.summary.Contains(searchQuery, StringComparison.OrdinalIgnoreCase));

    public void OpenDialog()
    {
        Console.WriteLine("Button triggered");
        dialog.Show();
    }

    public void HandleNewIssue(Issue newIssue)
    {
        var existingIssue = Issues.FirstOrDefault(i => i.Id == newIssue.Id);
        if (existingIssue != null)
        {
            existingIssue.type = newIssue.type;
            existingIssue.summary = newIssue.summary;
            existingIssue.description = newIssue.description;
            existingIssue.state = newIssue.state;
            existingIssue.date = newIssue.date;
        }
        else
        {
            Issues.Add(newIssue);
        }
        StateHasChanged();
    }

    public void ToggleMenu(int issueId)
    {
        var issue = Issues.FirstOrDefault(i => i.Id == issueId);
        if (issue != null)
        {
            issue.IsMenuOpen = !issue.IsMenuOpen;
        }
    }

    public void CloseAllMenus()
    {
        foreach (var issue in Issues)
        {
            issue.IsMenuOpen = false;
        }
    }

    public void EditIssue(Issue issue)
    {
        CloseAllMenus();
        dialog.Show(issue);
    }

    public void DeleteIssue(int id)
    {
        Issues = Issues.Where(i => i.Id != id).ToList();
        CloseAllMenus();
    }
}

}