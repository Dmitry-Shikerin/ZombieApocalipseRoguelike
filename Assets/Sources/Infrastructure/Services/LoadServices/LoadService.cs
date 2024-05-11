﻿using System;
using Sirenix.OdinInspector;
using Sirenix.OdinValidator.Editor;
using Sources.Domain.Models.Data.Ids;
using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.Models.Data;
using Sources.Infrastructure.Services.Repositories;
using Sources.Infrastructure.Services.Volumes;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.LoadServices.Collectors;
using Sources.InfrastructureInterfaces.Services.LoadServices.Data;

namespace Sources.Infrastructure.Services.LoadServices
{
    public class LoadService : ILoadService
    {
        private readonly IEntityRepository _entityRepository;
        private readonly IDataService _dataService;
        private readonly IMapperCollector _mapperCollector;
        private readonly CustomValidator _customValidator;

        public LoadService(
            IEntityRepository entityRepository,
            IDataService dataService,
            IMapperCollector mapperCollector,
            CustomValidator customValidator)
        {
            _entityRepository = entityRepository ?? throw new ArgumentNullException(nameof(entityRepository));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
            _mapperCollector = mapperCollector ?? throw new ArgumentNullException(nameof(mapperCollector));
            _customValidator = customValidator ?? throw new ArgumentNullException(nameof(customValidator));
        }

        //TODO загружать все дто и сразу конвертить их в модели и складировать в инстансе контейнер

        //todo лучше не придумал
        public T Load<T>(string id) 
            where T : class, IEntity
        {
            object dto = _dataService.LoadData(id, ModelId.DtoTypes[id]);
            Func<IDto, IEntity> modelMapper = _mapperCollector.GetToModelMapper(ModelId.DtoTypes[id]);
            IEntity model = modelMapper.Invoke((IDto)dto);

            if (model is not T concrete)
                throw new InvalidCastException(nameof(T));
            
            _entityRepository.Add(model);

            return concrete;
        }

        public void Save(IEntity entity)
        {
            Func<IEntity, IDto> dtoMapper = _mapperCollector.GetToDtoMapper(entity.Type);
            IDto dto = dtoMapper.Invoke(entity);
            _dataService.SaveData(dto, entity.Id);
        }

        public void Save(string id)
        {
            IEntity entity = _entityRepository.Get(id);
            Func<IEntity, IDto> dtoMapper = _mapperCollector.GetToDtoMapper(entity.Type);
            IDto dto = dtoMapper.Invoke(entity);
            _dataService.SaveData(dto, entity.Id);
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
            }
        }

        public void SaveAll()
        {
            foreach (IEntity dataModel in _entityRepository.Entities.Values)
            {
                Func<IEntity, IDto> dtoMapper = _mapperCollector.GetToDtoMapper(dataModel.Type);
                IDto dto = dtoMapper.Invoke(dataModel);
                _dataService.SaveData(dto, dataModel.Id);
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