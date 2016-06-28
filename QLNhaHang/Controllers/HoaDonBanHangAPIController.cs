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
    public class HoaDonBanHangAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/HoaDonBanHangAPI
        public IQueryable<HoaDonBanHang> GetHoaDonBanHangs()
        {
            return db.HoaDonBanHangs;
        }

        // GET: api/HoaDonBanHangAPI/5
        [ResponseType(typeof(HoaDonBanHang))]
        public IHttpActionResult GetHoaDonBanHang(int id)
        {
            HoaDonBanHang hoaDonBanHang = db.HoaDonBanHangs.Find(id);
            if (hoaDonBanHang == null)
            {
                return NotFound();
            }

            return Ok(hoaDonBanHang);
        }

        // PUT: api/HoaDonBanHangAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHoaDonBanHang(int id, HoaDonBanHang hoaDonBanHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hoaDonBanHang.IDHoaDonBanHang)
            {
                return BadRequest();
            }

            db.Entry(hoaDonBanHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoaDonBanHangExists(id))
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

        // POST: api/HoaDonBanHangAPI
        [ResponseType(typeof(HoaDonBanHang))]
        public IHttpActionResult PostHoaDonBanHang(HoaDonBanHang hoaDonBanHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HoaDonBanHangs.Add(hoaDonBanHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hoaDonBanHang.IDHoaDonBanHang }, hoaDonBanHang);
        }

        // DELETE: api/HoaDonBanHangAPI/5
        [ResponseType(typeof(HoaDonBanHang))]
        public IHttpActionResult DeleteHoaDonBanHang(int id)
        {
            HoaDonBanHang hoaDonBanHang = db.HoaDonBanHangs.Find(id);
            if (hoaDonBanHang == null)
            {
                return NotFound();
            }

            db.HoaDonBanHangs.Remove(hoaDonBanHang);
            db.SaveChanges();

            return Ok(hoaDonBanHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HoaDonBanHangExists(int id)
        {
            return db.HoaDonBanHangs.Count(e => e.IDHoaDonBanHang == id) > 0;
        }
    }
}