using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinist.Models.Entity
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }
        public string BookName { get; set; }
        public int BookId { get; set; }
        public int Price { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
        [ForeignKey("CustomerId")]
        public virtual User User { get; set; }
    }
}
