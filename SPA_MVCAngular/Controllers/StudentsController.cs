using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SPA_MVCAngular.Models;

namespace SPA_MVCAngular.Controllers
{
    public class StudentsController : ApiController
    {
        private SchoolEntities1 db = new SchoolEntities1();

        // GET: api/Students
        public IQueryable<Student> Get()
        {
            return db.Students;
        }

        // POST: api/Students
        public HttpResponseMessage Post([FromBody]Student student)
        {
            HttpResponseMessage msg = null;
            if (!ModelState.IsValid)
            {
                msg = Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid model");
            }
            else
            {
                db.Students.Add(student);
                db.SaveChanges();
                msg = Request.CreateResponse(HttpStatusCode.Created);
                msg.Headers.Location = new Uri(Request.RequestUri + student.ID.ToString());
            }
            return msg;
        }

        // GET: api/Students/5
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage msg = null;
            Student student = db.Students
                .Where(s => s.ID == id)
                .Include(ed => ed.studentDetails).FirstOrDefault();

            //db.Students.Find(id);
            if (student == null)
            {
                msg= Request.CreateErrorResponse(HttpStatusCode.NotFound, "Student not found");
            }
            else{
                msg= Request.CreateResponse(HttpStatusCode.OK,student);
            }
            return msg;
        }


        // PUT: api/Students/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStudent(int id, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.ID)
            {
                return BadRequest();
            }

            db.Entry(student).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // DELETE: api/Students/5
        [ResponseType(typeof(Student))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return NotFound();
            }

            db.Students.Remove(student);
            db.SaveChanges();

            return Ok(student);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StudentExists(int id)
        {
            return db.Students.Count(e => e.ID == id) > 0;
        }
    }
}