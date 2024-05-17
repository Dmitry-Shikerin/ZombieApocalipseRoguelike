using System;
using Sources.DomainInterfaces.Models.Healths;
using UnityEngine;

namespace Sources.Domain.Models.Enemies
{
    public class EnemyHealth : IHealth
    {
        private float _currentHealth;

        public EnemyHealth(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
        }

        public event Action HealthChanged;
        public event Action<float> DamageReceived;

        public float MaxHealth { get; }
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
    }
}