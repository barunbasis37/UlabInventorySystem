using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ULABInventory.Model
{
    public class Garbaged : Entity
    {
        [Required(ErrorMessage = "Garbaged Id Required"), Key, Column(Order = 0), Index("IX_GarbagedId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Garbaged Id"), StringLength(20, ErrorMessage = "Garbaged Id cannot be longer than 30 characters.", MinimumLength = 1)]
        public string GarbagedId { get; set; }
        //public string CpuId { get; set; }
        //[ForeignKey("CpuId"), Column(Order = 2)]
        //public virtual CheckInDetail InDetails { get; set; }
        //[Required]
        //public string DeviceId { get; set; }
        //[ForeignKey("DeviceId"), Column(Order = 3)]
        //public virtual CheckInDetail CheckInDetail { get; set; }
        [Display(Name = "CPU Name")]
        //[ForeignKey("CheckInDetail"), Column(Order = 4)]
        [StringLength(150, ErrorMessage = "CPU Id cannot be longer than 150 characters.")]
        public string CpuId { get; set; }
        [Display(Name = "Device Name")]
        //[ForeignKey("CheckInDetail"), Column(Order = 5)]
        [StringLength(150, ErrorMessage = "Device Code cannot be longer than 150 characters.")]
        public string DeviceId { get; set; }
        //[ForeignKey("CpuId,DeviceId")]
        //public virtual CheckInDetail CheckInDetail { get; set; }
        [Required]
        public DateTime GarbagedDate { get; set; }
        [Required]
        [Display(Name = "Garbaged By")]
        public string GarbagedBy { get; set; }
        [ForeignKey("GarbagedBy"), Column(Order = 1)]
        public virtual Employee Employee { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Garbaged IP cannot be longer than 30 characters.", MinimumLength = 1)]
        [Display(Name = "Garbaged IP")]
        public string GarbagedIp { get; set; }
        [Required]
        [Display(Name = "Garbaged Entry Date")]
        public DateTime GarbagedEntryDate { get; set; }
    }
}