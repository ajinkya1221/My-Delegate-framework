using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CustomDelegateProject
{
    class CustomDelegate
    {
        private List<Tuple<object, MethodInfo>> _listOfMethods = new List<Tuple<object, MethodInfo>>();
        public FunctionPrototype FunctionPrototype { private get; set; }

        public void Register(object classInstance, string functionName)
        {
            Type classTypeObject =  classInstance.GetType();
            MethodInfo methodInfo = classTypeObject.GetMethod(functionName, this.FunctionPrototype.InputParameters);
            if (methodInfo != null)
            {
                if (this.CheckPrototypeReturnType(methodInfo) == true)
                {
                    _listOfMethods.Add(new Tuple<object, MethodInfo>(classInstance, methodInfo));
                }
            }
        }

        public object Invoke(params object[] arguments)
        {
            object dataReturn = null;
            foreach (var listItemEntry in _listOfMethods)
            {
                dataReturn = listItemEntry.Item2.Invoke(listItemEntry.Item1, arguments);
            }
            return dataReturn;
        }

        //Check that the return of method is same.
        private bool CheckPrototypeReturnType(MethodInfo methodInfo)
        {
           return this.FunctionPrototype.ReturnDataType == methodInfo.ReturnType;
        }
    }
}
