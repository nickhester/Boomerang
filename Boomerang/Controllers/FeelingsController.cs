namespace Boomerang.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    using Models;
    using Contexts;
    using System.Web.OData;

    public class FeelingsController : ODataController
    {
        // GET api/feelings
        [EnableQuery]//(PageSize = 5)]
        public IQueryable<Feeling> Get()
        {
            Context context = new Context();

            context.Database.Log = (o => System.Diagnostics.Debug.Write(o));

            return context.FeelingDbSet;
        }

        // GET api/feelings/5
        [EnableQuery]
        public IQueryable<Feeling> Get([FromODataUri] int id)
        {
            Context context = new Context();

            context.Database.Log = (o => System.Diagnostics.Debug.Write(o));

            return context.FeelingDbSet.Where(x => x.Id == id);
        }

        // POST api/feelings
        public void Post([FromBody]Feeling value)
        {
            var context = new Context();
            context.FeelingDbSet.Add(value);
            context.SaveChanges();
        }

        //// PUT api/feelings/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/feelings/5
        //public void Delete(int id)
        //{
        //}
    }
}
