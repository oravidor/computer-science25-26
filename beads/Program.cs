using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beads
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }

        #region 3a0
        public static Bead CreateChain3()
        {
            Bead bead3 = new Bead("Green");
            Bead bead2 = new Bead("Blue", bead3);
            Bead bead1 = new Bead("Red", bead2);
            return bead1;
        }
        public static Bead CreateChainFromStart(string[] colors)
        {
            if (colors == null || colors.Length == 0)
            {
                return null;
            }
            Bead head = new Bead(colors[0]);
            Bead prevous = head;
            for (int i = 1; i < colors.Length; i++)
            {
                Bead newBead = new Bead(colors[i]);
                prevous.SetNextBead(newBead);
                prevous = newBead;
            }
            return head;
        }
        public static Bead CreateChainFromEnd(string[] colors)
        {
            if (colors == null || colors.Length == 0)
            {
                return null;
            }
            Bead head = new Bead(colors[colors.Length - 1]);
            Bead prevous = head;
            for (int i = colors.Length - 2; i >= 0; i--)
            {
                Bead newBead = new Bead(colors[i]);
                newBead.SetNextBead(prevous);
                prevous = newBead;
            }
            return prevous;
        }
        public static void PrintChain(Bead head)
        {
            if (head == null)
                return;
            while (head.GetNextBead() != null)
            {
                Console.Write($"{head.ToString()} -> ");
                head = head.GetNextBead();
            }
            if (head.GetNextBead() == null)
                Console.Write($"{head.ToString()}\n");
        }
        public static int CountBeads(Bead head)
        {
            if (head == null)
                return 0;
            int count = 1;
            while (head.GetNextBead() != null)
            {
                count++;
                head = head.GetNextBead();
            }
            return count;
        }
        public static Bead FindBead(Bead head, string targetColor)
        {
            if (head == null)
                return null;
            while (head.GetNextBead() != null)
            {
                if (head.ToString() == targetColor)
                    return head;
                head = head.GetNextBead();
            }
            if (head.ToString() == targetColor)
                return head;
            return null;
        }
        public static Bead AddBeadToEnd(Bead head, string colorToAdd)
        {
            if (head == null || head.ToString() == "")
            {
                Bead bead1 = new Bead(colorToAdd);
                head = bead1;
                return bead1;
            }
            Bead bead = head;
            while (bead.GetNextBead() != null)
            {
                bead = bead.GetNextBead();
            }
            Bead newBead = new Bead(colorToAdd);
            bead.SetNextBead(newBead);
            return head;
        }
        public static Bead ConcatenateChains(Bead head, Bead second)
        {
            if (head == null)
                return second;
            if (second == null)
                return head;
            Bead bead = head;
            while (bead.GetNextBead() != null)
            {
                bead = bead.GetNextBead();
            }
            bead.SetNextBead(second);
            return head;
        }
        public static Bead ReverseChain(Bead head)
        {
            if (head == null || head.GetNextBead() == null)
                return head;
            Bead prev = null;
            Bead current = head;
            while (current != null)
            {
                Bead next = current.GetNextBead();
                current.SetNextBead(prev);
                prev = current;
                current = next;
            }
            return prev;
        }
        public static Bead RemoveBead(Bead head, string colorToRemove)
        {
            if (head == null)
                return null;
            if (head.GetColor() == colorToRemove)
                return head.GetNextBead();
            Bead prev = head;
            Bead curr = head.GetNextBead();
            while (curr != null)
            {
                if (curr.GetColor() == colorToRemove)
                {
                    prev.SetNextBead(curr.GetNextBead());
                    break;
                }
                prev = curr;
                curr = curr.GetNextBead();
            }
            return head;
        }
        public static Bead RemoveBeadsByPosition(Bead head, bool removeEven)
        {
            if (head == null)
                return null;
            if (!removeEven)
            {
                Bead dummy = new Bead("", head);
                Bead prev = dummy;
                Bead curr = head;
                int index = 1;
                while (curr != null)
                {
                    if (index % 2 == 1)
                        prev.SetNextBead(curr.GetNextBead());
                    else
                        prev = curr;
                    curr = curr.GetNextBead();
                    index++;
                }
                return dummy.GetNextBead();
            }
            else
            {
                Bead prev = head;
                Bead curr = head.GetNextBead();
                int index = 2;
                while (curr != null)
                {
                    if (index % 2 == 0)
                        prev.SetNextBead(curr.GetNextBead());
                    else
                        prev = curr;
                    curr = curr.GetNextBead();
                    index++;
                }
                return head;
            }
        }
        public static Bead RemoveAll(Bead head, string colorToRemove)
        {
            if (head == null)
                return null;
            while (head != null && head.GetColor() == colorToRemove)
                head = head.GetNextBead();

            Bead current = head;
            while (current != null && current.GetNextBead() != null)
            {
                if (current.GetNextBead().GetColor() == colorToRemove)
                    current.SetNextBead(current.GetNextBead().GetNextBead());
                else
                    current = current.GetNextBead();
            }
            return head;
        }
        public static bool HasPattern(Bead head, string[] pattern)
        {
            if (pattern == null || pattern.Length == 0)
                return true;
            if (head == null)
                return false;
            Bead current = head;
            while (current != null)
            {
                Bead chainPtr = current;
                int i = 0;
                while (chainPtr != null && i < pattern.Length && chainPtr.GetColor() == pattern[i])
                {
                    chainPtr = chainPtr.GetNextBead();
                    i++;
                }
                if (i == pattern.Length)
                    return true;
                current = current.GetNextBead();
            }
            return false;
        }

        #endregion
    }
}
