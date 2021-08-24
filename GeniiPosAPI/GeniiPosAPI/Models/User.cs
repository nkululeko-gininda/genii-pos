using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeniiPosAPI.Models
{
    public class User
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Column("Username")]
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Column("Password")]
        [StringLength(50)]
        [Required]
        public string Password { get; set; }

        [Column("FirstName")]
        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }
        
        [Column("LastName")]
        [StringLength(50)]
        [Required]
        public string LastName { get; set; }
        
        [Column("Email")]
        [StringLength(100)]
        [Required]
        public string Email { get; set; }
        
        [Column("IsActive")]
        [Required]
        public bool IsActive { get; set; }

        [ForeignKey("Role")]
        [Required]
        public int RoleId { get; set; }

        [Column("CreatedDate")]
        [Required]
        public DateTime CreatedDate { get; set; }


    }
}
