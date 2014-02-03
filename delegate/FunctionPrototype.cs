using System;

namespace CustomDelegateProject
{
    class FunctionPrototype
    {
        public Type ReturnDataType { get; private set; }
        public Type[] InputParameters { get; private set; }

        public FunctionPrototype(Type returnType, Type[] inputParameters)
        {
            ReturnDataType = returnType;
            InputParameters = inputParameters;
        }


    }
}
