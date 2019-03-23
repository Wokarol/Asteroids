using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wokarol.BetweenSceneManagment
{
    [CreateAssetMenu]
    public class BetweenSceneData : ScriptableObject
    {
        // Consts
        private const string debugPrefix = "<b>Serializer: </b>";

        // Inspector variables
        [SerializeField] string destription;

        // ------
        Dictionary<string, object> data = new Dictionary<string, object>();

        /// <summary>
        /// Sets value
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void SetData(string key, object value)
        {
            if (data.ContainsKey(key)) {
                data[key] = value;
            } else {
                data.Add(key, value);
            }
        }

        /// <summary>
        /// Gets data, if no data is under the key returns and sets default
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public T GetData<T>(string key, T defaultValue)
        {
            if (data.ContainsKey(key)) {
                if (data[key] is T) {
                    return (T)data[key];
                }
            }
            SetData(key, defaultValue);
            return defaultValue;
        }

        public void Clear()
        {
            data.Clear();
        }

        public void Remove(string key)
        {
            if(data.ContainsKey(key)){
                data.Remove(key);
            }
        }

        public bool Contains(string key)
        {
            return data.ContainsKey(key);
        }
    } 
}
