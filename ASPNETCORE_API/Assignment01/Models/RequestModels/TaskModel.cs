using System.ComponentModel.DataAnnotations;

namespace Assignment01.Models;

public class TaskModel
{

    public Guid TaskId { get; set; }

    [Required]
    public string Title { get; set; } = null!;

    [Required]
    public bool IsCompleted { get; set; }

}


