#if UNITY_2021_1_OR_NEWER
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Rendering;

namespace Gilzoide.NonAllocEnumeration
{
    public static class ComponentEnumeration
    {
        public static NonAllocEnumerable<PooledListEnumerator<T>, T> EnumerateComponents<T>(this GameObject gameObject)
        {
            List<T> list = ListPool<T>.Get();
            gameObject.GetComponents(list);
            return new NonAllocEnumerable<PooledListEnumerator<T>, T>(new PooledListEnumerator<T>(list));
        }

        public static NonAllocEnumerable<PooledListEnumerator<T>, T> EnumerateComponents<T>(this Component component)
        {
            return component.gameObject.EnumerateComponents<T>();
        }

#if UNITY_5_3_OR_NEWER
        public static NonAllocEnumerable<PooledListEnumerator<T>, T> EnumerateComponentsInChildren<T>(this GameObject gameObject, bool includeInactive = false)
        {
            List<T> list = ListPool<T>.Get();
            gameObject.GetComponentsInChildren(includeInactive, list);
            return new NonAllocEnumerable<PooledListEnumerator<T>, T>(new PooledListEnumerator<T>(list));
        }

        public static NonAllocEnumerable<PooledListEnumerator<T>, T> EnumerateComponentsInChildren<T>(this Component component, bool includeInactive = false)
        {
            return component.gameObject.EnumerateComponentsInChildren<T>(includeInactive);
        }

        public static NonAllocEnumerable<PooledListEnumerator<T>, T> EnumerateComponentsInParent<T>(this GameObject gameObject, bool includeInactive = false)
        {
            List<T> list = ListPool<T>.Get();
            gameObject.GetComponentsInParent(includeInactive, list);
            return new NonAllocEnumerable<PooledListEnumerator<T>, T>(new PooledListEnumerator<T>(list));
        }

        public static NonAllocEnumerable<PooledListEnumerator<T>, T> EnumerateComponentsInParent<T>(this Component component, bool includeInactive = false)
        {
            return component.gameObject.EnumerateComponentsInParent<T>(includeInactive);
        }
#endif

#if UNITY_2018_2_OR_NEWER
        public static NonAllocEnumerable<PooledListEnumerator<Material>, Material> EnumerateMaterials(this Renderer renderer)
        {
            List<Material> list = ListPool<Material>.Get();
            renderer.GetMaterials(list);
            return new NonAllocEnumerable<PooledListEnumerator<Material>, Material>(new PooledListEnumerator<Material>(list));
        }

        public static NonAllocEnumerable<PooledListEnumerator<Material>, Material> EnumerateSharedMaterials(this Renderer renderer)
        {
            List<Material> list = ListPool<Material>.Get();
            renderer.GetSharedMaterials(list);
            return new NonAllocEnumerable<PooledListEnumerator<Material>, Material>(new PooledListEnumerator<Material>(list));
        }
#endif

        public static NonAllocEnumerable<PooledListEnumerator<ReflectionProbeBlendInfo>, ReflectionProbeBlendInfo> EnumerateClosestReflectionProbes(this Renderer renderer)
        {
            List<ReflectionProbeBlendInfo> list = ListPool<ReflectionProbeBlendInfo>.Get();
            renderer.GetClosestReflectionProbes(list);
            return new NonAllocEnumerable<PooledListEnumerator<ReflectionProbeBlendInfo>, ReflectionProbeBlendInfo>(new PooledListEnumerator<ReflectionProbeBlendInfo>(list));
        }
    }

    public struct PooledListEnumerator<T> : IEnumerator<T>
    {
        private List<T> _list;
        private int _index;

        public PooledListEnumerator(List<T> list)
        {
            _list = list;
            _index = -1;
        }

        public T Current => _list[_index];
        object IEnumerator.Current => Current;

        public void Dispose()
        {
            ListPool<T>.Release(_list);
        }

        public bool MoveNext()
        {
            int newIndex = _index + 1;
            if (newIndex >= 0 && newIndex < _list.Count)
            {
                _index = newIndex;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
#endif