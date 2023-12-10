using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ULABInventory.Model
{
    public class ItemDetail : Entity
    {
        [Required(ErrorMessage = "Item Detail Id Required"), Key, Column(Order = 0), Index("IX_ItemDetailId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Item Detail Id"), StringLength(20, ErrorMessage = "Item Detail Id cannot be longer than 20 characters.", MinimumLength = 1)]
        public string ItemDetailId { get; set; }
        [Required]
        [Display(Name = "Item Name")]
        public string ItemId { get; set; }
        [ForeignKey("ItemId"), Column(Order = 1)]
        public virtual Item Item { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Model cannot be longer than 50 characters.", MinimumLength = 1)]
        [Index("IX_Model")]
        public string Model { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Size cannot be longer than 50 characters.", MinimumLength = 1)]
        [Index("IX_Size")]
        public string Size { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Brand cannot be longer than 50 characters.", MinimumLength = 1)]
        [Index("IX_Brand")]
        public string Brand { get; set; }
        [Required]
        public decimal Price { get; set; }
        [StringLength(500, ErrorMessage = "Details cannot be longer than 500 characters.")]
        [DataType(DataType.Text)]
        public string Details { get; set; }
    }
}