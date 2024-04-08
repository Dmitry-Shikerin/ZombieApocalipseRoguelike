using System;
using System.Collections.Generic;
using Sources.Domain.Data;
using Sources.Domain.Data.Ids;
using Sources.DomainInterfaces.Data;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.LoadServices.Data;
using UnityEngine;

namespace Sources.Infrastructure.Services.LoadServices
{
    public class LoadService : ILoadService
    {
        private readonly IDataService _dataService;
        private readonly List<IDataModel> _dataModels;
        private readonly Dictionary<string, Func<IDataModel, IDto>> _factories;

        public LoadService(
            IDataService dataService,
            IDtoFactory<SawLauncherAbilityUpgradeDto> sawLauncherAbilityUpgradeDtoFactory,
            IDtoFactory<SawLauncherUpgradeDto> sawLauncherUpgradeDtoFactory,
            IDtoFactory<PlayerWalletDto> playerWalletDtoFactory)
        {
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _dataModels = new List<IDataModel>();
            _factories = new Dictionary<string, Func<IDataModel, IDto>>();

            _factories[DataModelId.SawLauncherAbilityUpgrader] = sawLauncherAbilityUpgradeDtoFactory.Create;
            _factories[DataModelId.SawLauncherUpgrader] = sawLauncherUpgradeDtoFactory.Create;
            _factories[DataModelId.PlayerWallet] = playerWalletDtoFactory.Create;
        }

        public T Load<T>(IDataModel dataModel)
            where T : IDto
        {
            return _dataService.LoadData<T>(dataModel.Id);
        }

        public void Save<T>(T dataModel)
            where T : IDataModel
        {
            if (_factories.ContainsKey(dataModel.Id) == false)
                throw new NullReferenceException("DtaModel Id is not registered in LoadService");

            _dataService.SaveData(_factories[dataModel.Id].Invoke(dataModel), dataModel.Id);
        }

        public void Register(IDataModel dataModel)
        {
            _dataModels.Add(dataModel);
        }

        public void SaveAll()
        {
            foreach (IDataModel dataModel in _dataModels)
            {
                Save(dataModel);
                Debug.Log($"Saved {dataModel.Id}");
            }
        }
    }
}