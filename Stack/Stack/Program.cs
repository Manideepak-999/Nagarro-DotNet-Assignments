using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack
{
    class Program
    {
        class Stack<T>
        {
            private T[] items;
            private int top;
            private int capacity;

            public Stack() //Construction
            {
                this.capacity = 10000;
                this.items = new T[this.capacity];
                this.top = -1;
            }
            public Stack(int capacity) //Parametrer defining "capacity"
            {
                this.capacity = capacity;
                this.items = new T[capacity];
                this.top = -1;
            }

            public void Push(T item) //Adding item to the stack
            {
                if (!IsFull())
                {
                    items[++top] = item;
                }
                else
                {
                    throw new Exception("Stack is full");
                }
            }

            public T Pop() //Returns the top item without any deletion
            {
                if (!IsEmpty())
                {
                    return items[top--];
                }
                else
                {
                    throw new Exception("Stack is empty");
                }
            }

            public T Peek() //Views first element in stack without any deletion
            {
                return items[top];
            }

            public bool Contains(T item) //Contains value in Stack
            {
                for (int i = 0; i < top; i++)
                {
                    if (item.Equals(items[i]))
                    {
                        return true;
                    }
                }
                return false;
            }

            public int Size() //Size
            {
                return top + 1;
            }

            public bool IsEmpty() //Check for Stack empty or not
            {
                return top == -1;
            }

            public bool IsFull() //Check for Stack full or not
            {
                return top == capacity - 1;
            }

            public void Reverse() //Reverse
            {
                T[] itemsTemp = new T[top + 1];
                int counter = top;
                for (int i = 0; i <= top; i++)
                {
                    itemsTemp[counter] = items[i];
                    counter--;
                }
                items = itemsTemp;
            }

            public void Print()
            {
                if (IsEmpty())
                {
                    throw new Exception("Stack is Empty");
                }
                else
                {
                    Console.WriteLine("Items in the stack are:");
                    for (int i = top; i >= 0; i--)
                    {
                        Console.WriteLine(items[i]);
                    }
                }
            }
        }

        class StackIterator<T>
        {
            private Stack<T> currentStack;

            public StackIterator(Stack<T> currentStack)
            {
                this.currentStack = currentStack;
            }
            public bool IsEmpty()
            {
                return this.currentStack.IsEmpty();
            }
            public T Pop()
            {
                return this.currentStack.Pop();
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Stack <int> stack = new Stack<int>(5);
                stack.Push(8);
                stack.Push(5);
                stack.Push(10);
                stack.Push(2);
                stack.Push(99);
                stack.Print();
                Console.WriteLine("Stack size is: {0}", stack.Size());
                stack.Reverse();
                Console.WriteLine("Reverse");
                stack.Print();
                if (stack.Contains(10))
                {
                    Console.WriteLine("Stack contains item 10");
                }
                else
                {
                    Console.WriteLine("Stack does not contain item 10");
                }


                if (stack.Contains(546))
                {
                    Console.WriteLine("Stack contains item 546");
                }
                else
                {
                    Console.WriteLine("Stack does not contain item 546");
                }
                Console.WriteLine("The top item is {0}", stack.Peek());
                Console.WriteLine("Delete the top item: {0}", stack.Pop());
                Console.WriteLine("Stack size is: {0}", stack.Size());
                StackIterator<int> stackIterator = new StackIterator<int>(stack);
                Console.WriteLine("\nDisplay items using StackIterator");
                while (!stackIterator.IsEmpty())
                {
                    Console.WriteLine(stackIterator.Pop());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}
