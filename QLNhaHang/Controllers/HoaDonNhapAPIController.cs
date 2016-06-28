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
    public class HoaDonNhapAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/HoaDonNhapAPI
        public IQueryable<HoaDonNhap> GetHoaDonNhaps()
        {
            return db.HoaDonNhaps;
        }

        // GET: api/HoaDonNhapAPI/5
        [ResponseType(typeof(HoaDonNhap))]
        public IHttpActionResult GetHoaDonNhap(int id)
        {
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            if (hoaDonNhap == null)
            {
                return NotFound();
            }

            return Ok(hoaDonNhap);
        }

        // PUT: api/HoaDonNhapAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHoaDonNhap(int id, HoaDonNhap hoaDonNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hoaDonNhap.IDHoaDonNhap)
            {
                return BadRequest();
            }

            db.Entry(hoaDonNhap).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoaDonNhapExists(id))
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

        // POST: api/HoaDonNhapAPI
        [ResponseType(typeof(HoaDonNhap))]
        public IHttpActionResult PostHoaDonNhap(HoaDonNhap hoaDonNhap)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HoaDonNhaps.Add(hoaDonNhap);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hoaDonNhap.IDHoaDonNhap }, hoaDonNhap);
        }

        // DELETE: api/HoaDonNhapAPI/5
        [ResponseType(typeof(HoaDonNhap))]
        public IHttpActionResult DeleteHoaDonNhap(int id)
        {
            HoaDonNhap hoaDonNhap = db.HoaDonNhaps.Find(id);
            if (hoaDonNhap == null)
            {
                return NotFound();
            }

            db.HoaDonNhaps.Remove(hoaDonNhap);
            db.SaveChanges();

            return Ok(hoaDonNhap);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HoaDonNhapExists(int id)
        {
            return db.HoaDonNhaps.Count(e => e.IDHoaDonNhap == id) > 0;
        }
    }
}