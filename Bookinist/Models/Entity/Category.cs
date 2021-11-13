using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinist.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
