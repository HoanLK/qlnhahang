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
    public class NhomThucDonAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/NhomThucDonAPI
        public IQueryable<NhomThucDon> GetNhomThucDons()
        {
            return db.NhomThucDons;
        }

        // GET: api/NhomThucDonAPI/5
        [ResponseType(typeof(NhomThucDon))]
        public IHttpActionResult GetNhomThucDon(int id)
        {
            NhomThucDon nhomThucDon = db.NhomThucDons.Find(id);
            if (nhomThucDon == null)
            {
                return NotFound();
            }

            return Ok(nhomThucDon);
        }

        // PUT: api/NhomThucDonAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhomThucDon(int id, NhomThucDon nhomThucDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhomThucDon.IDNhomThucDon)
            {
                return BadRequest();
            }

            db.Entry(nhomThucDon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhomThucDonExists(id))
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

        // POST: api/NhomThucDonAPI
        [ResponseType(typeof(NhomThucDon))]
        public IHttpActionResult PostNhomThucDon(NhomThucDon nhomThucDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhomThucDons.Add(nhomThucDon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nhomThucDon.IDNhomThucDon }, nhomThucDon);
        }

        // DELETE: api/NhomThucDonAPI/5
        [ResponseType(typeof(NhomThucDon))]
        public IHttpActionResult DeleteNhomThucDon(int id)
        {
            NhomThucDon nhomThucDon = db.NhomThucDons.Find(id);
            if (nhomThucDon == null)
            {
                return NotFound();
            }

            db.NhomThucDons.Remove(nhomThucDon);
            db.SaveChanges();

            return Ok(nhomThucDon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhomThucDonExists(int id)
        {
            return db.NhomThucDons.Count(e => e.IDNhomThucDon == id) > 0;
        }
    }
}