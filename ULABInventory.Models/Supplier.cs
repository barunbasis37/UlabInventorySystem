using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Models
{
    public class Supplier :Entity
    {
        [Required(ErrorMessage = "Supplier Id Required"), Key, Column(Order = 0), Index("IX_SupplierId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Supplier Id"), StringLength(20, ErrorMessage = "Supplier Id cannot be longer than 20 characters.", MinimumLength = 1)]
        public string SupplierId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 100 characters.", MinimumLength = 1)]
        public string Name { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.", MinimumLength = 1)]
        public string Address { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        public int Priority { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryId { get; set; }
        [ForeignKey("CategoryId"),Column(Order = 1)]
        public virtual Category Category { get; set; }
    }
}
