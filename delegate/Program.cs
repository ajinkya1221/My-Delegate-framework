using System;

namespace CustomDelegateProject
{
    delegate void MyDelegate(string param);
    class Program
    {
        static void Main()
        {
            var customDelegate = new CustomDelegate();
            var testClass = new TestClass {Message = "Invoking delegate from class instance"};
            var functionPrototype = new FunctionPrototype(typeof(void), new Type[] { typeof(string) });
            customDelegate.FunctionPrototype = functionPrototype;
            customDelegate.Register(testClass, "PrintMessage");
            customDelegate.Invoke("My message");

            customDelegate = new CustomDelegate();
            testClass.Message = "Void Print Function called.";
            functionPrototype = new FunctionPrototype(typeof(void), new Type[] { });
            customDelegate.FunctionPrototype = functionPrototype;
            customDelegate.Register(testClass, "PrintMessage");
            customDelegate.Invoke();
            Console.ReadKey(true);
        }
       
    }


    class TestClass
    {
        public string Message { get; set; }

        public void PrintMessage(string customMessage)
        {
            Console.WriteLine(Message + " " + customMessage);
        }
        public void PrintMessage()
        {
            Console.WriteLine(Message);
        }
    }
}
