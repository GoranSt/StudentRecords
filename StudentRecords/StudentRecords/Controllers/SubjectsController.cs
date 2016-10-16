using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using StudentRecords.Models;

namespace StudentRecords.Controllers
{
    public class SubjectsController : ApiController
    {
        private StudentRecordsContext db = new StudentRecordsContext();


        [Route("api/Subjects/search/{strSearch}")]
        public IQueryable<SubjectDTO> GetSubjects(string strSearch)
        {

          var subjects = from s in db.Subjects where s.Title.Contains(strSearch)
                           select new SubjectDTO()
                           {
                               Id = s.Id,
                               Title = s.Title,
                               StudentName = s.Student.Name,
                               Description = s.Description,
                               Semestar = s.Semestar,
                               Difficulty = s.Difficulty


                           };
        return subjects;

  }



        // GET: api/Subjects
        public IQueryable<SubjectDTO> GetSubjects()
        {

            var subjects = from s in db.Subjects
                           select new SubjectDTO()
                           {
                               Id = s.Id,
                               Title = s.Title,
                               StudentName = s.Student.Name,
                               Description = s.Description,
                              Semestar = s.Semestar,
                              Difficulty = s.Difficulty


                           };


           return subjects;
          
             
               
        }

        // GET: api/Subjects/5
        [ResponseType(typeof(SubjectDetailDTO))]
        public async Task<IHttpActionResult> GetSubject(int id)
        {

            var subject = await db.Subjects.Include(s => s.Student).Select(s => new SubjectDetailDTO()
            {

                Id = s.Id,
                Title = s.Title,
                Credits = s.Credits,
                Semestar = s.Semestar,
                Difficulty = s.Difficulty,
                Description = s.Description,
                StudentName = s.Student.Name


            }).SingleOrDefaultAsync(s => s.Id == id);

            if(subject == null)
            {
                return NotFound();

            }
            return Ok(subject);


            //Subject subject = await db.Subjects.FindAsync(id);
            //if (subject == null)
            //{
            //    return NotFound();
            //}

            //return Ok(subject);
        }

        // PUT: api/Subjects/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSubject(int id, Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subject.Id)
            {
                return BadRequest();
            }

            db.Entry(subject).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Subjects
        [ResponseType(typeof(Subject))]
        public async Task<IHttpActionResult> PostSubject(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subjects.Add(subject);
            await db.SaveChangesAsync();




            // new code
            db.Entry(subject).Reference(x => x.Student).Load();

            var dto = new SubjectDTO()
            {
                Id = subject.Id,
                Title = subject.Title,
                StudentName = subject.Student.Name


            };

            return CreatedAtRoute("DefaultApi", new { id = subject.Id }, dto);
            //return CreatedAtRoute("DefaultApi", new { id = subject.Id }, subject);
        }

        // DELETE: api/Subjects/5
        [ResponseType(typeof(Subject))]
        public async Task<IHttpActionResult> DeleteSubject(int id)
        {
            Subject subject = await db.Subjects.FindAsync(id);
            if (subject == null)
            {
                return NotFound();
            }

            db.Subjects.Remove(subject);
            await db.SaveChangesAsync();

            return Ok(subject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectExists(int id)
        {
            return db.Subjects.Count(e => e.Id == id) > 0;
        }
    }
}