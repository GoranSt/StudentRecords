namespace StudentRecords.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentRecords.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<StudentRecords.Models.StudentRecordsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
           
        }

        protected override void Seed(StudentRecords.Models.StudentRecordsContext context)
        {
            //  This method will be called after migrating to the latest version.

         


            context.Students.AddOrUpdate(x => x.Id,
       new Student() { Id = 1, Name = "Maria Petrova" },
       new Student() { Id = 2, Name = "Robert Watson" },
       new Student() { Id = 3, Name = "Bruce Willis" },
        new Student() { Id = 4, Name = "John Snow" },
         new Student() { Id = 5, Name = "Olivia Wilde" }
       );

            context.Subjects.AddOrUpdate(x => x.Id,
                new Subject()
                {
                    Id = 1,
                    Title = "Visual programming",
                    Credits = 6,
                    Difficulty = "Normal",
                    Semestar = 3,
                    Description = "The student will attain knowledge of software development techniques by using modern objectoriented programming language in advanced integrated development environment, designing user interfaces and software debugging.",
                    StudentId = 1,
                   
                },
                new Subject()
                {
                    Id = 2,
                    Title = "Structured programming",       
                    Credits = 8,
                    Difficulty = "Easy",
                    Semestar = 1,
                    Description = "To introduce the students to the Structured programming paradigm, to understand the concept of algorithms and to enable them to develop algorithms, to code, test and compile programs. There will be introduction of data types, control structures, functions, arrays and files.",

                    StudentId = 1,
                },

                  new Subject()
                  {
                      Id = 2,
                      Title = "Object-oriented programming",
                      Credits = 8,
                      Difficulty = "Normal",
                      Semestar = 2,
                      Description = "The goal of the course is to acquaint the student with the basic concepts of object-oriented programming. Therefore, the concepts of classes and objects will be introduced, encapsulation, inheritance and polymorphism.",

                      StudentId = 5,
                  },
                    new Subject()
                    {
                        Id = 2,
                        Title = "Discrete Mathematics",
                        Credits = 7,
                        Difficulty = "Normal",
                        Semestar = 1,
                        Description = "To introduce students to basic elements of discrete mathematics as a foundation of computer sciences and new technologies. In this context students should learn how to apply the formal methods of propositional and predicate logic in modeling situations from real life including those in the field of computer sciences.",

                        StudentId = 2,
                    },
                      new Subject()
                      {
                          Id = 2,
                          Title = "Web programming",
                          Credits = 4,
                          Difficulty = "Normal",
                          Semestar = 5,
                          Description = "Development of advanced server based web applications based on templates. Development of cloud based web applications.",

                          StudentId = 3,
                      },
                        new Subject()
                        {
                            Id = 2,
                            Title = "Internet programming",
                            Credits = 6,
                            Difficulty = "Easy",
                            Semestar = 3,
                            Description = "To learn the mechanisms in the HTTP protocol. Learns to use platforms for developing web applications. To create and develop web applications. To develop and use web services",

                            StudentId = 4,
                        }

                );



        }
    }
}
