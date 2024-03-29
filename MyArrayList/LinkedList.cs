﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLists
{
    public class LinkedList : IMyList
    {
        private Node _root;

        private Node _tail;

        public int this[int index]
        {
            get
            {
                if (Lenght == 0)
                {
                    throw new ArgumentException("LinkedList is empty");
                }
                if (index < 0 || index > Lenght)
                {
                    throw new IndexOutOfRangeException();
                }
                Node crnt = _root;
                for (int i = 1; i <= index; i++)
                {
                    crnt = crnt.Next;
                }
                return crnt.Value;
            }
            set
            {
                if (index < 0 || index > Lenght)
                {
                    throw new IndexOutOfRangeException();
                }
                Node crnt = _root;
                for (int i = 1; i <= index; i++)
                {
                    crnt = crnt.Next;
                }
                crnt.Value = value;
            }
        }

        public int Lenght
        {
            get
            {
                int count = 0;
                Node crnt = _root;
                while (crnt != null)
                {
                    crnt = crnt.Next;
                    count++;
                }
                return count;
            }
            private set { }
        }

        // 3 конструктора(пустой, на основе одного элемента, на основе массива) (task 23)
        public LinkedList()
        {
            _root = null;
            _tail = null;
        }

        public LinkedList(int value)
        {
            _root = new Node(value);
            _tail = _root;
        }

        public LinkedList(int[] array)
        {
            if (array is null || array.Length == 0)
            {
                _root = null;
                _tail = null;
            }
            else
            {
                _root = new Node(array[0]);
                Node crnt = _root;
                for (int i = 1; i < array.Length; i++)
                {
                    crnt.Next = new Node(array[i]);
                    crnt = crnt.Next;
                    _tail = crnt;
                }
            }
        }

        // добавление значения в конец (task 1)
        public void AddLast(int value)
        {
            if (_root is null)
            {
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                _tail.Next = new Node(value);
                _tail = _tail.Next;
            }
        }

        // добавление значения в начало (task 2)
        public void AddFirst(int value)
        {
            if (_root is null)
            {
                _root = new Node(value);
                _tail = _root;
            }
            else
            {
                Node crnt = _root;
                _root = new Node(value);
                _root.Next = crnt;
            }
        }

        // добавление значения по индексу (task 3)
        public void Insert(int index, int value)
        {
            if (index < 0 || index > Lenght - 1)
            {
                throw new IndexOutOfRangeException();
            }
            else if (_root is null)
            {
                throw new NullReferenceException();
            }
            Node crnt = _root;
            if (index == 0)
            {
                _root = new Node(value);
                _root.Next = crnt;
            }
            else
            {
                Node tmp;
                for (int i = 1; i < index; i++)
                {
                    crnt = crnt.Next;

                }
                tmp = crnt.Next;
                crnt.Next.Value = value;
                crnt.Next = tmp;
            }
        }

        // удаление из конца одного элемента (task 4)
        public void RemoveLast()
        {
            if (_root is null)
            {
                throw new NullReferenceException();
            }
            _tail = null;
        }

        // удаление из начала одного элемента (task 5)
        public void RemoveFirst()
        {
            if (_root is null)
            {
                throw new NullReferenceException();
            }
            _root = _root.Next;
        }

        // удаление по индексу одного элемента (task 6)
        public void RemoveByIndex(int index)
        {
            if (index < 0 || index > Lenght - 1)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                _root = _root.Next;
            }
            else
            {
                Node crnt = _root;
                for (int i = 1; i < index; i++)
                {
                    crnt = crnt.Next;
                }
                crnt.Next = crnt.Next.Next;
            }
        }

        // удаление из конца N элементов (task 7)
        public void RemoveRangeFromEnd(int count)
        {
            if (count < 0 || count > Lenght)
            {
                throw new ArgumentException("count must be > 0 & < lenght");
            }
            Node crnt = _root;
            for (int i = 0; i < Lenght - count - 1; i++)
            {
                crnt = crnt.Next;
            }
            _tail = crnt;
        }

        // удаление из начала N элементов (task 8)
        public void RemoveRangeFromBeginning(int count)
        {
            if (count < 0 || count > Lenght)
            {
                throw new ArgumentException("count must be > 0 & < lenght");
            }
            Node crnt = _root;
            for (int i = 0; i < count; i++)
            {
                crnt = crnt.Next;
            }
            _root = crnt;
        }

        // удаление по индексу N элементов (task 9)
        public void RemoveRangeFromIndex(int index, int count)
        {
            if (index < 0 || index > Lenght - 1)
            {
                throw new IndexOutOfRangeException();
            }
            else if (count < 0 || count > Lenght)
            {
                throw new ArgumentException("count must be >= 0 & < lenght");
            }
            else if (count + index > Lenght)
            {
                throw new ArgumentException("not enough elements to delete");
            }
            else
            {
                Node crnt = _root;
                Node prev = crnt;
                for (int i = index - 1; i < index + count - 1; i++)
                {
                    crnt = crnt.Next;
                }
                if (index == 0)
                {
                    _root = crnt;
                }
                prev.Next = crnt.Next;
            }
        }

        // вернуть длину (task 10)
        public int GetLenght()
        {
            return Lenght;
        }

        // первый индекс по значению(-1 - не нашел) (task 12)
        public int ReturnFirstIndex(int value)
        {
            int result = -1;
            Node crnt = _root;
            for (int i = 0; i < Lenght; i++)
            {
                if (crnt.Value == value)
                {
                    result = i;
                    break;
                }
                crnt = crnt.Next;
            }
            return result;
        }

        // реверс(123 -> 321) (task 14)
        public void Reverse()
        {
            Node crnt = _root;
            Node prev = null;
            Node next = null;
            while (crnt != null)
            {
                next = crnt.Next;                
                crnt.Next = prev;
                prev = crnt;
                crnt = next;
            }
            _root = prev;
        }

        // поиск значения максимального элемента (task 15)
        public int FindMaxValue()
        {
            if (Lenght == 0)
            {
                throw new ArgumentException("LinkedList is empty");
            }
            Node prev = _root;
            Node crnt = _root.Next;
            int result = prev.Value;
            while (crnt != null)
            {
                if (crnt.Value > prev.Value)
                {
                    result = crnt.Value;
                }
                crnt = crnt.Next;
            }
            return result;
        }

        // поиск значения минимального элемента (task 16)
        public int FindMinValue()
        {
            if (Lenght == 0)
            {
                throw new ArgumentException("LinkedList is empty");
            }
            Node prev = _root;
            Node crnt = _root.Next;
            int result = prev.Value;
            while (crnt != null)
            {
                if (crnt.Value < prev.Value)
                {
                    result = crnt.Value;
                }
                crnt = crnt.Next;
            }
            return result;
        }

        // поиск индекса максимального элемента (task 17)
        public int FindIndexOfMaxValue()
        {
            if (_root is null)
            {
                throw new NullReferenceException();
            }
            int result = -1;
            Node crnt = _root;
            for (int i = 0; i < Lenght; i++)
            {
                if (crnt.Value > crnt.Next.Value)
                {
                    result = i;
                }
                crnt = crnt.Next;
            }
            return result;
        }

        // поиск индекс минимального элемента (task 18)
        public int FindIndexOfMinValue()
        {
            if (_root is null)
            {
                throw new NullReferenceException();
            }
            int result = -1;
            Node crnt = _root;
            for (int i = 0; i < Lenght; i++)
            {
                if (crnt.Value < crnt.Next.Value)
                {
                    result = i;
                }
                crnt = crnt.Next;
            }
            return result;
        }

        // сортировка по возрастанию (task 19)
        public void SortAscending()
        {
            int l = Lenght;
            Node crnt;
            Node prev;

            for (int i = l - 2; i >= 0; i--)
            {
                if (i == 0)
                {
                    crnt = _root;
                    if (crnt.Next != null && crnt.Value > crnt.Next.Value)
                    {
                        _root = crnt.Next;
                        crnt.Next = _root.Next;
                        _root.Next = crnt;
                    }
                    prev = _root;
                }
                else
                {
                    prev = GetNodeByIndex(i - 1);
                    crnt = prev.Next;
                }
                while (crnt.Next != null && crnt.Value > crnt.Next.Value)
                {
                    prev.Next = crnt.Next;
                    crnt.Next = prev.Next.Next;
                    prev.Next.Next = crnt;
                    prev = prev.Next;
                }
            }
            _tail = GetNodeByIndex(l - 1);
        }

        // сортировка по убыванию (task 20)
        public void SortDescending()
        {
            int l = Lenght;
            Node crnt;
            Node prev;

            for (int i = l - 2; i >= 0; i--)
            {
                if (i == 0)
                {
                    crnt = _root;
                    if (crnt.Next != null && crnt.Value < crnt.Next.Value)
                    {
                        _root = crnt.Next;
                        crnt.Next = _root.Next;
                        _root.Next = crnt;
                    }
                    prev = _root;
                }
                else
                {
                    prev = GetNodeByIndex(i - 1);
                    crnt = prev.Next;
                }
                while (crnt.Next != null && crnt.Value < crnt.Next.Value)
                {
                    prev.Next = crnt.Next;
                    crnt.Next = prev.Next.Next;
                    prev.Next.Next = crnt;
                    prev = prev.Next;
                }
            }
            _tail = GetNodeByIndex(l - 1);
        }

        // удаление по значению первого(вернуть индекс)(-1 - ничего не удалил) (task 21)
        public int ClearFirstValue(int value)
        {
            if (_root is null)
            {
                throw new NullReferenceException();
            }
            int result = -1;
            Node crnt = _root;
            for (int i = 0; i < Lenght; i++)
            {
                if (crnt.Next.Value == value)
                {
                    crnt = crnt.Next.Next;
                    result = i;
                    break;
                }
                crnt = crnt.Next;
            }
            return result;
        }

        // удаление по значению всех(вернуть кол-во)(0 - ничего не удалил) (task 22)
        public int ClearAllByValue(int value)
        {
            if (_root is null)
            {
                throw new NullReferenceException();
            }
            int result = 0;
            Node crnt = _root;
            for (int i = 0; i < Lenght; i++)
            {
                if (crnt.Next.Value == value)
                {
                    crnt = crnt.Next.Next;
                    result++;
                }
                crnt = crnt.Next;
            }
            return result;
        }

        // добавление списка(вашего самодельного) в конец (task 24)
        public void AddListLast(LinkedList list)
        {
            if (list._root == null || _root == null)
            {
                throw new NullReferenceException();
            }
            _tail = GetNodeByIndex(Lenght - 1);
            _tail.Next = list._root;
            _tail = list._tail;
        }

        // добавление списка в начало (task 25)
        public void AddListFirst(LinkedList list)
        {
            if (list._root == null || _root == null)
            {
                throw new NullReferenceException();
            }
            list._tail = GetNodeByIndex(Lenght - 1);
            list._tail.Next = _root;
            //_root = list._root;
        }

        // добавление списка по индексу (task 26)
        public void AddListByIndex(LinkedList list, int index)
        {
            if (index < 0 || index > Lenght)
            {
                throw new IndexOutOfRangeException();
            }
            if (list._root == null || _root == null)
            {
                throw new NullReferenceException();
            }
            if (index == 0)
            {
                AddListFirst(list);
            }
            else if (index == Lenght)
            {
                AddListLast(list);
            }
            else
            {
                Node tmp = _root;
                Node crnt = list._root;
                for (int i = 0; i < index - 1; i++)
                {
                    tmp = tmp.Next;
                }
                while (crnt.Next != null)
                {
                    crnt = crnt.Next;
                }
                crnt.Next = tmp.Next;
                tmp.Next = list._root;
            }
        }

        public override string ToString()
        {
            string s = "[ ";
            Node crnt = _root;
            while (crnt != null)
            {
                s += $"{crnt.Value} ";
                crnt = crnt.Next;
            }
            s += "]";
            return s;
        }

        public override bool Equals(object? obj)
        {
            bool isEqual = true;
            if (obj is null || !(obj is LinkedList))
            {
                isEqual = false;
            }
            else
            {
                LinkedList list = (LinkedList)obj;
                if (list.Lenght != this.Lenght)
                {
                    isEqual = false;
                }
                else
                {
                    Node thisCrnt = this._root;
                    Node listCrnt = list._root;
                    while (thisCrnt != null)
                    {
                        if (thisCrnt.Value != listCrnt.Value)
                        {
                            isEqual = false;
                        }
                        thisCrnt = thisCrnt.Next;
                        listCrnt = listCrnt.Next;
                    }
                }
            }
            return isEqual;
        }

        private Node GetNodeByIndex(int index)
        {
            Node crnt = _root;
            for (int i = 1; i <= index; i++)
            {
                crnt = crnt.Next;
            }
            return crnt;
        }
    }
}
