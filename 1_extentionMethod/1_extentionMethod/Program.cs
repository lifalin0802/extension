using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtentionMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Test test = new Test();
            test.TestMethod();      // Call the method of itself  
            test.ExtendMethod();    // Call the extension method  
            AssessmentAnswer.Strongly_Disagree.ToDescription();
        }
    }

    public class Test
    {
        public void TestMethod()
        {
            Console.WriteLine("public void TestMethod()");
        }
    }

    public static class ExtendClass
    {
        public static void ExtendMethod(this Test test)
        {
            Console.WriteLine("test.ExtendMethod()");
        }
    }
}
