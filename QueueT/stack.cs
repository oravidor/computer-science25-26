using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueT
{
    // Unit4 המימוש הרשמי של 
    public class Stack<T>
    {
        private Node<T> head;

        //-----------------------------------
        //constructor
        public Stack()
        {
            this.head = null;
        }
        //-----------------------------------
        //adds element x to the top of the stack
        public void Push(T x)
        {
            Node<T> temp = new Node<T>(x);
            temp.SetNext(head);
            head = temp;
        }
        //-----------------------------------
        //removes & returns the element from the top of the stack
        public T Pop()
        {
            T x = head.GetValue();
            head = head.GetNext();
            return x;
        }
        //-----------------------------------
        //returns the element from the top of the stack
        public T Top()
        {
            return head.GetValue();
        }
        //-----------------------------------
        //returns true if there are no elements in stack
        // ...כיוון שאני לא מטיפוסל בלי קצת כתיב מקוצר
        public bool IsEmpty() => head == null;
        //-------------------------------------
        //ToString
        public override string ToString()
        {
            if (this.IsEmpty())
                return "[]";
            string temp = head.ToString();
            return "TOP <== " + temp.Substring(0, temp.Length - 1) + "]";
        }
    }
}
