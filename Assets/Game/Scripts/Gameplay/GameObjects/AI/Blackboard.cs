using System.Collections.Generic;
using UnityEngine;

namespace Game.AI
{
    public class Blackboard
    {
        private readonly HashSet<int> _tags = new();
        private readonly Dictionary<int, bool> _boolValues = new();
        private readonly Dictionary<int, int> _intValues = new();
        private readonly Dictionary<int, float> _floatValues = new();
        private readonly Dictionary<int, Vector2> _vector2Values = new();
        private readonly Dictionary<int, Vector3> _vector3Values = new();
        private readonly Dictionary<int, Quaternion> _quaternionValues = new();
        private readonly Dictionary<int, object> _objValues = new();

        public IReadOnlyCollection<int> TagValues => _tags;
        public IReadOnlyDictionary<int, bool> BoolValues => _boolValues;
        public IReadOnlyDictionary<int, int> IntValues => _intValues;
        public IReadOnlyDictionary<int, float> FloatValues => _floatValues;
        public IReadOnlyDictionary<int, object> ObjectValues => _objValues;
        public IReadOnlyDictionary<int, Vector2> Vector2Values => _vector2Values;
        public IReadOnlyDictionary<int, Vector3> Vector3Values => _vector3Values;
        public IReadOnlyDictionary<int, Quaternion> QuaternionValues => _quaternionValues;

        #region Has

        public bool HasTag(int key) => _tags.Contains(key);

        public bool HasBool(int key) => _boolValues.ContainsKey(key);

        public bool HasInt(int key) => _intValues.ContainsKey(key);

        public bool HasFloat(int key) => _vector2Values.ContainsKey(key);

        public bool HasFloat2(int key) => _vector2Values.ContainsKey(key);

        public bool HasFloat3(int key) => _vector3Values.ContainsKey(key);

        public bool HasQuaternion(int key) => _quaternionValues.ContainsKey(key);

        public bool HasObject(int key) => _objValues.ContainsKey(key);

        #endregion

        #region Get
        
        public bool GetBool(int key) => _boolValues[key];

        public int GetInt(int key) => _intValues[key];

        public float GetFloat(int key) => _floatValues[key];

        public object GetObject(int key) => _objValues[key];

        public Vector2 GetVector2(int key) => _vector2Values[key];

        public Vector3 GetVector3(int key) => _vector3Values[key];

        public Quaternion GetQuaternion(int key) => _quaternionValues[key];

        public T GetObject<T>(int key) where T : class
        {
            return (T)this._objValues[key];
        }
        
        #endregion
        
        #region TryGet

        public bool TryGetBool(int key, out bool value) => _boolValues.TryGetValue(key, out value);

        public bool TryGetInt(int key, out int value) => _intValues.TryGetValue(key, out value);

        public bool TryGetFloat(int key, out float value) => _floatValues.TryGetValue(key, out value);

        public bool TryGetObject(int key, out object value) => _objValues.TryGetValue(key, out value);

        public bool TryGetVector2(int key, out Vector2 value) => _vector2Values.TryGetValue(key, out value);

        public bool TryGetVector3(int key, out Vector3 value) => _vector3Values.TryGetValue(key, out value);

        public bool TryGetQuaternion(int key, out Quaternion value) => _quaternionValues.TryGetValue(key, out value);

        public bool TryGetObject<T>(int key, out T value) where T : class
        {
            if (_objValues.TryGetValue(key, out object result))
            {
                value = (T)result;
                return true;
            }

            value = default;
            return false;
        }
        
        #endregion
        
        #region Set

        public void SetTag(int key) => _tags.Add(key);
        
        public void SetBool(int key, bool value) => _boolValues[key] = value;
        
        public void SetInt(int key, int value) => _intValues[key] = value;
        
        public void SetFloat(int key, float value) => _floatValues[key] = value;
        
        public void SetVector2(int key, Vector2 value) => _vector2Values[key] = value;
        
        public void SetVector3(int key, Vector3 value) => _vector3Values[key] = value;
        
        public void SetQuaternion(int key, Quaternion value) => _quaternionValues[key] = value;
        
        public void SetObject(int key, object value) => _objValues[key] = value;
        
        #endregion

        #region Delete

        public bool DeleteTag(int key) => _tags.Remove(key);
        
        public bool DeleteBool(int key) => _boolValues.Remove(key);
        
        public bool DeleteInt(int key) => _intValues.Remove(key);
        
        public bool DeleteFloat(int key) => _floatValues.Remove(key);
        
        public bool DeleteObject(int key) => _objValues.Remove(key);
        
        public bool DeleteVector2(int key) => _vector2Values.Remove(key);
        
        public bool DeleteVector3(int key) => _vector3Values.Remove(key);
        
        public bool DeleteQuaternion(int key) => _vector3Values.Remove(key);
        
        #endregion
    }
}