using System;
using UnityEngine;

namespace _Application.Sources.Utils.CommonUtils.Libs
{
    public class MonoData : MonoBehaviour
    {
        public new GameObject gameObject => throw new InvalidOperationException();
        public new T GetComponent<T>() => throw new InvalidOperationException();
        public new bool TryGetComponent<T>(out T component) => throw new InvalidOperationException();
        protected GameObject GameObject => base.gameObject;
    }
}