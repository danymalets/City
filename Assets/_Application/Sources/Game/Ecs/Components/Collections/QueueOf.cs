using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Components.Collections
{
    public readonly struct QueueOf<T> : IComponent, IEnumerable<T>
    {
        public readonly Queue<T> Queue;

        public QueueOf(int reservedSize = 0)
        {
            Queue = new Queue<T>(reservedSize);
        }
        
        public QueueOf(IEnumerable<T> en)
        {
            Queue = new Queue<T>(en);
        }

        public int Count =>
            Queue.Count;

        public void Enqueue(T el) =>
            Queue.Enqueue(el);
        
        public T Dequeue() =>
            Queue.Dequeue();

        public void Clear() =>
            Queue.Clear();

        public IEnumerator<T> GetEnumerator() =>
            Queue.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            Queue.GetEnumerator();
    }
}