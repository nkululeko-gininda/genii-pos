using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeniiPosAPI.Models
{
    public class Product
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("Name")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        
        [Column("Stock")]
        [Required]
        public int Stock { get; set; }

        [Column("Price")]
        [Required]
        public double Price { get; set; }

        [Column("IsActive")]
        [Required]
        public bool IsActive { get; set; }

        [Column("CreatedDate")]
        [Required]
        public DateTime CreatedDate { get; set; }

    }
}
