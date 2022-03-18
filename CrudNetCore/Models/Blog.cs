using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudNetCore.Models
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is Required")]
        [StringLength(50, ErrorMessage = "The max of {0} must be {1} or {2} characters", MinimumLength = 3)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is Required")]
        [StringLength(50, ErrorMessage = "The max of {0} must be {1} or {2} characters", MinimumLength = 3)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.Date)]
        [Display(Name = "Date Creation")]
        public DateTime DateCreation { get; set; }

        [Required(ErrorMessage = "Autor is Required")]
        public string Autor { get; set; }
    }
}
