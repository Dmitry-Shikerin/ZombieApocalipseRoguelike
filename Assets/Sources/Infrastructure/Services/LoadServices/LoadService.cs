using System;
using System.Collections.Generic;
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Setting;
using Sources.Domain.Models.Spawners;
using Sources.Domain.Models.Upgrades;
using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.Models.Data;
using Sources.Infrastructure.Services.Repositories;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.LoadServices.Collectors;
using Sources.InfrastructureInterfaces.Services.LoadServices.Data;
using UnityEngine;

namespace Sources.Infrastructure.Services.LoadServices
{
    public class LoadService : ILoadService
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IDataService _dataService;
        private readonly IMapperCollector _mapperCollector;

        public LoadService(
            IEntityRepository entityRepository,
            IDataService dataService,
            IMapperCollector mapperCollector)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _mapperCollector = mapperCollector ?? throw new ArgumentNullException(nameof(mapperCollector));
        }

        //TODO загружать все дто и сразу конвертить их в модели и складировать в инстансе контейнер

        //todo лучше не придумал
        public T Load<T>(string id) 
            where T : class, IEntity
        {
            object dto = _dataService.LoadData(id, ModelId.DtoTypes[id]);
            IEntity model = _mapperCollector.GetToModelMapper(ModelId.DtoTypes[id]).Invoke((IDto)dto);

            if (model is not T concrete)
                throw new InvalidCastException(nameof(T));
            
            _entityRepository.Add(model);

            return concrete;
        }

        public void Save(IEntity entity)
        {
            _dataService.SaveData(_mapperCollector.GetToDtoMapper(entity.Type).Invoke(entity), entity.Id);
        }

        public void Save(string id)
        {
            if (_entityRepository.Get(id) == null)
                throw new NullReferenceException(nameof(id));
            
            IEntity entity = _entityRepository.Get(id);
            
            // Debug.Log($"Model saved {entity.Id}");
            
            _dataService.SaveData(_mapperCollector.GetToDtoMapper(entity.Type).Invoke(entity), entity.Id);
        }

        public void LoadAll()
        {
            foreach (string id in ModelId.ModelsIds)
            {
                Type dtoType = ModelId.DtoTypes[id];
                object dto = _dataService.LoadData(id, dtoType);
                Func<IDto, IEntity> mapper = _mapperCollector.GetToModelMapper(dtoType);
                IEntity model = mapper.Invoke((IDto)dto);
                _entityRepository.Add(model);
                // Debug.Log($"Saved {model.Type}");
            }
        }

        public void SaveAll()
        {
            foreach (IEntity dataModel in _entityRepository.Entities.Values)
            {
                _dataService.SaveData(_mapperCollector.GetToDtoMapper(dataModel.Type).Invoke(dataModel), dataModel.Id);
                
                //TOdo сделать валидацию на сохранение
                // Debug.Log($"Saved {dataModel.GetType()}");
            }
        }

        public void Clear(IEntity entity) =>
            _dataService.Clear(entity.Id);

        public void Clear(string id) =>
            _dataService.Clear(id);

        public void ClearAll()
        {
            foreach (string id in ModelId.DeletedModelsIds)
                _dataService.Clear(id);
        }

        public bool HasKey(string id) =>
            _dataService.HasKey(id);
    }
}