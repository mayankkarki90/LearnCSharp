using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    internal class ExceptionLearn
    {
        static void TestWithThrow()
        {
            try
            {
                Console.WriteLine("test with throw executing");
                test2();
            }
            catch (Exception)
            {
                throw; //simply re-throw exisitng exception, preserve the stack trace
                        //makes easier to pin point the root cause
            }
        }

        static void TestWithEx()
        {
            try
            {
                Console.WriteLine("test with ex executing");
                test2();
            }
            catch (Exception ex)
            {
                throw ex; //this will create a new exception object with stack trace starting
                        //starting from this point, hiding the original source of the error
            }
        }

        static void test2()
        {
            Console.WriteLine("new exception raised");
            throw new NotImplementedException("new exception raised");
        }

        public static void TestExceptionThrow()
        {
            try
            {
                TestWithThrow();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception handled");
                Console.WriteLine(ex.StackTrace);
            }

            try
            {
                TestWithEx();
            }
            catch (Exception ex)
            {
                Console.WriteLine("exception handled");
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
