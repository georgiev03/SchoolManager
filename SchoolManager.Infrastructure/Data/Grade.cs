﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManager.Infrastructure.Data
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public double Mark { get; set; }


        [Required]
        [ForeignKey(nameof(Student))]
        public Guid StudentId { get; set; }
        public Student Student { get; set; }
    }
}
