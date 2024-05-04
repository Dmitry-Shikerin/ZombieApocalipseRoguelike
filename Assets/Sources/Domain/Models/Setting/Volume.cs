using System;
using Sources.Domain.Data;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Data.Ids;
using Sources.DomainInterfaces.Entities;
using UnityEngine;

namespace Sources.Domain.Models.Setting
{
    public class Volume : IEntity
    {
        private float _musicMusicValue;
        private float _miniGunVolumeValue;

        public Volume(VolumeDto volumeDto)
            : this(volumeDto.MusicValue, volumeDto.MiniGunVolumeValue, volumeDto.Id)
        {
        }

        public Volume()
            : this(VolumeConstant.BaseMusciValue, VolumeConstant.BaseMusciValue, ModelId.Volume)
        {
        }

        private Volume(float musicValue, float miniGunVolume, string id)
        {
            MusicMusicValue = musicValue;
            MiniGunVolumeValue = miniGunVolume;
            Id = id;
        }

        public event Action MusicVolumeChanged;
        public event Action MiniGunVolumeChanged;

        public float MusicMusicValue
        {
            get => _musicMusicValue;
            set
            {
                _musicMusicValue = Mathf.Clamp(value, 0, 1);
                MusicVolumeChanged?.Invoke();
            }
        }
        
        public float MiniGunVolumeValue
        {
            get => _miniGunVolumeValue;
            set
            {
                _miniGunVolumeValue = Mathf.Clamp(value, 0, 1);
                MiniGunVolumeChanged?.Invoke();
            }
        }

        public string Id { get; }
        public Type Type => GetType();
    }
}