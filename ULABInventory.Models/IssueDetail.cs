﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Models
{
    public class IssueDetail : Entity
    {
        [Required(ErrorMessage = "Issue Detail Id Required"), Key, Column(Order = 0), Index("IX_IssueDetailId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Issue Detail Id"), StringLength(20, ErrorMessage = "Issue Detail Id cannot be longer than 20 characters.", MinimumLength = 1)]
        public string IssueDetailId { get; set; }
        [Required]
        [Display(Name = "Issue Name")]
        public string IssueId { get; set; }
        [ForeignKey("IssueId"),Column(Order = 2)]
        public virtual Issue Issue { get; set; }
        [Display(Name = "CPU Name")]
        [StringLength(150, ErrorMessage = "CPU Code cannot be longer than 150 characters.")]
        public string CpuId { get; set; }
        //[ForeignKey("CpuId"), Column(Order = 2)]
        //public virtual CheckInDetails InDetails { get; set; }
        [Display(Name = "Device Name")]
        [StringLength(150, ErrorMessage = "Device Code cannot be longer than 150 characters.")]
        public string DeviceId { get; set; }
        //[ForeignKey("DeviceId"),Column(Order = 3)]
        //public virtual CheckInDetails CheckInDetails { get; set; }
        [StringLength(50, ErrorMessage = "Against Device Id cannot be longer than 50 characters.")]
        [Index("IX_Id")]
        [Display(Name = "Against Device Code")]
        public string AgainstDeviceCode { get; set; }
        [StringLength(150, ErrorMessage = "Current Status cannot be longer than 150 characters.")]
        [Display(Name = "Current Status")]
        public string CurrentStatus { get; set; }
        [StringLength(150, ErrorMessage = "Device Return Remark cannot be longer than 150 characters.")]
        [Display(Name = "Device Return Remarks")]
        public string DeviceReturnRemarks { get; set; }
        [Required]
        [Display(Name = "Issue Date")]
        public DateTime IssueDate { get; set; }
        [Display(Name = "Return Date")]
        public DateTime ReturnDate { get; set; }
        [StringLength(150, ErrorMessage = "Return Comment cannot be longer than 150 characters.")]
        [Display(Name = "Return Comment")]
        public string ReturnComment { get; set; }

    }
}
