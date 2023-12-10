using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Models
{
    public class Campus : Entity
    {
        [Required(ErrorMessage = "Campus Id Required"), Key, Column(Order = 0), Index("IX_CampusId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None),Display(Name = "Campus Id"), StringLength(10, ErrorMessage = "Campus Id cannot be longer than 10 characters.", MinimumLength = 1)]
        public string CampusId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.", MinimumLength = 1)]
        [Index("IX_Name", IsUnique = true)]
        [Display(Name = "Campus Name")]
        public string Name { get; set; }
        [Required, StringLength(100, ErrorMessage = "Address can be maximum 100 length"), DataType(DataType.Text)]
        public string Address { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Type can be maximum 30 length")]
        [Display(Name = "School Type")]
        public string Type { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDateTime { get; set; }
        public virtual ICollection<School> Schools { get; set; }

    }
}
