using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;

namespace Stack
{
    public class Node
    {
        public int data;
        public Node ?next = null;

        public Node()
        {
            data = 0;
            next = null;
        }
    }

    public class MyStack
    {
        private Node? top = null;  // Points to the top of the stack (null if empty)

        // Push: Adds a new item to the TOP of the stack
        public void Push(int item)
        {
            // Create a new node and add it to the top of the stack
            Node newNode = new Node() { data = item };

            newNode.next = top; // Point the new node to the current top

            top = newNode; // Update the top to the new node

            Console.WriteLine($"Pushed item: {item}");
        }

        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty. Cannot pop an item.");
                return -1; // Sentinel value indicating failure
            }

            Node deleted = top!;

            top = top!.next;


            Console.WriteLine($"Popped: {deleted.data}");
            return deleted.data; // Return the removed value
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty. Cannot peek.");
                return -1; // Sentinel value indicating failure
            }

            Console.WriteLine($"Top item: {top!.data}");
            return top!.data;
        }
        public void Display()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty.");
                return;
            }

            Console.WriteLine("Stack (top → bottom):");
            Console.WriteLine("=============");

            Node? temp = top;
            
            while (temp != null)
            {
                Console.WriteLine($"  {temp.data}");


                // Only print separator if there's another node below
                if (temp.next != null)
                    Console.WriteLine("-------------");

                temp = temp.next;
            }

            Console.WriteLine("=============");
        }
        public bool IsEmpty()
        {
            return top == null;
        }


        public int Count()
        {
            int counter = 0;

            Node temp = top;

            while (temp != null)
            {
                counter++;
                temp = temp.next;
            }

            Console.WriteLine($"Number of items in the stack: {counter}");
            return counter;
        }

        public bool Search(int key)
        {
            Node temp = top;


            while (temp != null)
            {
                if (temp.data == key) {
                    Console.WriteLine($"Item {key} found in the stack.");
                    return true;
                }

                temp = temp.next;
            }
            Console.WriteLine($"Item {key} not found in the stack.");
            return false; // Also return result so callers can use it

        }


    }
}
