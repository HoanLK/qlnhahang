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
    public class ChiTietHoaDonNhapAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/ChiTietHoaDonNhapAPI
        public IQueryable<ChiTietHoaDonNhap> GetChiTietHoaDonNhaps()
        {
            return db.ChiTietHoaDonNhaps;
        }

        // GET: api/ChiTietHoaDonNhapAPI/5
        [ResponseType(typeof(ChiTietHoaDonNhap))]
        public IHttpActionResult GetChiTietHoaDonNhap(int id)
        {
            ChiTietHoaDonNhap chiTietHoaDonNhap = db.ChiTietHoaDonNhaps.Find(id);
            if (chiTietHoaDonNhap == null)
            {
                return NotFound();
            }

            return Ok(chiTietHoaDonNhap);
        }

        // PUT: api/ChiTietHoaDonNhapAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChiTietHoaDonNhap(int id, ChiTietHoaDonNhap chiTietHoaDonNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chiTietHoaDonNhap.IDChiTietHoaDonNhap)
            {
                return BadRequest();
            }

            db.Entry(chiTietHoaDonNhap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietHoaDonNhapExists(id))
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

        // POST: api/ChiTietHoaDonNhapAPI
        [ResponseType(typeof(ChiTietHoaDonNhap))]
        public IHttpActionResult PostChiTietHoaDonNhap(ChiTietHoaDonNhap chiTietHoaDonNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChiTietHoaDonNhaps.Add(chiTietHoaDonNhap);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chiTietHoaDonNhap.IDChiTietHoaDonNhap }, chiTietHoaDonNhap);
        }

        // DELETE: api/ChiTietHoaDonNhapAPI/5
        [ResponseType(typeof(ChiTietHoaDonNhap))]
        public IHttpActionResult DeleteChiTietHoaDonNhap(int id)
        {
            ChiTietHoaDonNhap chiTietHoaDonNhap = db.ChiTietHoaDonNhaps.Find(id);
            if (chiTietHoaDonNhap == null)
            {
                return NotFound();
            }

            db.ChiTietHoaDonNhaps.Remove(chiTietHoaDonNhap);
            db.SaveChanges();

            return Ok(chiTietHoaDonNhap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChiTietHoaDonNhapExists(int id)
        {
            return db.ChiTietHoaDonNhaps.Count(e => e.IDChiTietHoaDonNhap == id) > 0;
        }
    }
}