﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinist.Models.Entity
{
    public class User:IdentityUser
    {
        public decimal Balance { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
