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
    public class NhanVienAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/NhanVienAPI
        public IQueryable<NhanVien> GetNhanViens()
        {
            return db.NhanViens;
        }

        // GET: api/NhanVienAPI/5
        [ResponseType(typeof(NhanVien))]
        public IHttpActionResult GetNhanVien(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            return Ok(nhanVien);
        }

        // PUT: api/NhanVienAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhanVien(int id, NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhanVien.IDNhanVien)
            {
                return BadRequest();
            }

            db.Entry(nhanVien).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVienExists(id))
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

        // POST: api/NhanVienAPI
        [ResponseType(typeof(NhanVien))]
        public IHttpActionResult PostNhanVien(NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhanViens.Add(nhanVien);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nhanVien.IDNhanVien }, nhanVien);
        }

        // DELETE: api/NhanVienAPI/5
        [ResponseType(typeof(NhanVien))]
        public IHttpActionResult DeleteNhanVien(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();

            return Ok(nhanVien);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhanVienExists(int id)
        {
            return db.NhanViens.Count(e => e.IDNhanVien == id) > 0;
        }
    }
}