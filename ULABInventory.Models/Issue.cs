using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Models
{
    public class Issue : Entity
    {
        [Required(ErrorMessage = "Issue Id Required"), Key, Column(Order = 0), Index("IX_IssueId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Issue Id"), StringLength(20, ErrorMessage = "Issue Id cannot be longer than 20 characters.", MinimumLength = 1)]
        public string IssueId { get; set; }
        public string EmployeeId { get; set; }
        [ForeignKey("EmployeeId"),Column(Order = 2)]
        public virtual Employee Employee { get; set; }
        public string DepartmentId { get; set; }
        [ForeignKey("DepartmentId"),Column(Order = 1)]
        public virtual Department Department { get; set; }
        public string CampusId { get; set; }
        [ForeignKey("CampusId"),Column(Order = 1)]
        public virtual Campus Campus { get; set; }
        [Required]
        public string Floor { get; set; }
        [Required]
        public string Room { get; set; }
        [StringLength(100, ErrorMessage = "Issue Remark cannot be longer than 100 characters.", MinimumLength = 1)]
        [Index("IX_IssueRemark", IsUnique = true)]
        [Display(Name = "Issue Remark")]
        public string IssueRemark { get; set; }
        [StringLength(100, ErrorMessage = "Return Remark cannot be longer than 100 characters.", MinimumLength = 1)]
        [Index("IX_ReturnRemark", IsUnique = true)]
        [Display(Name = "Return Remark")]
        public string ReturnRemark { get; set; }
        [Required]
        public bool IsApproved { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 1)]
        [Index("IX_Id")]
        [Display(Name = "Approved Id")]
        public string ApprovedId { get; set; }
        [Required]
        [Display(Name = "Approved Date")]
        public DateTime ApprovedDateTime { get; set; }
        [Required]
        [Display(Name = "Approved IP")]
        public string ApprovedIp { get; set; }
        public virtual ICollection<IssueDetail> IssueDetails { get; set; }
        
    }
}
