using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Model
{
    public class IssueType : Entity
    {
        [Required(ErrorMessage = "Issue Type Required"), Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Display(Name = "Issue Type Id")]
        public int IssueTypeID { get; set; }
        [StringLength(100, ErrorMessage = "Issue Type Name cannot be longer than 100 characters.", MinimumLength = 1)]
        [Index("IX_ReturnRemark", IsUnique = true)]
        [Display(Name = "Issue Type Name")]
        public string Name { get; set; }
        public int Priority { get; set; }

    }
}
