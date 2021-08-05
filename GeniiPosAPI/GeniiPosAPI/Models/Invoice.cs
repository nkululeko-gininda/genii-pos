using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeniiPosAPI.Models
{
    public class Invoice
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }


        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [ForeignKey("Status")]
        [Required]
        public int StatusId { get; set;}
        public virtual InvoiceStatus InvoiceStatus { get; set; }

        [Column("Total")]
        [Required]
        public double Total { get; set; }

        [Column("CreatedDate")]
        [Required]
        public DateTime CreatedDate { get; set; }


    }
}
