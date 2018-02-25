using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms
{
    class LinkList
    {
        public Node Head { get; set; }

        public void AddBefore(int value, int target)
        {
            Node R = Head;

            if (R.Value == target)
            {
                Head = new Node { Value = value, Next = Head };
                R = Head.Next;
            }
            while (R.Next != null)
            {
                if (R.Next.Value == target)
                {
                    R.Next = new Node { Value = value, Next = R.Next };
                    R = R.Next;
                }
                R = R.Next;
            }

        }

        public void AddAfter(int value, int target)
        {
            Node R = Head;

            for (int i = 0; R.Next != null; i++)
            {
                R = R.Next;
                if (R.Value == target)
                {
                    Node N = R.Next;
                    if (R.Next != null)
                    {
                        R.Next.Next = null;
                    }
                    R.Next = new Node
                    {
                        Value = value,
                        Next = N
                    };
                }
            }
        }

        public void AddFirst(int value)
        {
            Node N = new Node { Value = value, Next = Head };

            Head = N;
        }

        public void AddLast(int value)
        {
            if (Head == null)
            {
                Head = new Node();
                Head.Value = value;
            }
            else
            {
                Node R = Head;

                while (R.Next != null)
                {
                    R = R.Next;
                }

                R.Next = new Node();
                R.Next.Value = value;

            }
        }

        public void Remove(int value)
        {
            while (Head.Value == value)
            {
                Head = Head.Next;
            }
            Node R1 = Head.Next;
            Node R2 = Head;
            while (R1 != null)
            {
                if (R1.Value == value)
                {
                    if (R1.Next != null)
                    {
                        R2.Next.Value = R1.Next.Value;
                        R2.Next.Next = R1.Next.Next;
                    }
                    else
                    {
                        R2.Next = null;
                    }
                    R1 = Head.Next;
                    R2 = Head;
                }
                R1 = R1.Next;
                R2 = R2.Next;
            }
        }

        public Node Middle()
        {
            Node R1 = this.Head;
            Node R2 = this.Head;

            int counter = 0;

            while (R1.Next != null)
            {
                counter++;
                R1 = R1.Next;
                if (counter % 2 == 0)
                {
                    R2 = R2.Next;
                }
                if (R1.Next == null)
                {
                    return R2;
                }
            }
            return R2;
        }
    }

    class DoubleLinkList
    {
        public DoubleNode Head { get; set; }
    }

    class Tree
    {
        public TreeNode Root { get; set; }
    }
}
