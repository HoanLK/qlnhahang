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
using QLNhaHang.Models;

namespace QLNhaHang.Controllers
{
    public class MatHangAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/MatHangAPI
        public IQueryable<MatHang> GetMatHangs()
        {
            return db.MatHangs;
        }

        // GET: api/MatHangAPI/5
        [ResponseType(typeof(MatHang))]
        public IHttpActionResult GetMatHang(int id)
        {
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return NotFound();
            }

            return Ok(matHang);
        }

        // PUT: api/MatHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMatHang(int id, MatHang matHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != matHang.IDMatHang)
            {
                return BadRequest();
            }

            db.Entry(matHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MatHangExists(id))
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

        // POST: api/MatHangAPI
        [ResponseType(typeof(MatHang))]
        public IHttpActionResult PostMatHang(MatHang matHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MatHangs.Add(matHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = matHang.IDMatHang }, matHang);
        }

        // DELETE: api/MatHangAPI/5
        [ResponseType(typeof(MatHang))]
        public IHttpActionResult DeleteMatHang(int id)
        {
            MatHang matHang = db.MatHangs.Find(id);
            if (matHang == null)
            {
                return NotFound();
            }

            db.MatHangs.Remove(matHang);
            db.SaveChanges();

            return Ok(matHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MatHangExists(int id)
        {
            return db.MatHangs.Count(e => e.IDMatHang == id) > 0;
        }
    }
}