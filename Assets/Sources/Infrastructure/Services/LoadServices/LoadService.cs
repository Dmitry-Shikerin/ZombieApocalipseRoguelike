using System;
using System.Collections.Generic;
using Sources.Domain.Data;
using Sources.Domain.Data.Common;
using Sources.Domain.Players;
using Sources.Domain.Upgrades;
using Sources.DomainInterfaces.Data;
using Sources.DomainInterfaces.Entities;
using Sources.Infrastructure.Services.Repositories;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.LoadServices.Data;
using UnityEngine;

namespace Sources.Infrastructure.Services.LoadServices
{
    public class LoadService : ILoadService
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IDataService _dataService;
        private readonly Dictionary<Type, Func<IEntity, IDto>> _mappers;

        public LoadService(
            IEntityRepository entityRepository,
            IDataService dataService,
            IDtoMapper<UpgradeDto, Upgrader> upgradeDtoMapper,
            IDtoMapper<PlayerWalletDto, PlayerWallet> playerWalletDtoMapper)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));

            _mappers = new Dictionary<Type, Func<IEntity, IDto>>();
            _mappers[typeof(Upgrader)] = 
                model => upgradeDtoMapper.MapTo(model as Upgrader);
            _mappers[typeof(PlayerWallet)] =
                model => playerWalletDtoMapper.MapTo(model as PlayerWallet);
        }

        public T Load<T>(IEntity entity)
            where T : IDto
        {
            return _dataService.LoadData<T>(entity.Id);
        }

        public void Save(IEntity entity)
        {
            if (_mappers.ContainsKey(entity.Type) == false)
                throw new NullReferenceException("DtaModel Id is not registered in LoadService");

            _dataService.SaveData(_mappers[entity.Type].Invoke(entity), entity.Id);
        }

        public void SaveAll()
        {
            foreach (IEntity dataModel in _entityRepository.Entities.Values)
            {
                Save(dataModel);
                Debug.Log($"Saved {dataModel.GetType()}");
            }
        }
    }
}