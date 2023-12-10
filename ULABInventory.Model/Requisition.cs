using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ULABInventory.Model
{
    public class Requisition : Entity
    {
        [Required(ErrorMessage = "Requisition Required"), Key, Column(Order = 0), Index("IX_RequisitionId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Requisition Id"), StringLength(15, ErrorMessage = "Requisition cannot be longer than 15 characters.", MinimumLength = 1)]
        public string RequisitionId { get; set; }
        [Display(Name = "Employee Name")]
        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Employee Employees { get; set; }
        [Display(Name = "Campus Name")]
        public string CampusId { get; set; }
        [ForeignKey("CampusId"), Column(Order = 2)]
        public virtual Campus Campus { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Room No can be maximum 10 length", MinimumLength = 1)]
        public string RoomNo { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Floor No can be maximum 20 length", MinimumLength = 1)]
        public string FloorNo { get; set; }
        [StringLength(150, ErrorMessage = "Remarks can be maximum 150 length", MinimumLength = 1)]
        public string Remarks { get; set; }

        public int IssueTypeId { get; set; }
        [ForeignKey("IssueTypeId")]
        public IssueType IssueType { get; set; }
        public virtual ICollection<RequisitionDetail> RequisitionDetails { get; set; }
    }
}