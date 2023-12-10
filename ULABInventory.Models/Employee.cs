using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ULABInventory.Models
{
    public class Employee : Entity
    {
        [Required(ErrorMessage = "Employee Id Required"), Key, Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None), StringLength(20, ErrorMessage = "Employee Id cannot be longer than 20 characters.", MinimumLength = 1)]
        [Index("IX_Id", IsUnique = true)]
        public string EmployeeId { get; set; }
        [Required]
        [StringLength(150, ErrorMessage = "Name cannot be longer than 150 characters.", MinimumLength = 1)]
        [Index("IX_Name", IsUnique = true)]
        [Display(Name = "Employee Name")]
        public string Name { get; set; }
        [Required]
        public string Designation { get; set; }
        public string DepartmentId { get; set; }
        [ForeignKey("DepartmentId"),Column(Order = 1)]
        public virtual Department Department { get; set; }
    }
}