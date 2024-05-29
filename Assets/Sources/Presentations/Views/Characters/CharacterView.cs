﻿using Sirenix.OdinInspector;
using Sources.Presentations.Views.Cameras.Types;
using Sources.Presentations.Views.Characters.EnemyIndicators;
using Sources.Presentations.Views.Weapons;
using Sources.PresentationsInterfaces.Views.Cameras.Points;
using UnityEngine;

namespace Sources.Presentations.Views.Characters
{
    public class CharacterView : View, ICameraFollowable
    {
        [SerializeField] private FollowableId _followableId = FollowableId.Character;
        [Required] [SerializeField] private CharacterMovementView _characterMovementView;
        [Required] [SerializeField] private CharacterAnimationView _characterAnimationView;
        [Required] [SerializeField] private MiniGunView _miniGunView;
        [Required] [SerializeField] private CharacterAttackerView _characterAttackerView;
        [Required] [SerializeField] private CharacterHealthView _characterHealthView;
        [Required] [SerializeField] private CharacterWalletView _characterWalletView;
        [Required] [SerializeField] private EnemyIndicatorView _enemyIndicatorView;

        public FollowableId Id => _followableId;

        public CharacterMovementView CharacterMovementView => _characterMovementView;

        public CharacterAnimationView CharacterAnimationView => _characterAnimationView;

        public MiniGunView MiniGunView => _miniGunView;

        public CharacterAttackerView CharacterAttackerView => _characterAttackerView;

        public CharacterHealthView CharacterHealthView => _characterHealthView;

        public CharacterWalletView CharacterWalletView => _characterWalletView;

        public EnemyIndicatorView EnemyIndicatorView => _enemyIndicatorView;

        public Transform Transform => transform;
    }
}