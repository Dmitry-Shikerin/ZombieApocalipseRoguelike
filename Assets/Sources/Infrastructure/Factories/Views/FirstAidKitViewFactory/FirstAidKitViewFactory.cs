using System;
using Sources.Domain.Models.Constants;
using Sources.InfrastructureInterfaces.Factories.Views.FirstAidKits;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.Presentations.Views.FirstAidKits;
using Sources.PresentationsInterfaces.Views.FirstAidKits;
using Sources.PresentationsInterfaces.Views.ObjectPools;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.FirstAidKitViewFactory
{
    public class FirstAidKitViewFactory : IFirstAidKitViewFactory
    {
        private readonly IObjectPool<FirstAidKitView> _firstAidKitViewPool;

        public FirstAidKitViewFactory(IObjectPool<FirstAidKitView> firstAidKitViewPool)
        {
            _firstAidKitViewPool = firstAidKitViewPool ??
                                   throw new ArgumentNullException(nameof(firstAidKitViewPool));
        }

        public IFirstAidKitView Create(Vector3 position)
        {
            FirstAidKitView firstAidKitView = CreateView();
            firstAidKitView.SetPosition(position);

            return firstAidKitView;
        }

        private FirstAidKitView CreateView()
        {
            FirstAidKitView firstAidKitView =
                Object.Instantiate(Resources.Load<FirstAidKitView>(PrefabPath.FirstAidKit));

            firstAidKitView
                .AddComponent<PoolableObject>()
                .SetPool(_firstAidKitViewPool);

            return firstAidKitView;
        }
    }
}