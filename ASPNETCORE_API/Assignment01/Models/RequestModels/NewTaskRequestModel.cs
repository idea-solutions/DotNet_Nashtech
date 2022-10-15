using System.ComponentModel.DataAnnotations;

namespace Assignment01.Models;

public class NewTaskRequestModel
{

    [Required]
    [MinLength(5)]
    public string Title { get; set; } = null!;

    public bool isCompleted { get; set; }

}


