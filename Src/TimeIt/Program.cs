using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeIt.Test
{
    public class Program
    {
        static void Main(string[] args)
        {
           var custTimer=new TimeIt();
            var executionTime=new TimeSpan();

            //This overload lets you pass a params array
            executionTime=custTimer.Start(GenerateNumbers,1,2,3,4,5);

            //Use an anonymous function  
            executionTime = custTimer.Start(() =>
            {
                //timer will stop at the end of this block of code
            });

            //Wrap your code within an Using statement  
            using (var byUsing=new TimeIt())
            {
                GenerateNumbers();
                //Before end using, retrieve elapsed time from object  
                executionTime = byUsing.ElapsedTime;
            }

            //Use it with lambda expressions (lambda will return execution Time)  by using Invoke Method()
            using (TimeIt.Invoke(ts =>Console.Write("Method exec time: "+ts.Milliseconds)))
                GenerateNumbers();


            //Pass to Invoke the function that will receive the TimeSpan before intern object disposal  
            using (TimeIt.Invoke(ProcessResult))
                GenerateNumbers();
            //Keep the console open
            Console.ReadKey();
        }
        private static void ProcessResult(TimeSpan span)
        {
            // log, show, etc
        }
        private static void GenerateNumbers(params object[] args)
        {
            for (var i = 0; i < 999999; i++)
            {
                for (var j = 0; j < 999; j++)
                {
                    //Console.Write(i.ToString());
                }
            }
        }
    }
}
