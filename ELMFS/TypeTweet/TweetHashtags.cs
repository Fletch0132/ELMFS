//Author: Fletcher Thomas Moore
//Description: Handles any hashtags within the message body, writes them to a hashtag list, and counts them to make a trending list. Connected to Tweet.cs
//Start Date: 29/06/2020
//End Date: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMFS.TypeTweet
{
    class TweetHashtags
    {
        //Hashtag List
        private List<string> Hashtags = new List<string>();

        public List<string> GetHashtagList()
        {
            return Hashtags;
        }

        internal void Add(string hashtagMatch)
        {
            throw new NotImplementedException();
        }
    }
}
