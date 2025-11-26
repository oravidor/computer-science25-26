using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oop
{
    internal class Eratoasthenes
    {
        Node<int> lst = null;

        public Eratoasthenes(int n)
        {
            for (int i = n; i >= 2; i--)
                lst = new Node<int>(i, lst);
            primes();
        }

        private void primes()
        {
            Node<int> cur = lst;
            while (cur != null)
            {
                cur.SetNext(RemoveNum(cur.GetNext(), cur.GetValue()));
                cur = cur.GetNext();
            }
        }

        public Node<int> RemoveNum(Node<int> head, int remove)
        {
            if (head == null)
                return null;
            head.SetNext(RemoveNum(head.GetNext(), remove));
            if (head.GetValue() % remove == 0)
                return head.GetNext();
            return head;
        }

        public void ToString()
        {
            Node<int> primes = lst;
            while (primes != null)
            {
                Console.WriteLine(primes.GetValue());
                primes = primes.GetNext();
            }
        }
    }
}