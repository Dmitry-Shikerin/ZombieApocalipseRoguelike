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

        public void SaveData<T>(T dataModel, string key)
            where T : IDto
        {
            string json = JsonConvert.SerializeObject(dataModel);
            
            PlayerPrefs.SetString(key, json);
        }
    }
}