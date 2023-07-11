using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloCSharp
{
    //generic type
   public class Stack<T>
   {
        Entry _top;

        public void Push(T data) {
            _top = new Entry(_top,data);
         }

        public  T Pop()
        {
            if( _top == null ) {
                throw new InvalidOperationException();
            }
            T result =_top.Data; 
            _top =_top.Next;
            return result;
        }

        class Entry {
            public Entry Next { get; set; }
            public T Data { get; set; }

            public Entry(Entry next, T data) {
                Next = next;
                Data = data;
            }
        }
   }
}
