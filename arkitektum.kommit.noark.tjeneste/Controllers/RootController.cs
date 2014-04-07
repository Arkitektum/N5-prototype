using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace arkitektum.kommit.noark.tjeneste.Controllers
{
    public class RootController : ApiController
    {
        // GET api/Mappe
        public IEnumerable<LinkType> GetRoots()
        {
            var url = HttpContext.Current.Request.Url;
            var baseUri =
                new UriBuilder(
                    url.Scheme,
                    url.Host,
                    url.Port).Uri;

            //Rettinghetsstyring...og alle andre restriksjoner
            List<LinkType> linker = new List<LinkType>();
            //LinkType l = new LinkType();
            //l.uri = "arkiv/" + m.systemID;
            //l.rel = "self";
            //linker.Add(l);
            LinkType l2 = new LinkType();
            l2.uri = baseUri + Url.Route("DefaultApi", new { controller = "Mappe" });
            l2.rel = "http://rel.kommit.no/noark5/v4/Mappe";
            linker.Add(l2);
            LinkType l3 = new LinkType();
            l3.uri = baseUri + Url.Route("DefaultApi", new { controller = "OffentligJournal" });
            l3.rel = "http://rel.kommit.no/noark5/v4/OffentligJournal";
            linker.Add(l3);

            LinkType l4 = new LinkType();
            l4.uri = baseUri + Url.Route("DefaultApi", new { controller = "Restanser" });
            l4.rel = "http://rel.kommit.no/noark5/v4/Restanser";
            linker.Add(l4);


            return linker.AsEnumerable();
        }

        //// GET api/Mappe/5
        //public MappeType GetMappe(string id)
        //{
        //    MappeType mappe = db.Mappes.Find(id);
        //    if (mappe == null)
        //    {
        //        throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    }

        //    return mappe;
        //}
    }
}
