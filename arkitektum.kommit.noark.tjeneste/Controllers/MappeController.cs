using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using arkitektum.kommit.noark.tjeneste.Models.Arkivstruktur;
using arkitektum.kommit.noark.tjeneste.Models.arkitektum.kommit.noark;

namespace arkitektum.kommit.noark.tjeneste.Controllers
{
    public class MappeController : ApiController
    {
        private tjenesteContext db = new tjenesteContext();

        // GET api/Mappe
        public IEnumerable<Mappe> GetMappes()
        {
            //Rettinghetsstyring...og alle andre restriksjoner
            return db.Mappes.AsEnumerable();
        }

        // GET api/Mappe/5
        public Mappe GetMappe(string id)
        {
            Mappe mappe = db.Mappes.Find(id);
            if (mappe == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return mappe;
        }

        // PUT api/Mappe/5
        public HttpResponseMessage PutMappe(string id, Mappe mappe)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != mappe.systemID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            //TODO restriksjoner

            db.Entry(mappe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Mappe
        public HttpResponseMessage PostMappe(Mappe mappe)
        {
            if (ModelState.IsValid)
            {
                db.Mappes.Add(mappe);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, mappe);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = mappe.systemID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Mappe/5
        public HttpResponseMessage DeleteMappe(string id)
        {
            Mappe mappe = db.Mappes.Find(id);
            if (mappe == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Mappes.Remove(mappe);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, mappe);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}