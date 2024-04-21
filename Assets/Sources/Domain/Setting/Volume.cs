using System;
using Sources.Domain.Constants;
using Sources.Domain.Data;
using Sources.Domain.Data.Ids;
using Sources.DomainInterfaces.Entities;
using UnityEngine;

namespace Sources.Domain.Setting
{
    public class Volume : IEntity
    {
        private int _step;

        public Volume(VolumeDto volumeDto)
            : this(volumeDto.Step, volumeDto.Id)
        {
        }

        public Volume()
            : this(VolumeConstant.BaseStep, ModelId.Volume)
        {
        }

        private Volume(int step, string id)
        {
            Step = step;
            Id = id;
        }

        public event Action VolumeChanged;

        public float VolumeValue => Step * VolumeConstant.VolumeValuePerStep;
        public string Id { get; }
        public Type Type => GetType();

        public int Step
        {
            get => _step;
            set
            {
                _step = Mathf.Clamp(value, 0, VolumeConstant.MaxStep);
                VolumeChanged?.Invoke();
            }
        }

        public void Increase() =>
            Step++;

        public void TurnDown() =>
            Step--;
    }
}