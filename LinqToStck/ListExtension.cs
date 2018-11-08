using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToStck
{
    public static class ListExtension
    {
        public static List<T> Push<T>(this List<T> stack, T item)
        {
            stack.Add(item);
            return stack;
        }

        public static (List<T> Stack, T Element) Pop<T>(this List<T> stack)
        {
            if (stack.Count < 1) return (Stack: stack, Element: default(T));

            var tos = stack.ElementAt(stack.Count - 1);
            stack.RemoveAt(stack.Count - 1);

            return (Stack: stack, Element: tos);
        }
        
        public static List<T> Drop<T>(this List<T> stack)
        {
            return stack.Pop().Stack;
        }

        public static List<T> Dup<T>(this List<T> stack)
        {
            (var s, var e) = stack.Pop();
            if (isDefault(e))
            {
                return stack;
            }

            return s.Push(e).Push(e);
        }

        public static List<T> Dup2<T>(this List<T> stack)
        {
            (var _, var e1) = stack.Pop();
            (var s, var e2) = stack.Pop();
            if (isDefault(e1) || isDefault(e2))
            {
                return s;
            }

            return s.Push(e2).Push(e1).Push(e2).Push(e1);
        }

        public static List<T> Rot<T>(this List<T> stack)
        {
            (var _, var e1) = stack.Pop();
            (var _, var e2) = stack.Pop();
            (var s, var e3) = stack.Pop();
            if (isDefault(e1) || isDefault(e2) || isDefault(e3))
            {
                return stack;
            }

            return s.Push(e2).Push(e1).Push(e3);
        }

        private static bool isDefault<T>(T value)
        {
            return EqualityComparer<T>.Default.Equals(value, default(T));
        }
    }
}
