using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    internal delegate void MessageHandler(string message);

    internal class DoChat
    {
        public MessageHandler SendMessage;

        public DoChat()
        {
            SendMessage = Message;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
