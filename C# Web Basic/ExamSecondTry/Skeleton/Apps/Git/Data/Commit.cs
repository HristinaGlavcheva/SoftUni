﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Git.Data
{
    public class Commit
    {
        public Commit()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        [ForeignKey("User")]
        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        [ForeignKey("Repository")]
        public string RepositoryId { get; set; }

        public virtual Repository Repository { get; set; }
    }
}
