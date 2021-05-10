using System;
using System.Collections.Generic;
using System.Text;

namespace Stack
{
    class Stack
    {
        static protected List<Stack> stackList = new List<Stack>();

        //methods
        public void Push(StackItem s)
        {
            stackList.Insert(, s);
                
        }

        public Object Pop()
        {
            StackItem s = stackList[0];

            return 
        }

        public void Clear()
        {

        }


    }
}
