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
    public class NhomNhanVienAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/NhomNhanVienAPI
        public IQueryable<NhomNhanVien> GetNhomNhanViens()
        {
            return db.NhomNhanViens;
        }

        // GET: api/NhomNhanVienAPI/5
        [ResponseType(typeof(NhomNhanVien))]
        public IHttpActionResult GetNhomNhanVien(int id)
        {
            NhomNhanVien nhomNhanVien = db.NhomNhanViens.Find(id);
            if (nhomNhanVien == null)
            {
                return NotFound();
            }

            return Ok(nhomNhanVien);
        }

        // PUT: api/NhomNhanVienAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhomNhanVien(int id, NhomNhanVien nhomNhanVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhomNhanVien.IDNhomNhanVien)
            {
                return BadRequest();
            }

            db.Entry(nhomNhanVien).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhomNhanVienExists(id))
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

        // POST: api/NhomNhanVienAPI
        [ResponseType(typeof(NhomNhanVien))]
        public IHttpActionResult PostNhomNhanVien(NhomNhanVien nhomNhanVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhomNhanViens.Add(nhomNhanVien);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nhomNhanVien.IDNhomNhanVien }, nhomNhanVien);
        }

        // DELETE: api/NhomNhanVienAPI/5
        [ResponseType(typeof(NhomNhanVien))]
        public IHttpActionResult DeleteNhomNhanVien(int id)
        {
            NhomNhanVien nhomNhanVien = db.NhomNhanViens.Find(id);
            if (nhomNhanVien == null)
            {
                return NotFound();
            }

            db.NhomNhanViens.Remove(nhomNhanVien);
            db.SaveChanges();

            return Ok(nhomNhanVien);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhomNhanVienExists(int id)
        {
            return db.NhomNhanViens.Count(e => e.IDNhomNhanVien == id) > 0;
        }
    }
}