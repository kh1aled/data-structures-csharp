using System;
using System.Text;

namespace LinkedList
{
    // Represents a single node in the linked list
    public class ListNode
    {
        public int Value;
        public ListNode Next;

        public ListNode(int value)
        {
            Value = value;
            Next = null;
        }
    }

    public class SinglyLinkedList
    {
        private ListNode head;
        private int count;

        // Constructor: creates an empty linked list
        public SinglyLinkedList()
        {
            head = null;
            count = 0;
        }

        // ─────────────────────────────────────────
        //  BASIC UTILITIES
        // ─────────────────────────────────────────

        // Returns true if the list has no nodes
        public bool IsEmpty() => head == null;

        // Returns the total number of nodes — O(1)
        public int Count() => count;

        // Checks if a value exists in the list — O(n)
        public bool Contains(int target)
        {
            ListNode current = head;
            while (current != null)
            {
                if (current.Value == target) return true;
                current = current.Next;
            }
            return false;
        }

        // Returns the value of the head node — O(1)
        public int? PeekFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty. No first element.");
                return null;
            }
            return head.Value;
        }

        // Returns the value of the tail node — O(n)
        public int? PeekLast()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty. No last element.");
                return null;
            }

            ListNode current = head;
            while (current.Next != null)
                current = current.Next;

            return current.Value;
        }

        // Returns the node at a given index (0-based) — O(n)
        public int? GetAt(int index)
        {
            if (index < 0 || index >= count)
            {
                Console.WriteLine($"Index {index} is out of range.");
                return null;
            }

            ListNode current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            return current.Value;
        }

        // Returns the index of the first occurrence of value — O(n)
        public int IndexOf(int target)
        {
            ListNode current = head;
            int index = 0;

            while (current != null)
            {
                if (current.Value == target) return index;
                current = current.Next;
                index++;
            }

            return -1; // not found
        }

        // ─────────────────────────────────────────
        //  INSERTION
        // ─────────────────────────────────────────

        // Inserts a new node at the beginning — O(1)
        public void AddFirst(int value)
        {
            ListNode newNode = new ListNode(value);
            newNode.Next = head;
            head = newNode;
            count++;
            Console.WriteLine($"'{value}' inserted at head successfully.");
        }

        // Inserts a new node at the end — O(n)
        public void Append(int value)
        {
            if (IsEmpty())
            {
                head = new ListNode(value);
                count++;
                Console.WriteLine($"'{value}' added successfully.");
                return;
            }

            ListNode current = head;
            while (current.Next != null)
                current = current.Next;

            current.Next = new ListNode(value);
            count++;
            Console.WriteLine($"'{value}' added successfully.");
        }

        // Inserts a new node at a given index (0-based) — O(n)
        public void InsertAt(int index, int value)
        {
            if (index < 0 || index > count)
            {
                Console.WriteLine($"Index {index} is out of range.");
                return;
            }

            if (index == 0)
            {
                AddFirst(value);
                return;
            }

            ListNode current = head;
            for (int i = 0; i < index - 1; i++)
                current = current.Next;

            ListNode newNode = new ListNode(value);
            newNode.Next = current.Next;
            current.Next = newNode;
            count++;
            Console.WriteLine($"'{value}' inserted at index {index} successfully.");
        }

        // Inserts a new node directly before the node containing target — O(n)
        public void InsertBefore(int target, int newValue)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty. Cannot insert before a target.");
                return;
            }

            if (!Contains(target))
            {
                Console.WriteLine($"Target value '{target}' not found in the list.");
                return;
            }

            if (head.Value == target)
            {
                AddFirst(newValue);
                return;
            }

            ListNode current = head;
            while (current.Next != null && current.Next.Value != target)
                current = current.Next;

            ListNode newNode = new ListNode(newValue);
            newNode.Next = current.Next;
            current.Next = newNode;
            count++;
            Console.WriteLine($"'{newValue}' inserted before '{target}' successfully.");
        }

        // Inserts a new node directly after the node containing target — O(n)
        public void InsertAfter(int target, int newValue)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty. Cannot insert after a target.");
                return;
            }

            if (!Contains(target))
            {
                Console.WriteLine($"Target value '{target}' not found in the list.");
                return;
            }

            ListNode current = head;
            while (current != null && current.Value != target)
                current = current.Next;

            ListNode newNode = new ListNode(newValue);
            newNode.Next = current!.Next;
            current.Next = newNode;
            count++;
            Console.WriteLine($"'{newValue}' inserted after '{target}' successfully.");
        }

        // ─────────────────────────────────────────
        //  DELETION
        // ─────────────────────────────────────────

        // Deletes the node containing the target value — O(n)
        public void Delete(int target)
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty. Cannot delete.");
                return;
            }

            if (!Contains(target))
            {
                Console.WriteLine($"Target value '{target}' not found in the list.");
                return;
            }

            if (head.Value == target)
            {
                head = head.Next;
                count--;
                Console.WriteLine(
                    head == null
                    ? $"'{target}' deleted successfully. List is now empty."
                    : $"'{target}' deleted successfully from head.");
                return;
            }

            ListNode current = head;
            while (current.Next != null && current.Next.Value != target)
                current = current.Next;

            current.Next = current.Next!.Next;
            count--;
            Console.WriteLine($"'{target}' deleted successfully.");
        }

        // Removes and returns the first node — O(1)
        public int? RemoveFirst()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty. Cannot remove first.");
                return null;
            }

            int value = head.Value;
            head = head.Next;
            count--;
            Console.WriteLine($"'{value}' removed from head successfully.");
            return value;
        }

        // Removes and returns the last node — O(n)
        public int? RemoveLast()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty. Cannot remove last.");
                return null;
            }

            if (head.Next == null)
            {
                int only = head.Value;
                head = null;
                count--;
                Console.WriteLine($"'{only}' removed. List is now empty.");
                return only;
            }

            ListNode current = head;
            while (current.Next.Next != null)
                current = current.Next;

            int value = current.Next.Value;
            current.Next = null;
            count--;
            Console.WriteLine($"'{value}' removed from tail successfully.");
            return value;
        }

        // Removes all nodes — O(1)
        public void Clear()
        {
            head = null;
            count = 0;
            Console.WriteLine("List cleared successfully.");
        }

        // ─────────────────────────────────────────
        //  OPERATIONS
        // ─────────────────────────────────────────

        // Reverses the list in place — O(n)
        public void Reverse()
        {
            if (IsEmpty() || head.Next == null)
            {
                Console.WriteLine("Nothing to reverse.");
                return;
            }

            ListNode prev = null;
            ListNode current = head;

            while (current != null)
            {
                ListNode next = current.Next;
                current.Next = prev;
                prev = current;
                current = next;
            }

            head = prev;
            Console.WriteLine("List reversed successfully.");
        }

        // Copies the list into an array — O(n)
        public int[] ToArray()
        {
            int[] result = new int[count];
            ListNode current = head;

            for (int i = 0; i < count; i++)
            {
                result[i] = current.Value;
                current = current.Next;
            }

            return result;
        }

        // Returns a string representation of the list — O(n)
        public override string ToString()
        {
            if (IsEmpty()) return "Empty list";

            StringBuilder sb = new StringBuilder();
            ListNode current = head;

            while (current != null)
            {
                sb.Append(current.Value);
                if (current.Next != null) sb.Append(" -> ");
                current = current.Next;
            }

            sb.Append(" -> null");
            return sb.ToString();
        }

        // ─────────────────────────────────────────
        //  DISPLAY
        // ─────────────────────────────────────────

        // Displays all elements in the list
        public void PrintAll()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is empty. No items to display.");
                return;
            }

            Console.WriteLine($"List ({count} items): {ToString()}");
            Console.WriteLine("-------------------");

            ListNode current = head;
            int index = 0;

            while (current != null)
            {
                Console.WriteLine($"[{index}] {current.Value}");
                current = current.Next;
                index++;
            }

            Console.WriteLine("-------------------");
        }
    }
}
