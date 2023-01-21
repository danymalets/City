using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Components.Collections
{
    public readonly struct ListOf<T> : IComponent, IEnumerable<T>
    {
        public readonly List<T> List;

        public ListOf(int reservedSize = 0)
        {
            List = new List<T>(reservedSize);
        }
        
        public ListOf(IEnumerable<T> en)
        {
            List = en.ToList();
        }

        public int Length =>
            List.Count;

        public void Add(T el) =>
            List.Add(el); 
        
        public void Remove(T el) =>
            List.Remove(el);

        public void Clear() =>
            List.Clear();

        public IEnumerator<T> GetEnumerator() =>
            List.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            List.GetEnumerator();
    }
}