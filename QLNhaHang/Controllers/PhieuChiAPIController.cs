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
    public class PhieuChiAPIController : ApiController
    {
        private DBQLNhaHang db = new DBQLNhaHang();

        // GET: api/PhieuChiAPI
        public IQueryable<PhieuChi> GetPhieuChis()
        {
            return db.PhieuChis;
        }

        // GET: api/PhieuChiAPI/5
        [ResponseType(typeof(PhieuChi))]
        public IHttpActionResult GetPhieuChi(int id)
        {
            PhieuChi phieuChi = db.PhieuChis.Find(id);
            if (phieuChi == null)
            {
                return NotFound();
            }

            return Ok(phieuChi);
        }

        // PUT: api/PhieuChiAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPhieuChi(int id, PhieuChi phieuChi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != phieuChi.IDPhieuChi)
            {
                return BadRequest();
            }

            db.Entry(phieuChi).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhieuChiExists(id))
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

        // POST: api/PhieuChiAPI
        [ResponseType(typeof(PhieuChi))]
        public IHttpActionResult PostPhieuChi(PhieuChi phieuChi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PhieuChis.Add(phieuChi);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = phieuChi.IDPhieuChi }, phieuChi);
        }

        // DELETE: api/PhieuChiAPI/5
        [ResponseType(typeof(PhieuChi))]
        public IHttpActionResult DeletePhieuChi(int id)
        {
            PhieuChi phieuChi = db.PhieuChis.Find(id);
            if (phieuChi == null)
            {
                return NotFound();
            }

            db.PhieuChis.Remove(phieuChi);
            db.SaveChanges();

            return Ok(phieuChi);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PhieuChiExists(int id)
        {
            return db.PhieuChis.Count(e => e.IDPhieuChi == id) > 0;
        }
    }
}