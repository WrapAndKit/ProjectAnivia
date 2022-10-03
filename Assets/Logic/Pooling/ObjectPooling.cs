using System.Collections.Generic;
using UnityEngine;

namespace Assets.Logic.Pooling {
    public sealed class ObjectPooling<T> where T : MonoBehaviour {
        #region Data

        private List<T> p_objects;
        private Transform p_parent;
        private System.Random p_randomizer;

        public int Size => (p_objects is null) ? 0 : p_objects.Count;

        #endregion

        public void Initialize(Transform parent, int count, T sample) {
            p_objects = new List<T>();
            p_parent = parent;
            for (int i = 0; i < count; i++) {
                AddObject(sample);
            }
            p_randomizer = new System.Random();
        }


        public void AddObject(T sample) {
            GameObject tmp = GameObject.Instantiate(sample.gameObject);
            tmp.name = sample.name;
            tmp.transform.SetParent(p_parent);
            p_objects.Add(tmp.GetComponent<T>());
            tmp.SetActive(false);
        }

        public T GetObject() {
            foreach (T obj in p_objects) {
                if (obj.gameObject.activeInHierarchy == false) {
                    return obj;
                }
            }
            AddObject(p_objects[p_randomizer.Next(0, p_objects.Count)]);
            return p_objects[p_objects.Count - 1];
        }

        public void Clear() {
            foreach (T obj in p_objects) {
                GameObject.Destroy(obj.gameObject);
            }
            p_objects.Clear();
        }
    }
}
