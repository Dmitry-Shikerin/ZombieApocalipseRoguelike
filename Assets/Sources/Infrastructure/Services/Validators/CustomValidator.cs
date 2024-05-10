using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Infrastructure.Services.Volumes
{
    public class CustomValidator
    {
        private Dictionary<Type, List<string>> _errors = new Dictionary<Type, List<string>>();

        public CustomValidator()
        {
            Validate();
        }

        public void ShowMassage(string message)
        {
            Debug.Log(message);
        }
        
        public void AddError(Type type, string message)
        {
            if (_errors.ContainsKey(type) == false)
            {
                _errors[type] = new List<string>();
                _errors[type].Add(message);
            }
            
            _errors[type].Add(message);
        }

        private void Validate()
        {
            foreach (var error in _errors)
            {
                Debug.Log($"{error.Key}, {error.Value}");
                
                foreach (var massage in error.Value)
                {
                    Debug.Log(massage);
                }
            }
        }
    }
}