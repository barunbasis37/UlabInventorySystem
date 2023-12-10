using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Models
{
    public class RequisitionDetails : Entity
    {
        [Required(ErrorMessage = "Requisition Detail Required"), Key, Column(Order = 0), Index("IX_RequisitionDetailId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Requisition Detail Id"), StringLength(20, ErrorMessage = "Requisition Detail cannot be longer than 20 characters.", MinimumLength = 1)]
        public string RequisitionDetailId { get; set; }
        [Required]
        [Display(Name = "Requisition Name")]
        public string RequisitionId { get; set; }
        [ForeignKey("RequisitionId")]
        public virtual Requisition Requisition { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        public string ItemCode { get; set; }
        [ForeignKey("ItemCode")]
        public virtual Item Item { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "ApprovedID can be maximum 10 length", MinimumLength = 1)]
        [Display(Name = "Approved By")]
        public string ApprovedBy { get; set; }
        [Required]
        [Display(Name = "Approved Date")]
        public DateTime ApprovedDateTime { get; set; }
        [Required]
        [Display(Name = "Approved IP")]
        public string ApprovedIP { get; set; }
        [Required]
        [Display(Name = "Issued By")]
        public string IssuedBy { get; set; }
        [Required]
        [Display(Name = "Issued Date")]
        public DateTime IssuedDateTime { get; set; }
        [Required]
        [Display(Name = "Issued IP")]
        public string IssuedIP { get; set; }
        [StringLength(10, ErrorMessage = "Remarks can be maximum 10 length", MinimumLength = 1)]
        public string Remarks { get; set; }
        [StringLength(10, ErrorMessage = "Status can be maximum 10 length", MinimumLength = 1)]
        public string Status { get; set; }

    }
}
