using System.ComponentModel.DataAnnotations;

namespace task_tracker.DAL.Enums
{
    public enum ProjectStatus
    {
        [Display(Name = "Not started")]
        NotStarted=1,
        [Display(Name = "Active")]
        Active,
        [Display(Name = "Completed")]
        Completed
    }
}