using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ULABInventory.Model
{
    public class Department : Entity
    {
        [Required(ErrorMessage = "Department Id Required"), Key, Column(Order = 0), Index("IX_DepartmentId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Department Id"), StringLength(10, ErrorMessage = "Department Id cannot be longer than 30 characters.", MinimumLength = 1)]
        public string DepartmentId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Department Name cannot be longer than 50 characters.", MinimumLength = 1)]
        [Index("IX_Name")]
        [Display(Name = "Department Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "School Name")]
        public string SchoolId { get; set; }
        [ForeignKey("SchoolId"), Column(Order = 1)]
        public virtual School School { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Type cannot be longer than 30 characters.", MinimumLength = 1)]
        [Index("IX_Type")]
        [Display(Name = "Department Type")]
        public string Type { get; set; }
        [Required]
        [Display(Name = "Priority Level")]
        public int Priority { get; set; }
        [StringLength(100, ErrorMessage = "Description can be maximum 100 length")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}