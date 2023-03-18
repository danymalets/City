using System;
using UnityEngine;

namespace Sources.Utilities
{
    public class MonoData : MonoBehaviour
    {
        public new virtual GameObject gameObject => throw new InvalidOperationException();
        public new T GetComponent<T>() => throw new InvalidOperationException();
        public new bool TryGetComponent<T>(out T component) => throw new InvalidOperationException();
    }
}