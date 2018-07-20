﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoIdentity.Entities.Core
{
    [Table(name: "trUser", Schema = "Core")]
    public class User : Entity
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public string MobileNumber { get; set; }

        public Guid UniqueId { get; set; }
        public string JsonFeed { get; set; }

        public bool IsLocked { get; set; }
    }
}
