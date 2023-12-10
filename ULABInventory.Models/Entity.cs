using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Models
{
    public class Entity
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(Order = 0)]
        //public int SN { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Column(Order = 1),Index(IsUnique = true)]
        public Guid QueryId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Posted By")]
        public string PostedBy { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Posted IP")]
        public string PostedIp { get; set; }
        [Required]
        [Display(Name = "Posted Date")]
        public DateTime PostedDate { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Updated By")]
        public string UpdatedBy { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Updated IP")]
        public string UpdatedIp { get; set; }
        [Required]
        [Display(Name = "Updated Date")]
        public DateTime UpdatedDate { get; set; }
    }
}
