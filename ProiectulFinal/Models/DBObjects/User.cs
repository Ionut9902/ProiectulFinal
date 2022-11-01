﻿using System;
using System.Collections.Generic;

namespace ProiectulFinal.Models.DBObjects
{
    public partial class User
    {
        public User()
        {
            Messages = new HashSet<Message>();
            Posts = new HashSet<Post>();
        }

        public Guid IdUser { get; set; }
        public string Name { get; set; } = null!;
        public string YearOfBirth { get; set; } = null!;
        public string? NumberOfPosts { get; set; }
        public string FirstRegistered { get; set; } = null!;
        public string Id { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
