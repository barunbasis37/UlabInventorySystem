using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Model
{
    public class Program : Entity
    {
        [Required(ErrorMessage = "Program Id Required"), Key, Column(Order = 0), Index("IX_ProgramId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Program Id"), StringLength(10, ErrorMessage = "Program Id cannot be longer than 10 characters.", MinimumLength = 1)]
        public string ProgramId { get; set; }
        [Required]
        [StringLength(80, ErrorMessage = "Program Name cannot be longer than 80 characters.", MinimumLength = 1)]
        [Index("IX_ProgramName")]
        [Display(Name = "Program Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentId { get; set; }
        [ForeignKey("DepartmentId"), Column(Order = 1)]
        public virtual Department Department { get; set; }
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
    }
}
