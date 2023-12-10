using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ULABInventory.Model
{
    public class SubCategory : Entity
    {
        [Required(ErrorMessage = "Subcategory Id Required"), Key, Column(Order = 0), Index("IX_SubcategoryId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Subcategory Id"), StringLength(20, ErrorMessage = "Subcategory Id cannot be longer than 20 characters.", MinimumLength = 1)]
        public string SubCategoryId { get; set; }
        [StringLength(150, ErrorMessage = "Name can be maximum 150 length")]
        [Display(Name = "Sub-category Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Priority Level")]
        public int Priority { get; set; }
        //[Required]
        //[StringLength(100, ErrorMessage = "Description can be maximum 100 length")]
        ////[DataType(DataType.Text)]
        //public string Description { get; set; }
        [StringLength(100, ErrorMessage = "Description can be maximum 100 length")]
        public string SubCatDescription { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryId { get; set; }
        [ForeignKey("CategoryId"), Column(Order = 3)]
        public virtual Category Category { get; set; }
    }
}