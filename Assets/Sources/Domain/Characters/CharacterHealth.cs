using System;
using Sources.DomainInterfaces.Healths;
using UnityEngine;

namespace Sources.Domain.Characters
{
    public class CharacterHealth : IHealth
    {
        private float _currentHealth;

        public CharacterHealth(float maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
        }

        public event Action HealthChanged;
        
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
        }
    }
}