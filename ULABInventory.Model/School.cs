using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Model
{
    public class School : Entity
    {
        [Required(ErrorMessage = "School Id Required"), Key, Column(Order = 0), Index("IX_SchoolId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "School Id"), StringLength(20, ErrorMessage = "School Id cannot be longer than 20 characters.", MinimumLength = 1)]
        public string SchoolId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "School Name cannot be longer than 50 characters.", MinimumLength = 1)]
        [Index("IX_Name", IsUnique = true)]
        [Display(Name = "School Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Priority Level")]
        public int PriorityLevel { get; set; }
        public virtual ICollection<Department> Departments { get; set; }
    }
}
