using System;
using System.Collections.Generic;
using Sources.Domain.Data;
using Sources.Domain.Data.Common;
using Sources.Domain.Data.Ids;
using Sources.Domain.Gameplay;
using Sources.Domain.Players;
using Sources.Domain.Setting;
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
        private readonly Dictionary<Type, Func<IEntity, IDto>> _toDtoMappers;
        private readonly Dictionary<Type, Func<IDto, IEntity>> _toModelMappers;

        public LoadService(
            IEntityRepository entityRepository,
            IDataService dataService,
            IUpgradeDtoMapper upgradeDtoMapper,
            IPlayerWalletDtoMapper playerWalletDtoMapper,
            IVolumeDtoMapper volumeDtoMapper,
            ILevelDtoMapper levelDtoMapper)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));

            _toDtoMappers = new Dictionary<Type, Func<IEntity, IDto>>();
            _toDtoMappers[typeof(Upgrader)] =
                model => upgradeDtoMapper.MapModelToDto(model as Upgrader);
            _toDtoMappers[typeof(PlayerWallet)] =
                model => playerWalletDtoMapper.MapModelToDto(model as PlayerWallet);
            _toDtoMappers[typeof(Volume)] =
                model => volumeDtoMapper.MapModelToDto(model as Volume);
            _toDtoMappers[typeof(Level)] =
                model => levelDtoMapper.MapModelToDto(model as Level);

            _toModelMappers = new Dictionary<Type, Func<IDto, IEntity>>();
            _toModelMappers[typeof(Upgrader)] =
                dto => upgradeDtoMapper.MapDtoToModel(dto as UpgradeDto);
            _toModelMappers[typeof(PlayerWallet)] =
                dto => playerWalletDtoMapper.MapDtoToModel(dto as PlayerWalletDto);
            _toModelMappers[typeof(Volume)] =
                dto => volumeDtoMapper.MapDtoToModel(dto as VolumeDto);
            _toModelMappers[typeof(Level)] =
                dto => levelDtoMapper.MapDtoToModel(dto as LevelDto);
        }

        //TODO загружать все дто и сразу конвертить их в модели и складировать в инстансе контейнер

        //todo лучше не придумал
        public T Load<T>(string id) where T : class, IEntity
        {
            object dto = _dataService.LoadData(id, ModelId.ModelTypes[id]);
            IEntity model = _toModelMappers[ModelId.ModelTypes[id]].Invoke((IDto)dto);

            if (model is not T concrete)
                throw new InvalidCastException(nameof(T));

            return concrete;
        }

        public void Save(IEntity entity)
        {
            _dataService.SaveData(_toDtoMappers[entity.Type].Invoke(entity), entity.Id);
        }

        public void LoadAll()
        {
            foreach (string id in ModelId.ModelsIds)
            {
                object dto = _dataService.LoadData(id, ModelId.ModelTypes[id]);
                IEntity model = _toModelMappers[ModelId.ModelTypes[id]].Invoke((IDto)dto);
                _entityRepository.Add(model);
                Debug.Log($"Saved {model.GetType()}");
            }
        }

        public void SaveAll()
        {
            foreach (IEntity dataModel in _entityRepository.Entities.Values)
            {
                if (_toDtoMappers.ContainsKey(dataModel.Type) == false)
                    throw new NullReferenceException("DtaModel Id is not registered in LoadService");

                _dataService.SaveData(_toDtoMappers[dataModel.Type].Invoke(dataModel), dataModel.Id);
                Debug.Log($"Saved {dataModel.GetType()}");
            }
        }

        public void ClearAll()
        {
            foreach (string id in ModelId.ModelsIds)
                _dataService.Clear(id);
        }

        public bool HasKey(string id) =>
            _dataService.HasKey(id);
    }
}