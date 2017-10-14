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

    public class PostsController : ODataController
    {
        // GET api/posts
        [EnableQuery(PageSize = 5)]
        public IQueryable<Post> Get()
        {
            PostsContext postContext = new PostsContext();

            postContext.Database.Log = (o => System.Diagnostics.Debug.Write(o));

            return postContext.PostDbSet;
        }

        // GET api/posts/5
        [EnableQuery]
        public IQueryable<Post> Get([FromODataUri] int id)
        {
            PostsContext postContext = new PostsContext();

            postContext.Database.Log = (o => System.Diagnostics.Debug.Write(o));

            return postContext.PostDbSet.Where(x => x.Id == id);
        }

        // POST api/posts
        public void Post([FromBody]Post value)
        {
            // fix up data
            value.Time = DateTime.UtcNow;

            var postContext = new PostsContext();
            postContext.PostDbSet.Add(value);
            postContext.SaveChanges();
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
