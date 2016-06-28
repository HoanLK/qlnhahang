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
    public class HoaDonXuatAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/HoaDonXuatAPI
        public IQueryable<HoaDonXuat> GetHoaDonXuats()
        {
            return db.HoaDonXuats;
        }

        // GET: api/HoaDonXuatAPI/5
        [ResponseType(typeof(HoaDonXuat))]
        public IHttpActionResult GetHoaDonXuat(int id)
        {
            HoaDonXuat hoaDonXuat = db.HoaDonXuats.Find(id);
            if (hoaDonXuat == null)
            {
                return NotFound();
            }

            return Ok(hoaDonXuat);
        }

        // PUT: api/HoaDonXuatAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHoaDonXuat(int id, HoaDonXuat hoaDonXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hoaDonXuat.IDHoaDonXuat)
            {
                return BadRequest();
            }

            db.Entry(hoaDonXuat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HoaDonXuatExists(id))
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

        // POST: api/HoaDonXuatAPI
        [ResponseType(typeof(HoaDonXuat))]
        public IHttpActionResult PostHoaDonXuat(HoaDonXuat hoaDonXuat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HoaDonXuats.Add(hoaDonXuat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hoaDonXuat.IDHoaDonXuat }, hoaDonXuat);
        }

        // DELETE: api/HoaDonXuatAPI/5
        [ResponseType(typeof(HoaDonXuat))]
        public IHttpActionResult DeleteHoaDonXuat(int id)
        {
            HoaDonXuat hoaDonXuat = db.HoaDonXuats.Find(id);
            if (hoaDonXuat == null)
            {
                return NotFound();
            }

            db.HoaDonXuats.Remove(hoaDonXuat);
            db.SaveChanges();

            return Ok(hoaDonXuat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HoaDonXuatExists(int id)
        {
            return db.HoaDonXuats.Count(e => e.IDHoaDonXuat == id) > 0;
        }
    }
}