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
using System.Runtime.Serialization;

namespace ELMFS.TypeTweet
{
    [DataContract]
    class Tweet : Message
    {
        #region Sender
        public static string TweetSender(string mainSender)
        {
            //Regex for ID
            //Regex rxTweetSender = new Regex(@"\s(?<=^|(?<=[^a-zA-Z0-9-_\.]))@([A-Za-z]+[A-Za-z0-9-_]+)");
            //Match
            //Match matchSender = rxTweetSender.Match(mainSender);

            //split main sender
            string senderOne = mainSender.Substring(0, 1);
            string senderTwo = mainSender.Substring(1);

            //handle the input
            if(senderOne != "@")
            {
                System.Windows.MessageBox.Show("Error: Twitter ID must start with '@'");
                mainSender = null;
                return mainSender;
            }
            else if (senderTwo.Length > 15)
            {
                System.Windows.MessageBox.Show("Error: Length of sender must be 16 characters including '@' at the start.");
                mainSender = null;
                return mainSender;
            }
            else
            {
                return mainSender;
            }
        }
        #endregion


        #region Message
        //Finds and converts textspeak, finds and stores hashtags and mentions
        public static string TweetMessage(string mainMessage, ref List<string> hTags, ref List<string> tMention)
        {
            //check for textspeak
            mainMessage = Textspeak.TextSpeak(mainMessage);

            //Initialize Lists
            //TweetHashtags tweetHashtags = new TweetHashtags();
            //TweetMentions tweetMentions = new TweetMentions();

            //Match Pattern
            const string hashtag = @"#([A-Za-z0-9\-_&;]+)";
            const string mention = @"@([A-Za-z0-9\-_&;]+)";

            //if the body contains '#' store the #hashtag to the list
            if (mainMessage.Contains("#"))
            {
                foreach (Match match in Regex.Matches(mainMessage, hashtag))
                {
                    var hashtagMatch = match.Groups[1].Value;
                    hTags.Add("#" + hashtagMatch);
                }
            }

            //if the body contains '@' store the @mention to the list
            if (mainMessage.Contains("@"))
            {
                foreach(Match match in Regex.Matches(mainMessage, mention))
                {
                    var mentionMatch = match.Groups[1].Value;
                    tMention.Add("@" + mentionMatch);
                }
            }

            //return message
            return mainMessage;
        }
        #endregion

        public Tweet (string finalHeader, string finalSender, string finalSubject, string finalMessage) : base(finalHeader, finalSender, finalSubject, finalMessage)
        {
            msgHeader = finalHeader;
            msgSender = finalSender;
            msgSubject = finalSubject;
            msgBody = finalMessage;
        }
    }
}
