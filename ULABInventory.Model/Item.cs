using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ULABInventory.Model
{
    public class Item : Entity
    {
        [Required(ErrorMessage = "Item Id Required"), Key, Column(Order = 0), Index("IX_ItemId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Item Id"), StringLength(20, ErrorMessage = "Item Id cannot be longer than 20 characters.", MinimumLength = 1)]
        public string ItemId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.", MinimumLength = 1)]
        [Index("IX_Name", IsUnique = true)]
        [Display(Name = "Item Name")]
        public string Name { get; set; }
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        [Required]
        public int Priority { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string CategoryId { get; set; }
        [ForeignKey("CategoryId"), Column(Order = 1)]
        public virtual Category Category { get; set; }
        [Required]
        [Display(Name = "SubCategory Name")]
        public string SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId"), Column(Order = 1)]
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<ItemDetail> ItemDetail { get; set; }
    }
}