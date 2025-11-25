using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueT
{
    // Unit4 המימוש הרשמי של 
    public class Queue<T>
    {
        private Node<T> first;
        private Node<T> last;

        //-----------------------------------
        //constructor
        public Queue()
        {
            this.first = null;
            this.last = null;
        }
        //-----------------------------------
        //adds element x to the end of the queue
        public void Insert(T x)
        {
            Node<T> temp = new Node<T>(x);
            if (first == null)
                first = temp;
            else
                last.SetNext(temp);
            last = temp;
        }
        //-----------------------------------
        //removes & returns the element from the head of the queue
        public T Remove()
        {
            if (IsEmpty())
                return default(T);
            T x = first.GetValue();
            first = first.GetNext();
            if (first == null)
                last = null;
            return x;
        }
        //-----------------------------------
        //returns the element from the head of the queue
        public T Head()
        {
            return first.GetValue();
        }
        //-----------------------------------
        //returns true if there are no elements in queue
        public bool IsEmpty()
        {
            return first == null;
        }
        //-------------------------------------
        //ToString
        public override string ToString()
        {
            if (this.IsEmpty())
                return "[]";
            string temp = first.ToString();
            return "QueueHead[" + temp.Substring(0, temp.Length - 1) + "]";
        }
    }
}
