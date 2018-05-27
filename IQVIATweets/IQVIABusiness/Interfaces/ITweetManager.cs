using IQVIA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IQVIA.Business.Interfaces
{
    public interface ITweetManager
    {
        bool GetTweets(List<TweetsModel> tweetsModel, string lastDate);
        string GetEndDate(List<TweetsModel> lstTweets);
    }
}