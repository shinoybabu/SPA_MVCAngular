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
    public class studentDetailsController : ApiController
    {
        private SchoolEntities1 db = new SchoolEntities1();

        // GET: api/studentDetails
        public IQueryable<studentDetail> GetstudentDetails()
        {
            return db.studentDetails;
        }

        // GET: api/studentDetails/5
        [ResponseType(typeof(studentDetail))]
        public IHttpActionResult GetstudentDetail(int id)
        {
            studentDetail studentDetail = db.studentDetails.Find(id);
            if (studentDetail == null)
            {
                return NotFound();
            }

            return Ok(studentDetail);
        }

        // PUT: api/studentDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutstudentDetail(int id, studentDetail studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != studentDetail.StudentDetailID)
            {
                return BadRequest();
            }

            db.Entry(studentDetail).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!studentDetailExists(id))
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

        // POST: api/studentDetails
        [ResponseType(typeof(studentDetail))]
        public IHttpActionResult PoststudentDetail(studentDetail studentDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.studentDetails.Add(studentDetail);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = studentDetail.StudentDetailID }, studentDetail);
        }

        // DELETE: api/studentDetails/5
        [ResponseType(typeof(studentDetail))]
        public IHttpActionResult DeletestudentDetail(int id)
        {
            studentDetail studentDetail = db.studentDetails.Find(id);
            if (studentDetail == null)
            {
                return NotFound();
            }

            db.studentDetails.Remove(studentDetail);
            db.SaveChanges();

            return Ok(studentDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool studentDetailExists(int id)
        {
            return db.studentDetails.Count(e => e.StudentDetailID == id) > 0;
        }
    }
}