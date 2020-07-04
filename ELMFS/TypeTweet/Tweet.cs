//Author: Fletcher Thomas Moore
//Description: Handles the Tweet type message, The Sender/Twitter ID, TextSpeak, hashtags and mentions. Connected to MainWindow.xaml.cs, TweetHashtags.cs, and TweetMentions.cs
//Start Date: 29/06/2020
//End Date: 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ELMFS.TypeTweet
{
    class Tweet
    {
        public static bool TweetSender(string mainSender)
        {
            //Regex for ID
            Regex rxTweetSender = new Regex(@"\s(?<=^|(?<=[^a-zA-Z0-9-_\.]))@([A-Za-z]+[A-Za-z0-9-_]+)");

            //Match
            Match matchSender = rxTweetSender.Match(mainSender);

            //handle the input
            if(matchSender.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
