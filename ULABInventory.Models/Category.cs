using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;


namespace ULABInventory.Models
{
    public class Category : Entity
    {
        [Required(ErrorMessage = "Category Id Required"), Key, Column(Order = 0), Index("IX_CategoryId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "Category Id"), StringLength(10, ErrorMessage = "Category Id cannot be longer than 10 characters.", MinimumLength = 1)]
        public string CategoryId { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Category Name can be maximum 100 length", MinimumLength = 1)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Priority Level")]
        public int Priority { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Description can be maximum 100 length",MinimumLength = 1)]
        [DataType(DataType.Text)]
        public string Description { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }

    }
}
