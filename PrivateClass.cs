using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    //A private class can only be instantiated inside the class or the class nested in 
    public class Work
    {
        private InitializeWork instance;

        private class InitializeWork
        {
            //private InitializeWork instance;

            public void DoSomeWork()
            {

            }
        }

        public void StartWork()
        {
            instance = new InitializeWork();
            instance.DoSomeWork();
        }
    }
}
