using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ULABInventory.Models
{
    public class CheckIn : Entity
    {
        [Required(ErrorMessage = "CheckIn Id Required"), Key, Column(Order = 0), Index("IX_CheckInId")]
        [DatabaseGenerated(DatabaseGeneratedOption.None), Display(Name = "CheckIn Id"), StringLength(20, ErrorMessage = "CheckIn Id cannot be longer than 20 characters.", MinimumLength = 1)]
        public string CheckInId { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryId { get; set; }
        [ForeignKey("CategoryId"), Column(Order = 1)]
        public virtual Category Category { get; set; }
        [StringLength(150, ErrorMessage = "Invoice No cannot be longer than 150 characters.")]
        [Display(Name = "Invoice No")]
        public string InvoiceNo { get; set; }
        [Display(Name = "Supplier Name")]
        public string SupplierId { get; set; }
        [ForeignKey("SupplierId"), Column(Order = 1)]
        public virtual Supplier Supplier { get; set; }
        [Required]
        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }
        [Required]
        [Column(TypeName = "Money")]
        [Display(Name = "Product Price")]
        public decimal TotalBillAmount { get; set; }
        [StringLength(150, ErrorMessage = "Comment cannot be longer than 150 characters.")]
        public string Comment { get; set; }
        //[Required]
        //[StringLength(20, ErrorMessage = "Purchase By cannot be longer than 20 characters.")]
        //[Display(Name = "Purchase By")]
        //public string PurchaseBy { get; set; }
        [Required, StringLength(100, ErrorMessage = "Receipt No cannot be longer than 100 characters.")]
        [Display(Name = "Receipt No")]
        public string ReceiptNo { get; set; }
        public virtual ICollection<CheckInDetails> CheckInDetails { get; set; }


    }
}
