using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ULABInventory.Model
{
    public class IssueApproved : Entity
    {
        [Required(ErrorMessage = "Issue Approved Id Required"), Key, Column(Order = 0), Index("IX_IssueApprovedId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Issue Approved"), StringLength(20, ErrorMessage = "Issue Approved cannot be longer than 20 characters.", MinimumLength = 1)]
        public string IssueApprovedId { get; set; }
        [Required]
        [Display(Name = "Requisition_D Id")]
        public string RequisitionDId { get; set; }
        [ForeignKey("RequisitionDId"), Column(Order = 2)]
        public virtual RequisitionDetail RequisitionDetail { get; set; }
        
        [StringLength(150, ErrorMessage = "Current Status cannot be longer than 150 characters.")]
        [Display(Name = "Current Status")]
        public string CurrentStatus { get; set; }
        [StringLength(150, ErrorMessage = "Return Remark cannot be longer than 150 characters.")]
        [Display(Name = "Return Remarks")]
        public string ReturnRemarks { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "ReturnBy can be maximum 10 length", MinimumLength = 1)]
        [Display(Name = "Return By")]
        public string ReturnBy { get; set; }
        [Required]
        [Display(Name = "Return IP")]
        [StringLength(20, ErrorMessage = "Return Ip can be maximum 20 length", MinimumLength = 1)]
        public string ReturnIp { get; set; }
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }
        [StringLength(150, ErrorMessage = "Garbage Remark cannot be longer than 150 characters.")]
        [Display(Name = "Garbage Description")]
        public string GarbageDescription { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Garbage By can be maximum 10 length", MinimumLength = 1)]
        [Display(Name = "Garbage By")]
        public string GarbageBy { get; set; }
        [Required]
        [Display(Name = "Garbage IP")]
        [StringLength(20, ErrorMessage = "Garbage Ip can be maximum 20 length", MinimumLength = 1)]
        public string GarbageIp { get; set; }
        [Display(Name = "Garbage Date")]
        public DateTime GarbageDate { get; set; }
        [StringLength(150, ErrorMessage = "Garbage Remark cannot be longer than 150 characters.")]
        [Display(Name = "Warranty Details")]
        public string WarrantyReason { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Garbage By can be maximum 10 length", MinimumLength = 1)]
        [Display(Name = "Warranty By")]
        public string WarrantyBy { get; set; }
        [Required]
        [Display(Name = "Warranty IP")]
        [StringLength(20, ErrorMessage = "Garbage Ip can be maximum 20 length", MinimumLength = 1)]
        public string WarrantyIp { get; set; }
        [Display(Name = "Warranty Date")]
        public DateTime WarrantyDate { get; set; }

        //[StringLength(150, ErrorMessage = "Return Comment cannot be longer than 150 characters.")]
        //[Display(Name = "Return Comment")]
        //public string ReturnComment { get; set; }
        //[StringLength(50, ErrorMessage = "Against Device Id cannot be longer than 50 characters.")]
        //[Index("IX_Id")]
        //[Display(Name = "Against Device Code")]
        //public string AgainstDeviceCode { get; set; }
    }
}