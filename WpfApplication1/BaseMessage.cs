using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// Binär serialisering , spara öppna
// XML fil för att editera via andra plattform/prog
namespace WpfApplication1
{
    [Serializable]
    public class BaseMessage
    {
        
        private string theReciever;
        private string theTime;
        private string senderName;
        private string theSubject;
        private string theMessage;
        private string theStatus;



        public BaseMessage()
        {

        }
        public string Time
        {
            get
            {
                return theTime;/* = Convert.ToString(DateTime.Now);*/
            }
            set
            {
                theTime = value;
            }
        }

        public string Reciever
        {
            get
            {
                return theReciever;
            }
            set
            {
                theReciever = value;
            }
        }
        public string Sender
        {
            get
            {
                return senderName;
            }
            set
            {
                senderName = value;
            }
        }
        public string Subject
        {
            get
            {
                return theSubject;
            }
            set
            {
                theSubject = value;
            }
        }
        public string Message
        {
            get
            {
                return theMessage;
            }
            set
            {
                theMessage = value;
            }
        }
        public string Status
        {
            get
            {
                return theStatus;
            }
            set
            {

                theStatus = value;
            }
        }
        public bool Read { get; set; }

        

            public override string ToString()
            {
                return ("Time: " + theTime + "\n" + "Sender: " + senderName + "\n" + "Reciever: " + theReciever + "\n" + "Title: " + theSubject + "\n" + "Message: " + theMessage + "\n");
            }
        
            
        
        
        
    }
}
