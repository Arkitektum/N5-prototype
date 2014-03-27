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
    public class ArkivskaperController : ApiController
    {
        private tjenesteContext db = new tjenesteContext();

        // GET api/Arkivskaper



        /// <summary>
        /// Tradisjonelt har et arkiv blitt definert etter organisasjon. Ett organ skaper ett arkiv, dvs. 
        /// organet er arkivskaperen. Men elektronisk informasjonsteknologi har ført til at det blir stadig 
        /// vanligere at flere arkivskapere sammen skaper ett arkiv. Arkivet vil da være definert etter 
        /// funksjon, ikke organisasjon
        /// </summary>
        /// <returns>Liste med arkivskapere</returns>
        public IEnumerable<Arkivskaper> GetArkivskapers()
        {
            return db.Arkivskapers.AsEnumerable();
        }

        // GET api/Arkivskaper/5
        public Arkivskaper GetArkivskaper(string id)
        {
            Arkivskaper arkivskaper = db.Arkivskapers.Find(id);
            if (arkivskaper == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return arkivskaper;
        }

        // PUT api/Arkivskaper/5
        public HttpResponseMessage PutArkivskaper(string id, Arkivskaper arkivskaper)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != arkivskaper.systemID)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(arkivskaper).State = EntityState.Modified;

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

        // POST api/Arkivskaper
        public HttpResponseMessage PostArkivskaper(Arkivskaper arkivskaper)
        {
            if (ModelState.IsValid)
            {
                db.Arkivskapers.Add(arkivskaper);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, arkivskaper);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = arkivskaper.systemID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Arkivskaper/5
        public HttpResponseMessage DeleteArkivskaper(string id)
        {
            Arkivskaper arkivskaper = db.Arkivskapers.Find(id);
            if (arkivskaper == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Arkivskapers.Remove(arkivskaper);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, arkivskaper);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}