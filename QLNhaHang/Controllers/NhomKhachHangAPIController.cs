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
    public class NhomKhachHangAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/NhomKhachHangAPI
        public IQueryable<NhomKhachHang> GetNhomKhachHangs()
        {
            return db.NhomKhachHangs;
        }

        // GET: api/NhomKhachHangAPI/5
        [ResponseType(typeof(NhomKhachHang))]
        public IHttpActionResult GetNhomKhachHang(int id)
        {
            NhomKhachHang nhomKhachHang = db.NhomKhachHangs.Find(id);
            if (nhomKhachHang == null)
            {
                return NotFound();
            }

            return Ok(nhomKhachHang);
        }

        // PUT: api/NhomKhachHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhomKhachHang(int id, NhomKhachHang nhomKhachHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhomKhachHang.IDNhomKhachHang)
            {
                return BadRequest();
            }

            db.Entry(nhomKhachHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhomKhachHangExists(id))
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

        // POST: api/NhomKhachHangAPI
        [ResponseType(typeof(NhomKhachHang))]
        public IHttpActionResult PostNhomKhachHang(NhomKhachHang nhomKhachHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhomKhachHangs.Add(nhomKhachHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nhomKhachHang.IDNhomKhachHang }, nhomKhachHang);
        }

        // DELETE: api/NhomKhachHangAPI/5
        [ResponseType(typeof(NhomKhachHang))]
        public IHttpActionResult DeleteNhomKhachHang(int id)
        {
            NhomKhachHang nhomKhachHang = db.NhomKhachHangs.Find(id);
            if (nhomKhachHang == null)
            {
                return NotFound();
            }

            db.NhomKhachHangs.Remove(nhomKhachHang);
            db.SaveChanges();

            return Ok(nhomKhachHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhomKhachHangExists(int id)
        {
            return db.NhomKhachHangs.Count(e => e.IDNhomKhachHang == id) > 0;
        }
    }
}