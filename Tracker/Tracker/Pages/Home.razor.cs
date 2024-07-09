using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Components;
using Tracker.Pages;
using Microsoft.AspNetCore.Components.Web;
// inject IVersionProvider;

namespace Tracker.Pages
{
    public partial class Home
    {
    public Dialog dialog;
    public List<Issue> Issues = new List<Issue>{
        new Issue {Id =1 , type = "Bug", summary = "Fix a bug", description = "The primary button isn't working", state="New", date = DateTime.Now.AddDays(8)},
        new Issue {Id =2 , type = "Story", summary = "On the way to Tranarc", description = "The primary button isn't working", state="Pending", date = DateTime.Now.AddDays(5)},
        new Issue {Id =3 , type = "Task", summary = "Build a bot", description = "The primary button isn't working", state="Completed", date = DateTime.Now.AddDays(3)},
    };
    public string search = "";

    public IEnumerable<Issue> FilteredIssues =>
        string.IsNullOrWhiteSpace(search)
            ? Issues
            : Issues.Where(i => i.summary.Contains(search, StringComparison.OrdinalIgnoreCase));

    public void OpenDialog(){
        Console.WriteLine("Button triggered");
        dialog.Show();
    }
    public void CloseDialog(){
        dialog.Hide();
    }

    public void HandleNewIssue(Issue newIssue){
        var existingIssue =  Issues.FirstOrDefault(i => i.Id == newIssue.Id);
        if (existingIssue != null){
            existingIssue.type = newIssue.type;
            existingIssue.summary = newIssue.summary;
            existingIssue.description = newIssue.description;
            existingIssue.state = newIssue.state;
            existingIssue.date = newIssue.date;
        }
        else{
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

    public void EditIssue(Issue issue)
    {
        Console.WriteLine("Issue editing not yet implemented.");
        issue.IsMenuOpen = false;
        dialog.Show(issue);
    }

    public void DeleteIssue(int issueId)
    {
        Issues.RemoveAll(i => i.Id == issueId);
    }

    // public string draggedIssueId;

    // public void OnDragStart(int issueId, DragEventArgs e)
    // {
    //     draggedIssueId = issueId.ToString();
    // }

    // public void OnDragOver(DragEventArgs e)
    // {
    //     e.DataTransfer.Effect = "move";
    //     e.PreventDefault();
    // }

    // public void OnDrop(DragEventArgs e)
    // {
    //     var issueId = int.Parse(draggedIssueId);
    //     var issue = Issues.FirstOrDefault(i => i.Id == issueId);
    //     if (issue != null)
    //     {
    //         var dropCategory = e.Target.Id switch
    //         {
    //             "To Do" => "New",
    //             "IN PROGRESS" => "Pending",
    //             "DONE" => "Completed",
    //             _ => null
    //         };

    //         if (dropCategory != null && issue.state != dropCategory)
    //         {
    //             issue.state = dropCategory;
    //             StateHasChanged();
    //         }
    //     }
    // }
}

}