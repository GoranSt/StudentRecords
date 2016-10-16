using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecords.Models
{
    public class Subject
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        
        public decimal Credits { get; set; }



        //additional
        public string Description { get; set; }

        public int Semestar { get; set; }

        public string Difficulty { get; set; }
        // ends here

        // Foreign key
        public int StudentId { get; set; }
        // Navigation property
        public Student Student { get; set; }


    



    }
}