﻿using System;
using Newtonsoft.Json;
using Sources.DomainInterfaces.Data;
using Sources.InfrastructureInterfaces.Services.LoadServices.Data;
using UnityEngine;

namespace Sources.Infrastructure.Services.LoadServices.Data
{
    public class PlayerPrefsDataService : IDataService
    {
        public T LoadData<T>(string key)
            where T : IDto
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

            return JsonConvert.DeserializeObject<T>(json);
        }
        
        public object LoadData(string key, Type type)
        {
            string json = PlayerPrefs.GetString(key, string.Empty);

            return JsonConvert.DeserializeObject(json, type);
        }

        public void SaveData<T>(T dataModel, string key)
            where T : IDto
        {
            string json = JsonConvert.SerializeObject(dataModel);
            
            PlayerPrefs.SetString(key, json);
        }

        public bool HasKey(string key) =>
            PlayerPrefs.HasKey(key);

        public void Clear(string key) =>
            PlayerPrefs.DeleteKey(key);
    }
}