using System;
using System.Collections.Generic;
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Setting;
using Sources.Domain.Models.Upgrades;
using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.Models.Data;
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
            ILevelDtoMapper levelDtoMapper,
            IGameDataDtoMapper gameDataDtoMapper,
            ITutorialDtoMapper tutorialDtoMapper,
            IKillEnemyCounterDtoMapper killEnemyCounterDtoMapper,
            ISavedLevelDtoMapper savedLevelDtoMapper)
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
            _toDtoMappers[typeof(GameData)] =
                model => gameDataDtoMapper.MapModelToDto(model as GameData);
            _toDtoMappers[typeof(Tutorial)] =
                model => tutorialDtoMapper.MapModelToDto(model as Tutorial);
            _toDtoMappers[typeof(KillEnemyCounter)] =
                model => killEnemyCounterDtoMapper.MapModelToDto(model as KillEnemyCounter);
            _toDtoMappers[typeof(SavedLevel)] =
                model => savedLevelDtoMapper.MapModelToDto(model as SavedLevel);

            _toModelMappers = new Dictionary<Type, Func<IDto, IEntity>>();
            _toModelMappers[typeof(UpgradeDto)] =
                dto => upgradeDtoMapper.MapDtoToModel(dto as UpgradeDto);
            _toModelMappers[typeof(PlayerWalletDto)] =
                dto => playerWalletDtoMapper.MapDtoToModel(dto as PlayerWalletDto);
            _toModelMappers[typeof(VolumeDto)] =
                dto => volumeDtoMapper.MapDtoToModel(dto as VolumeDto);
            _toModelMappers[typeof(LevelDto)] =
                dto => levelDtoMapper.MapDtoToModel(dto as LevelDto);
            _toModelMappers[typeof(GameDataDto)] =
                dto => gameDataDtoMapper.MapDtoToModel(dto as GameDataDto);
            _toModelMappers[typeof(TutorialDto)] =
                dto => tutorialDtoMapper.MapDtoToModel(dto as TutorialDto);
            _toModelMappers[typeof(KillEnemyCounterDto)] =
                dto => killEnemyCounterDtoMapper.MapDtoToModel(dto as KillEnemyCounterDto);
            _toModelMappers[typeof(SavedLevelDto)] =
                dto => savedLevelDtoMapper.MapDtoToModel(dto as SavedLevelDto);
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
                Type modelType = ModelId.ModelTypes[id];
                object dto = _dataService.LoadData(id, modelType);
                Func<IDto, IEntity> mapper = _toModelMappers[modelType];
                IEntity model = mapper.Invoke((IDto)dto);
                _entityRepository.Add(model);
                Debug.Log($"Saved {model.Type}");
            }
        }

        public void SaveAll()
        {
            foreach (IEntity dataModel in _entityRepository.Entities.Values)
            {
                if (_toDtoMappers.ContainsKey(dataModel.Type) == false)
                    throw new NullReferenceException("DtaModel Id is not registered in LoadService");

                _dataService.SaveData(_toDtoMappers[dataModel.Type].Invoke(dataModel), dataModel.Id);
                
                //TOdo сделать валидацию на сохранение
                Debug.Log($"Saved {dataModel.GetType()}");
            }
        }

        public void ClearAll()
        {
            foreach (string id in ModelId.DeletedModelsIds)
                _dataService.Clear(id);
        }

        public bool HasKey(string id) =>
            _dataService.HasKey(id);
    }
}