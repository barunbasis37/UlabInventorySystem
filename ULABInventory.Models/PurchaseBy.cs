using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Models
{
    public class PurchaseBy : Entity
    {
        [Required(ErrorMessage = "Purchase By Required"), Key, Column(Order = 0), Index("IX_PurchaseById")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Purchase By"), StringLength(20, ErrorMessage = "Purchase By cannot be longer than 20 characters.", MinimumLength = 1)]
        public string PurchaseById { get; set; }
        [StringLength(150, ErrorMessage = "Name cannot be longer than 150 characters.")]
        [Display(Name = "Purchase By")]
        public string Name { get; set; }
        [StringLength(150, ErrorMessage = "Description cannot be longer than 150 characters.")]
        public string Description { get; set; }
        [Required]
        public int Priority { get; set; }
        
    }
}
