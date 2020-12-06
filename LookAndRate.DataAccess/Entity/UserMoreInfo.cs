using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LookAndRate.DataAccess.Entity
{
    [Table("tblUserMoreInfo")]
    public class UserMoreInfo
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int Age { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Review> reviewUser { get; set; }
        public virtual User User { get; set; }
    }
}
