//Author: Fletcher Thomas Moore
//Description: Handles the message as a whole, writing the inputs to a JSON format file. Connected to MainWindow.xaml.cs
//Start Date: 29/06/2020
//End Date: 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace ELMFS
{
    //deal with complete message for JSON format
    [DataContract]
    class Message
    {
        //Header
        [DataMember(Name ="Message Header")]
        public string msgHeader { get; set; }
        //Sender
        [DataMember(Name ="Message Sender")]
        public string msgSender { get; set; }
        //Subject
        [DataMember(Name = "Message Subject")]
        public string msgSubject { get; set; }
        //Message Body
        [DataMember(Name = "Message Body")]
        public string msgBody { get; set; }

        //construct
        public Message(string finalHeader, string finalSender, string finalSubject, string finalMessage)
        {
            msgHeader = finalHeader;
            msgSender = finalSender;
            msgSubject = finalSubject;
            msgBody = finalMessage;
        }
    }
}
