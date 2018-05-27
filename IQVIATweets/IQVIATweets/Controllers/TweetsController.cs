using IQVIA.Business.Interfaces;
using IQVIA.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;
using System.Linq;
using IQVIA.Domain;
using IQVIATweets.ExceptionFilter;

namespace IQVIATweets.Controllers
{
    [RoutePrefix("v1")]
    [ExceptionFilterClass]
    public class TweetsController : ApiController
    {
        private readonly ITweetManager _tweetManager;
        
        public TweetsController(ITweetManager tweetManager)
        {
            _tweetManager = tweetManager;
        }

        /// <summary>
        /// Used to get tweets from external api based on parameters
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Tweets")]
        public async Task<IHttpActionResult> GetTweets(string startDate, string endDate)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            js.MaxJsonLength = Int32.MaxValue;

            List<TweetsModel> Tweets = new List<TweetsModel>();
            List<TweetsModel> AllTweets = new List<TweetsModel>();
            int moreRecordsFlag = 0;
            do
            {
                if(moreRecordsFlag > 0)
                {
                    startDate = _tweetManager.GetEndDate(Tweets);
                }
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Contants.Baseurl);

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage Res = await client.GetAsync("?startDate=" + startDate + "&endDate=" + endDate);

                    if (Res.IsSuccessStatusCode)
                    {
                        var tweetsResult = Res.Content.ReadAsStringAsync().Result;

                        Tweets = JsonConvert.DeserializeObject<List<TweetsModel>>(tweetsResult);
                        AllTweets.AddRange(Tweets);
                    }
                }
                moreRecordsFlag++;
            } while (_tweetManager.GetTweets(Tweets, endDate));
           
            string jsonData = js.Serialize(AllTweets.GroupBy(x=>x.id).Select(x=>x.First()).Distinct());
            return Ok(jsonData);
        }
    }
}