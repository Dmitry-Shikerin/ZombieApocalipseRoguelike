using System;
using System.Collections.Generic;
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Setting;
using Sources.Domain.Models.Spawners;
using Sources.Domain.Models.Upgrades;
using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.Models.Data;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Services.LoadServices.Collectors;

namespace Sources.Infrastructure.Services.LoadServices.Collectors
{
    public class MapperCollector : IMapperCollector
    {
        private readonly Dictionary<Type, Func<IEntity, IDto>> _toDtoMappers;
        private readonly Dictionary<Type, Func<IDto, IEntity>> _toModelMappers;

        public MapperCollector(
            IUpgradeDtoMapper upgradeDtoMapper,
            IPlayerWalletDtoMapper playerWalletDtoMapper,
            IVolumeDtoMapper volumeDtoMapper,
            ILevelDtoMapper levelDtoMapper,
            IGameDataDtoMapper gameDataDtoMapper,
            ITutorialDtoMapper tutorialDtoMapper,
            IKillEnemyCounterDtoMapper killEnemyCounterDtoMapper,
            ISavedLevelDtoMapper savedLevelDtoMapper,
            IEnemySpawnerDtoMapper enemySpawnerDtoMapper,
            IScoreCounterDtoMapper scoreCounterDtoMapper)
        {
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
            _toDtoMappers[typeof(EnemySpawner)] =
                model => enemySpawnerDtoMapper.MapModelToDto(model as EnemySpawner);
            _toDtoMappers[typeof(ScoreCounter)] =
                model => scoreCounterDtoMapper.MapModelToDto(model as ScoreCounter);

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
            _toModelMappers[typeof(EnemySpawnerDto)] =
                dto => enemySpawnerDtoMapper.MapDtoToModel(dto as EnemySpawnerDto);
            _toModelMappers[typeof(ScoreCounterDto)] =
                dto => scoreCounterDtoMapper.MapDtoToModel(dto as ScoreCounterDto);
        }

        public Func<IEntity, IDto> GetToDtoMapper(Type type)
        {
            if(_toDtoMappers.ContainsKey(type) == false)
                throw new NullReferenceException($"DtaModel Id {type} not registered in MapperCollector.");
            
            return _toDtoMappers[type];
        }

        public Func<IDto, IEntity> GetToModelMapper(Type type)
        {
            if(_toModelMappers.ContainsKey(type) == false)
                throw new NullReferenceException($"DtaModel Id {type} not registered in MapperCollector.");
            
            return _toModelMappers[type];
        }
    }
}