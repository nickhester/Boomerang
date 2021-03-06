﻿namespace Boomerang.Controllers
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

    public class PostsController : ODataController
    {
        // GET api/posts
        [EnableQuery]//(PageSize = 5)]
        public IQueryable<Post> Get()
        {
            Context context = new Context();
            
            context.Database.Log = (o => System.Diagnostics.Debug.Write(o));

            return context.PostDbSet;
        }

        // GET api/posts/5
        [EnableQuery]
        public IQueryable<Post> Get([FromODataUri] int id)
        {
            Context context = new Context();

            context.Database.Log = (o => System.Diagnostics.Debug.Write(o));

            return context.PostDbSet.Where(x => x.Id == id);
        }

        // POST api/posts
        public void Post([FromBody]Post value)
        {
            // fix up data
            value.Time = DateTime.UtcNow;

            var context = new Context();
            context.PostDbSet.Add(value);
            context.SaveChanges();
        }

        //// PUT api/posts/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/posts/5
        //public void Delete(int id)
        //{
        //}
    }
}
