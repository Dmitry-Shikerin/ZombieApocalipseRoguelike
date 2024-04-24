using System;
using Sources.Domain.Models.Upgrades;
using Sources.DomainInterfaces.Healths;
using UnityEngine;

namespace Sources.Domain.Models.Characters
{
    public class CharacterHealth : IHealth
    {
        public Upgrader HealthUpgrader { get; }
        private float _currentHealth;

        public CharacterHealth(Upgrader healthUpgrader)
        {
            HealthUpgrader = healthUpgrader;
            CurrentHealth = MaxHealth;
        }

        public event Action HealthChanged;
        public event Action<float> DamageReceived;

        public float MaxHealth => HealthUpgrader.CurrentAmount;
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
            CurrentHealth -= damage;
            DamageReceived?.Invoke(damage);
        }

        public void TakeHeal(int heal)
        {
            CurrentHealth += heal;
        }
    }
}