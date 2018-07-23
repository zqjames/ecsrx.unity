﻿using EcsRx.Examples.GameObjectBinding.Components;
using EcsRx.Unity;
using EcsRx.Views.Components;

namespace EcsRx.Examples.GameObjectBinding
{
    public class UnityApplication : EcsRxApplicationBehaviour
    {
        protected override void ApplicationStarting()
        {
            RegisterAllBoundSystems();
        }

        protected override void ApplicationStarted()
        {
            var defaultPool = CollectionManager.GetCollection();

            var cubeEntity = defaultPool.CreateEntity();
            cubeEntity.AddComponent<ViewComponent>();
            cubeEntity.AddComponent<CubeComponent>();

            var sphereEntity = defaultPool.CreateEntity();
            sphereEntity.AddComponent<ViewComponent>();
            sphereEntity.AddComponent<SphereComponent>();
        }
    }
}