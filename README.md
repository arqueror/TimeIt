# TimeIt
A simple C# library for mesure your application methods. This library only exposes two mwthods> Start() and Invoke(). The only difference is Start() needs to create an Instance of TimeIt class, and Invoke() can be called directly.


# Using

//Initialize the library  
var timeit=new TimeIt();

//All the methods will return a TimeSpan with the execution time in Seconds, Ms,etc  
TimeSpan executionTime=new TimeSpan(); 

*******************************************************************
//This overload lets you pass a params array   
executionTime=timeit.Start(GenerateNumbers,1,2,3,4,5); 

private static void GenerateNumbers(params object[] args)  
{   
  //Do something with the args[] array     
}  
*******************************************************************
//Use an anonymous function   
executionTime = timeit.Start(() =>  
            {  
               //Code to mesure   
            });   
 ******************************************************************           
//Wrap your code within an Using statement  
            using (var custTimer=new TimeIt())  
            {  
               YourMethod();  
               //Before end using, retrieve elapsed time from object  
                executionTime = custTimer.ElapsedTime;  
            }   
 ******************************************************************            
 //Use it with lambda expressions (lambda will return execution Time)  by using Invoke Method  
  using (TimeIt.Invoke(ts =>Console.Write(ts.ToString())))  
                YourMethod();  
  ******************************************************************               
  //Pass to Invoke() the method that will receive the TimeSpan before object disposal  
  using (TimeIt.Invoke(ProcessResult))    
                GenerateNumbers();  
                
void ProcessResult(TimeSpan span)  
        { 
            // log, show, etc  
        }  
                
