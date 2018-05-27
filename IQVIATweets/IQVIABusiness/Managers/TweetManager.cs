using IQVIA.Business.Interfaces;
using IQVIA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace IQVIA.Business.Managers
{
    public class TweetManager : ITweetManager
    {
        public bool GetTweets(List<TweetsModel> lstTweets, string lastDate)
        {
            if (lstTweets.Count < 100)
                return false;
            DateTime tweetsLastDate = DateTimeOffset.Parse(lstTweets.Last().stamp).UtcDateTime.Date;
            lastDate = GetExactDate(lastDate);
            DateTime lstDate = DateTime.ParseExact(lastDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
            if ((lstDate - tweetsLastDate).TotalDays >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetEndDate(List<TweetsModel> lstTweets)
        {
            return DateTimeOffset.Parse(lstTweets.Last().stamp).UtcDateTime.Date.ToString("MM/dd/yyyy");
        }

        private string GetExactDate(string date)
        {
            string[] dateSplit = date.Split('-');
            return dateSplit[1] + "-" + dateSplit[0] + "-"+ dateSplit[2];
        }
    }
}