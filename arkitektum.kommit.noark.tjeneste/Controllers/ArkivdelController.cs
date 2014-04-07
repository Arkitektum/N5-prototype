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
    public class ArkivdelController : ApiController
    {
        private tjenesteContext db = new tjenesteContext();

        // GET api/Arkivdel
        public IEnumerable<ArkivdelType> GetArkivdels()
        {
            var url = HttpContext.Current.Request.Url;
            var baseUri =
                new UriBuilder(
                    url.Scheme,
                    url.Host,
                    url.Port).Uri;

            //Rettinghetsstyring...og alle andre restriksjoner
            List<ArkivdelType> testdata = new List<ArkivdelType>();
            ArkivdelType m = new ArkivdelType();
            m.tittel = "test arkivdel";
            m.systemID = "12345";
            m.opprettetDato = DateTime.Now;

            List<LinkType> linker = new List<LinkType>();
            LinkType l = new LinkType();
            l.uri = baseUri + "api/Arkivdel/" + m.systemID;
            l.rel = "self";
            linker.Add(l);
            LinkType l2 = new LinkType();
            l2.uri = l.uri + "/mappe";
            l2.rel = "http://rel.kommit.no/noark5/v4/mappe";
            linker.Add(l2);
            LinkType l3 = new LinkType();
            l3.uri = l.uri + "/registrering";
            l3.rel = "http://rel.kommit.no/noark5/v4/registrering";
            linker.Add(l3);

            LinkType l4 = new LinkType();
            l4.uri = l.uri + "/klassifikasjonssystem";
            l4.rel = "http://rel.kommit.no/noark5/v4/klassifikasjonssystem";
            linker.Add(l4);

            LinkType l5 = new LinkType();
            l5.uri = baseUri + "api/Arkiv/" + "45345";
            l5.rel = "http://rel.kommit.no/noark5/v4/referanseArkiv";
            linker.Add(l5);

            m.linker = linker.ToArray();

            testdata.Add(m);

            ArkivdelType m2 = new ArkivdelType();
            m2.tittel = "test arkivdel 2";
            m2.systemID = "234";
            m2.opprettetDato = DateTime.Now;

            List<LinkType> linker2 = new List<LinkType>();

            LinkType ml = new LinkType();
            ml.uri = baseUri + "api/Arkivdel/" + m.systemID;
            ml.rel = "self";
            linker.Add(ml);
            LinkType ml2 = new LinkType();
            ml2.uri = ml.uri + "/mappe";
            ml2.rel = "http://rel.kommit.no/noark5/v4/mappe";
            linker.Add(ml2);
            LinkType ml3 = new LinkType();
            ml3.uri = ml.uri + "/registrering";
            ml3.rel = "http://rel.kommit.no/noark5/v4/registrering";
            linker.Add(ml3);

            LinkType ml4 = new LinkType();
            ml4.uri = ml.uri + "/klassifikasjonssystem";
            ml4.rel = "http://rel.kommit.no/noark5/v4/klassifikasjonssystem";
            linker.Add(ml4);

            LinkType ml5 = new LinkType();
            ml5.uri = baseUri + "api/Arkiv/" + "45345";
            ml5.rel = "http://rel.kommit.no/noark5/v4/referanseArkiv";
            linker.Add(ml5);

            m2.linker = linker2.ToArray();

            testdata.Add(m2);

            return testdata.AsEnumerable();
            
            //return db.Arkivdels.AsEnumerable();
        }

        // GET api/Arkivdel/5
        public ArkivdelType GetArkivdel(string id)
        {
            var url = HttpContext.Current.Request.Url;
            var baseUri =
                new UriBuilder(
                    url.Scheme,
                    url.Host,
                    url.Port).Uri;

                        ArkivdelType m = new ArkivdelType();
            m.tittel = "test arkivdel";
            m.systemID = id;
            m.opprettetDato = DateTime.Now;

            List<LinkType> linker = new List<LinkType>();
            LinkType l = new LinkType();
            l.uri = baseUri + "api/Arkivdel/" + m.systemID;
            l.rel = "self";
            linker.Add(l);
            LinkType l2 = new LinkType();
            l2.uri = l.uri + "/mappe";
            l2.rel = "http://rel.kommit.no/noark5/v4/mappe";
            linker.Add(l2);
            LinkType l3 = new LinkType();
            l3.uri = l.uri + "/registrering";
            l3.rel = "http://rel.kommit.no/noark5/v4/registrering";
            linker.Add(l3);

            LinkType l4 = new LinkType();
            l4.uri = l.uri + "/klassifikasjonssystem";
            l4.rel = "http://rel.kommit.no/noark5/v4/klassifikasjonssystem";
            linker.Add(l4);

            LinkType l5 = new LinkType();
            l5.uri = baseUri + "api/Arkiv/" + "45345";
            l5.rel = "http://rel.kommit.no/noark5/v4/referanseArkiv";
            linker.Add(l5);

            m.linker = linker.ToArray();
            if (m == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return m;
        }

        //[HttpGet]
        //public IEnumerable<MappeType> mappe(string id)
        //{
        //    MappeController m = new MappeController();
        //    return m.Arkivdel(id);
        //}
        //// PUT api/Arkivdel/5
        //public HttpResponseMessage PutArkivdel(string id, Arkivdel arkivdel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }

        //    if (id != arkivdel.systemID)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }

        //    db.Entry(arkivdel).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        //// POST api/Arkivdel
        //public HttpResponseMessage PostArkivdel(Arkivdel arkivdel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Arkivdels.Add(arkivdel);
        //        db.SaveChanges();

        //        HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, arkivdel);
        //        response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = arkivdel.systemID }));
        //        return response;
        //    }
        //    else
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        //    }
        //}

        //// DELETE api/Arkivdel/5
        //public HttpResponseMessage DeleteArkivdel(string id)
        //{
        //    Arkivdel arkivdel = db.Arkivdels.Find(id);
        //    if (arkivdel == null)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.NotFound);
        //    }

        //    db.Arkivdels.Remove(arkivdel);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }

        //    return Request.CreateResponse(HttpStatusCode.OK, arkivdel);
        //}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}