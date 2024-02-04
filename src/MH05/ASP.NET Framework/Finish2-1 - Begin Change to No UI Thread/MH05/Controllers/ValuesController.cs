using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace MH05.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        // https://localhost:44369/api/values
        public async Task<IEnumerable<string>> Get()
        {
            await Task.Delay(1).ConfigureAwait(false);
            int ThreadId = Thread.CurrentThread.ManagedThreadId;
            Debug.WriteLine($"[StartBtn_Click - StartAsync] Begin {ThreadId}");
            var task = new MyService().StartAsync();
            ThreadId = Thread.CurrentThread.ManagedThreadId;
            Debug.WriteLine($"[StartBtn_Click - Result] Begin {ThreadId}");
            var result = task.Result;
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
