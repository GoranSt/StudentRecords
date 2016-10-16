using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentRecords.Models
{
    public class SubjectDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StudentName { get; set; }


        // aditinal added
        public string Description { get; set; }

        public int Semestar { get; set; }

        public string Difficulty { get; set; }
        // ends here
    }
}