﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Test.Context
{
    public partial class User
    {
        public User()
        {
            Order = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string Name { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string Surname { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string UserName { get; set; }
        [StringLength(256)]
        [Unicode(false)]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public bool IsActive { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CreateDate { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Order> Order { get; set; }
    }
}