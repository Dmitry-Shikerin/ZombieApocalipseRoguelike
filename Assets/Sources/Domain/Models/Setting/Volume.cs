using System;
using Sources.Domain.Constants;
using Sources.Domain.Data;
using Sources.Domain.Data.Ids;
using Sources.Domain.Models.Constants;
using Sources.DomainInterfaces.Entities;
using UnityEngine;

namespace Sources.Domain.Setting
{
    public class Volume : IEntity
    {
        private float _volumeValue;

        public Volume(VolumeDto volumeDto)
            : this(volumeDto.VolumeValue, volumeDto.Id)
        {
        }

        public Volume()
            : this(VolumeConstant.BaseValue, ModelId.Volume)
        {
        }

        private Volume(float value, string id)
        {
            VolumeValue = value;
            Id = id;
        }

        public event Action VolumeChanged;

        public float VolumeValue
        {
            get => _volumeValue;

            private set
            {
                _volumeValue = Mathf.Clamp(value, 0, 1);
                VolumeChanged?.Invoke();
            }
        }

        public string Id { get; }
        public Type Type => GetType();

        public void SetVolume(float value) =>
            VolumeValue = value;
    }
}