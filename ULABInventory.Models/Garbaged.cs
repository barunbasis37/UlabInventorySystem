using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Models
{
    public class Garbaged : Entity
    {
        [Required(ErrorMessage = "Garbaged Id Required"), Key, Column(Order = 0), Index("IX_GarbagedId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Garbaged Id"), StringLength(20, ErrorMessage = "Garbaged Id cannot be longer than 30 characters.", MinimumLength = 1)]
        public string GarbagedId { get; set; }
        public string CpuId { get; set; }
        [ForeignKey("CpuId"), Column(Order = 2)]
        public virtual CheckInDetails InDetails { get; set; }
        [Required]
        public string DeviceId { get; set; }
        [ForeignKey("DeviceId"), Column(Order = 3)]
        public virtual CheckInDetails CheckInDetails { get; set; }
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
