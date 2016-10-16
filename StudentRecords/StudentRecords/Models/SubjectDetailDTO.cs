using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRecords.Models
{
    public class SubjectDetailDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Credits { get; set; }
        public string StudentName { get; set; }


        // aditional
        public string Description { get; set; }

        public int Semestar { get; set; }

        public string Difficulty { get; set; }


        // ends here

    }
}