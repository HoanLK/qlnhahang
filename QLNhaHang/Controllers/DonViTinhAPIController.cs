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
    public class DonViTinhAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/DonViTinhAPI
        public IQueryable<DonViTinh> GetDonViTinhs()
        {
            return db.DonViTinhs;
        }

        // GET: api/DonViTinhAPI/5
        [ResponseType(typeof(DonViTinh))]
        public IHttpActionResult GetDonViTinh(int id)
        {
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            if (donViTinh == null)
            {
                return NotFound();
            }

            return Ok(donViTinh);
        }

        // PUT: api/DonViTinhAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonViTinh(int id, DonViTinh donViTinh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donViTinh.IDDonViTinh)
            {
                return BadRequest();
            }

            db.Entry(donViTinh).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonViTinhExists(id))
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

        // POST: api/DonViTinhAPI
        [ResponseType(typeof(DonViTinh))]
        public IHttpActionResult PostDonViTinh(DonViTinh donViTinh)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DonViTinhs.Add(donViTinh);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donViTinh.IDDonViTinh }, donViTinh);
        }

        // DELETE: api/DonViTinhAPI/5
        [ResponseType(typeof(DonViTinh))]
        public IHttpActionResult DeleteDonViTinh(int id)
        {
            DonViTinh donViTinh = db.DonViTinhs.Find(id);
            if (donViTinh == null)
            {
                return NotFound();
            }

            db.DonViTinhs.Remove(donViTinh);
            db.SaveChanges();

            return Ok(donViTinh);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonViTinhExists(int id)
        {
            return db.DonViTinhs.Count(e => e.IDDonViTinh == id) > 0;
        }
    }
}