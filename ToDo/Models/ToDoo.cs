using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class ToDoo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter a description.")]
        public string Description { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter a due date.")]
        public DateTime? DueDate { get; set; }
        [Required(ErrorMessage = "Please select a category.")]
        public string CategoryId { get; set; } = string.Empty;
        [ValidateNever]
        public Category Category { get; set; } = null!; // We will bring in CategoryId basically as a foreign Key to this object
        [Required(ErrorMessage = "Please select a Status")]
        public string StatusId { get; set; } = string.Empty;
        [ValidateNever]
        public Status Status { get; set; } = null!;
        public bool Overdue => StatusId == "open" && DueDate < DateTime.Today;
    }
}
