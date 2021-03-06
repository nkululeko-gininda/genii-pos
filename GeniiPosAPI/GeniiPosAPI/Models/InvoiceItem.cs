using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeniiPosAPI.Models
{
    public class InvoiceItem
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Invoice")]
        [Required]
        public int InvoiceId { get; set; }
        
        [ForeignKey("Product")]
        [Required]
        public int ProductId { get; set; }

        [Column("Quantity")]
        [Required]
        public int Quantity { get; set; }

        [Column("CreatedDate")]
        [Required]
        public DateTime CreatedDate { get; set; }


    }
}
