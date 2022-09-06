using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_10
{
    public class MessageLog
    {
        public long ID { get; private set; }
        public string Name { get; private set; }
        public string Message { get; private set; }
        public DateTime Time { get; private set; }

        public MessageLog(long ID, string Name, string Message,DateTime Time)
        { 
            this.ID=ID;
            this.Name=Name;
            this.Message=Message;
            this.Time=Time;
        }
    }
}
