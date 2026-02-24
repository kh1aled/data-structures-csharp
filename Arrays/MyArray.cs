using System;

namespace MyApp
{
    public class MyArray
    {
        private int[] data;
        private int size;
        private int length;

        public MyArray(int size)
        {
            this.size = size;
            data = new int[size];
            length = 0;
        }

        public void Print()
        {
            if (length == 0)
            {
                Console.WriteLine("Array is empty.");
                return;
            }
            for (int i = 0; i < length; i++)
            {
                Console.Write(data[i] + " ");
            }
            Console.WriteLine();
        }
        public void Append(int value)
        {
            if (length >= size)
            {
                Console.WriteLine("Array is full!");
                return;
            }

            data[length] = value;
            length++;
        }
        public int[] getData() { return data; }
        public int getSize() { return size; }
        public int getLength() { return length; }

        public void Fill()
        {
            Console.WriteLine("How many items do you want to fill?");

            if (!int.TryParse(Console.ReadLine(), out int count))
            {
                Console.WriteLine("Invalid number!");
                return;
            }

            if (count <= 0 || count > (size - length))
            {
                Console.WriteLine($"Available space is {size - length}");
                return;
            }

            for (int i = 0; i < count; i++)
            {
                Console.Write($"Enter number item {i + 1}: ");
                if (!int.TryParse(Console.ReadLine(), out int value))
                {
                    Console.WriteLine("Invalid number!");
                    return;
                }
                data[length++] = value;
            }

            Console.WriteLine("Created Successfully");
            Print();
        }

        public void Insert(int index, int newItemValue)
        {
            if (!CheckSize())
            {
                Console.WriteLine("Array is full...");
                return;
            }

            if (index < 0 || index > length)
            {
                Console.WriteLine("Invalid index!");
                return;
            }

            for (int i = length; i > index; i--)
            {
                data[i] = data[i - 1];
            }
            data[index] = newItemValue;
            length++;
            Console.WriteLine($"Item {newItemValue} inserted at index {index}");
            Print();
        }

        public void Search(int key)
        {
            int result = -1;
            int foundIndex = -1;

            for (int i = 0; i < length; i++)
            {
                if (data[i] == key)
                {
                    result = 1;
                    foundIndex = i;
                    break;
                }
            }

            if (result != -1)
                Console.WriteLine($"Item found: {data[foundIndex]} at index {foundIndex}");
            else
            {
                Console.WriteLine("Item not found");
                Print();
            }
        }

        public bool CheckSize() { return length < size; }

        public void Delete(int index)
        {
            if (index >= 0 && index < length)
            {
                for (int i = index; i < length - 1; i++)
                {
                    data[i] = data[i + 1];
                }
                length--;
                Console.WriteLine("Item Deleted");
                Print();
            }
            else
            {
                Console.WriteLine("Out of scope");
            }
        }

        public void Enlarge(int newArraySize)
        {
            if (newArraySize <= length)
            {
                Console.WriteLine("New size must be greater than current length.");
                return;
            }

            int[] oldItems = data;
            data = new int[newArraySize];
            size = newArraySize;

            for (int i = 0; i < length; i++)
            {
                data[i] = oldItems[i];
            }

            Console.WriteLine($"Array enlarged to size {newArraySize}");
            Print();
        }

        public void Merge(MyArray otherArray)
        {
            if ((size - length) >= otherArray.length)
            {
                for (int i = 0; i < otherArray.length; i++)
                {
                    data[length + i] = otherArray.getData()[i];
                }
                length += otherArray.length;
                Console.WriteLine("Arrays Merged Successfully");
                Print();
            }
            else
            {
                Console.WriteLine("Sorry!, No size available for new items from other array");
            }
        }



    } 

    internal class Program
    {
        static void Main(string[] args)
        {
            MyArray arr = new MyArray(6);
            //arr.Append(10);
            //arr.Append(20);
            //arr.Append(30);
            //arr.Append(40);
            //arr.Print(); 10 20 30 40

            Console.WriteLine("\n===== Test Append When Full =====");
            arr.Append(50);
            arr.Append(60);
            arr.Append(70); // Array is full!

            // ─── Test Insert ───────────────────────────────────────
            Console.WriteLine("\n===== Test Insert =====");
            MyArray arr2 = new MyArray(6);
            arr2.Append(10);
            arr2.Append(20);
            arr2.Append(30);
            arr2.Insert(1, 99);
            // Expected: 10 99 20 30

            Console.WriteLine("\n===== Test Insert Invalid Index =====");
            arr2.Insert(99, 5);
            // Expected: Invalid index!

            Console.WriteLine("\n===== Test Insert When Full =====");
            arr2.Append(40);
            arr2.Append(50);
            arr2.Insert(0, 1);
            // Expected: Array is full...

            // ─── Test Search ───────────────────────────────────────
            Console.WriteLine("\n===== Test Search Found =====");
            arr2.Search(99);
            // Expected: Item found: 99 at index 1

            Console.WriteLine("\n===== Test Search Not Found =====");
            arr2.Search(999);
            // Expected: Item not found

            // ─── Test Delete ───────────────────────────────────────
            Console.WriteLine("\n===== Test Delete =====");
            arr2.Delete(1);
            // Expected: Item Deleted → 10 20 30 40 50

            Console.WriteLine("\n===== Test Delete Out of Scope =====");
            arr2.Delete(99);
            // Expected: Out of scope

            // ─── Test Enlarge ──────────────────────────────────────
            Console.WriteLine("\n===== Test Enlarge =====");
            arr2.Enlarge(15);
            // Expected: Array enlarged to size 15 → 10 20 30 40 50

            Console.WriteLine("\n===== Test Enlarge With Smaller Size =====");
            arr2.Enlarge(2);
            // Expected: New size must be greater than current length.

            // ─── Test Merge ────────────────────────────────────────
            Console.WriteLine("\n===== Test Merge Success =====");
            MyArray arr3 = new MyArray(10);
            arr3.Append(1);
            arr3.Append(2);
            arr3.Append(3);

            MyArray arr4 = new MyArray(5);
            arr4.Append(4);
            arr4.Append(5);
            arr4.Append(6);

            arr3.Merge(arr4);
            // Expected: Arrays Merged Successfully → 1 2 3 4 5 6

            Console.WriteLine("\n===== Test Merge No Space =====");
            MyArray arr5 = new MyArray(4);
            arr5.Append(1);
            arr5.Append(2);
            arr5.Append(3);
            arr5.Append(4); // full

            MyArray arr6 = new MyArray(3);
            arr6.Append(5);
            arr6.Append(6);

            arr5.Merge(arr6);
            // Expected: Sorry!, No size available...

            // ─── Test Enlarge then Merge ───────────────────────────
            Console.WriteLine("\n===== Test Enlarge Then Merge =====");
            arr5.Enlarge(10);
            arr5.Merge(arr6);
            // Expected: Arrays Merged Successfully → 1 2 3 4 5 6
        }
    }

}
