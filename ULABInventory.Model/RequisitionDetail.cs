using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ULABInventory.Model
{
    public class RequisitionDetail : Entity
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
        [Display(Name = "CheckIn Details")]
        public string CheckInDetailIdCode { get; set; }
        [ForeignKey("CheckInDetailIdCode")]
        public virtual CheckInDetail CheckInDetail { get; set; }
        [Required]
        [Display(Name = "IsApproved")]
        public bool IsApproved { get; set; }
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
        [Display(Name = "IsIssued")]
        public bool IsIssued { get; set; }
        [Required]
        [Display(Name = "Issued By")]
        public string IssuedBy { get; set; }
        [Required]
        [Display(Name = "Issued Date")]
        public DateTime IssuedDateTime { get; set; }
        [Required]
        [Display(Name = "Issued IP")]
        public string IssuedIP { get; set; }
        [StringLength(20, ErrorMessage = "Remarks can be maximum 20 length", MinimumLength = 1)]
        public string ApproveRemarks { get; set; }

        [StringLength(50, ErrorMessage = "Remarks can be maximum 50 length", MinimumLength = 1)]
        public string RequestRemarks { get; set; }
        [Required]
        [Display(Name = "IsDenied")]
        public bool IsDenied { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "ApprovedID can be maximum 10 length", MinimumLength = 1)]
        [Display(Name = "Denied By")]
        public string DeniedBy { get; set; }
        [Required]
        [Display(Name = "Denied Date")]
        public DateTime DeniedDateTime { get; set; }
        [Required]
        [Display(Name = "Denied IP")]
        public string DeniedIP { get; set; }
        //[StringLength(10, ErrorMessage = "Status can be maximum 10 length", MinimumLength = 1)]
        //public string Status { get; set; }
    }
}