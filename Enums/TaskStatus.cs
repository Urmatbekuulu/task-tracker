using System.ComponentModel.DataAnnotations;

namespace task_tracker.Enums
{
    public enum TaskStatus
    {
       [Display(Name = "To do")] 
       ToDo=1,
       [Display(Name = "In progress")]
       InProgress,
       [Display(Name = "Done")]
       Done
    }
}