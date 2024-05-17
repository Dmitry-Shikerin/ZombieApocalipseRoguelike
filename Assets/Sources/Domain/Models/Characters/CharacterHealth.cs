using System;
using Sources.Domain.Models.Upgrades;
using Sources.DomainInterfaces.Models.Characters;
using Sources.DomainInterfaces.Models.Healths;
using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.Domain.Models.Characters
{
    public class CharacterHealth : IHealth, ICharacterHealth
    {
        private readonly Upgrader _healthUpgrader;
        private float _currentHealth;

        public CharacterHealth(Upgrader healthUpgrader)
        {
            _healthUpgrader = healthUpgrader;
            CurrentHealth = MaxHealth;
        }

        public event Action HealthChanged;
        public event Action<float> DamageReceived;
        public event Action CharacterDie;

        public float MaxHealth => _healthUpgrader.CurrentAmount;


        public float CurrentHealth
        {
            get => _currentHealth;
            private set
            {
                _currentHealth = value;
                _currentHealth = Mathf.Clamp(value, 0, MaxHealth);
                HealthChanged?.Invoke();
            }
        }

        public void TakeDamage(float damage)
        {
            if(CurrentHealth <= 0)
                return;
            
            CurrentHealth -= damage;
            DamageReceived?.Invoke(damage);

            if (CurrentHealth > 0)
                return;

            CharacterDie?.Invoke();
        }

        public void TakeHeal(int heal) =>
            CurrentHealth += heal;
    }
}