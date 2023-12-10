using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Model
{
    public class CheckInDetail : Entity
    {
        [Required(ErrorMessage = "CheckIn Detail Id Required"), Key, Column(Order = 0), Index("IX_CheckInDetailId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "CheckIn Detail Id"), StringLength(20, ErrorMessage = "CheckIn Detail Id cannot be longer than 20 characters.", MinimumLength = 1)]
        public string CheckInDetailId { get; set; }
        [Required]
        public string CheckInId { get; set; }
        [ForeignKey("CheckInId"), Column(Order = 2)]
        public virtual CheckIn CheckIn { get; set; }
        [Column(Order = 3)]
        [Index("IX_AuditCode", 1, IsUnique = true)]
        [StringLength(250)]
        [Display(Name = "Audit Code")]
        public string AuditCode { get; set; }
        [Required(ErrorMessage = "CPU Id Required"), Column(Order = 4), Index("IX_CPUCode")]
        [Display(Name = "CPU Code"), StringLength(100, ErrorMessage = "CPU Id cannot be longer than 20 characters.", MinimumLength = 1)]
        public string CpuId { get; set; }
        [Required(ErrorMessage = "Device Id Required"), Column(Order = 5), Index("IX_DeviceCode", IsUnique = true)]
        [Display(Name = "Device Code"), StringLength(150, ErrorMessage = "Device Id cannot be longer than 20 characters.", MinimumLength = 1)]
        public string DeviceId { get; set; }
        //[Required]
        public string ItemId { get; set; }
        [ForeignKey("ItemId"), Column(Order = 1)]
        [Display(Name = "Item")]
        public virtual Item Item { get; set; }
        [Required]
        public string ItemDetailsId { get; set; }
        [ForeignKey("ItemDetailsId"), Column(Order = 2)]
        public virtual ItemDetail ItemDetail { get; set; }
        //[Required(ErrorMessage = "Item Size required")]
        //[StringLength(50, ErrorMessage = "Item Size cannot be longer than 50 characters.", MinimumLength = 1)]
        //[Display(Name = "Item Size")]
        //public string ItemSize { get; set; }
        //[Required(ErrorMessage = "Item Brand required")]
        //[StringLength(50, ErrorMessage = "Item Brand cannot be longer than 50 characters.", MinimumLength = 1)]
        //[Display(Name = "Item Brand")]
        //public string ItemBrand { get; set; }
        [Required(ErrorMessage = "Price required")]
        [Column(TypeName = "Money")]
        [Display(Name = "Unit Price")]
        public decimal Unitprice { get; set; }
        [Required(ErrorMessage = "Warranty Expire Date required")]
        [Display(Name = "Warrant Expired Date")]
        public DateTime WarrantyExpireDate { get; set; }

        [Display(Name = "Warrenty Duration (Month)")]
        public int WarrentyDuration { get; set; }
        [Required(ErrorMessage = "Product Serial No required")]
        [StringLength(50, ErrorMessage = "Product Serial No cannot be longer than 50 characters.", MinimumLength = 1)]
        [Display(Name = "Product Serial No")]
        public string ProductSerialNo { get; set; }
        [Required(ErrorMessage = "Item Status Required")]
        [StringLength(50, ErrorMessage = "Item Status cannot be longer than 50 characters.", MinimumLength = 1)]
        [Display(Name = "Item Status")]
        public string ItemStatus { get; set; }
        [Required(ErrorMessage = "Current Status required")]
        [StringLength(50, ErrorMessage = "Current Status cannot be longer than 50 characters.", MinimumLength = 1)]
        [Display(Name = "Current Status")]
        public string CurrentStatus { get; set; }
        [StringLength(150, ErrorMessage = "Remarks cannot be longer than 150 characters.")]
        public string Remarks { get; set; }

        [StringLength(1000, ErrorMessage = "Image Path cannot be longer than 1000 characters.")]
        [DefaultValue("imagepath")]
        public string QRCodeImgPath { get; set; }

        public byte[] QRImage { get; set; }
    }
}