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
    public class NhomMatHangAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/NhomMatHangAPI
        public IQueryable<NhomMatHang> GetNhomMatHangs()
        {
            return db.NhomMatHangs;
        }

        // GET: api/NhomMatHangAPI/5
        [ResponseType(typeof(NhomMatHang))]
        public IHttpActionResult GetNhomMatHang(int id)
        {
            NhomMatHang nhomMatHang = db.NhomMatHangs.Find(id);
            if (nhomMatHang == null)
            {
                return NotFound();
            }

            return Ok(nhomMatHang);
        }

        // PUT: api/NhomMatHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhomMatHang(int id, NhomMatHang nhomMatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhomMatHang.IDNhomMatHang)
            {
                return BadRequest();
            }

            db.Entry(nhomMatHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhomMatHangExists(id))
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

        // POST: api/NhomMatHangAPI
        [ResponseType(typeof(NhomMatHang))]
        public IHttpActionResult PostNhomMatHang(NhomMatHang nhomMatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhomMatHangs.Add(nhomMatHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nhomMatHang.IDNhomMatHang }, nhomMatHang);
        }

        // DELETE: api/NhomMatHangAPI/5
        [ResponseType(typeof(NhomMatHang))]
        public IHttpActionResult DeleteNhomMatHang(int id)
        {
            NhomMatHang nhomMatHang = db.NhomMatHangs.Find(id);
            if (nhomMatHang == null)
            {
                return NotFound();
            }

            db.NhomMatHangs.Remove(nhomMatHang);
            db.SaveChanges();

            return Ok(nhomMatHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhomMatHangExists(int id)
        {
            return db.NhomMatHangs.Count(e => e.IDNhomMatHang == id) > 0;
        }
    }
}