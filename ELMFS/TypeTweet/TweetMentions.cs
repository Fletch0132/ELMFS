//Author: Fletcher Thomas Moore
//Description: Handles the mentions (User ID's mentioned) within the message body and writes them to a mention list. Connected to Tweet.cs
//Start Date: 29/06/2020
//End Date: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELMFS.TypeTweet
{
    class TweetMentions
    {
        //Mentions List
        private List<string> Mentions = new List<string>();

        public List<string> GetMentionsList()
        {
            return Mentions;
        }

        internal static void Add(string mentionMatch)
        {
            throw new NotImplementedException();
        }
    }
}
