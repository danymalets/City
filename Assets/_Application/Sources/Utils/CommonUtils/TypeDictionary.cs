using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sources.Utils.CommonUtils
{
    public class TypeDictionary<TBase> : IEnumerable<KeyValuePair<Type, TBase>>
        where TBase : class
    {
        private readonly Dictionary<Type, TBase> _dictionary = new();
        public IEnumerable<TBase> Values =>
            _dictionary.Select(p => p.Value);

        public void Add<TElement>(TElement element) 
            where TElement: TBase
        {
            _dictionary[element.GetType()] = element;
        }

        public bool TryGet<TElement>(out TElement element)
            where TElement: class, TBase
        {
            if (_dictionary.TryGetValue(typeof(TElement), out TBase elementBase))
            {
                element = (TElement)elementBase;
                return true;
            }
            else
            {
                element = default;
                return false;
            }
        }

        public TElement Get<TElement>() 
            where TElement : class, TBase
        {
            if (TryGet(out TElement element))
            {
                return element;
            }
            else
            {
                throw new KeyNotFoundException();
            }
        }

        public void AddRange(IEnumerable<TBase> screenControllers)
        {
            foreach (TBase screenController in screenControllers)
            {
                Add(screenController);
            }
        }


        public IEnumerator<KeyValuePair<Type, TBase>> GetEnumerator() => 
            _dictionary.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => 
            GetEnumerator();
    }
}