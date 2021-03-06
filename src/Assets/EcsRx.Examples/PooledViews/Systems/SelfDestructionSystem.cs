﻿using System;
using EcsRx.Collections;
using EcsRx.Entities;
using EcsRx.Examples.PooledViews.Components;
using EcsRx.Extensions;
using EcsRx.Groups;
using EcsRx.Systems;
using EcsRx.Views.Components;
using UniRx;

namespace EcsRx.Examples.PooledViews.Systems
{
    public class SelfDestructionSystem : IReactToEntitySystem
    {
        public IGroup Group => new Group(typeof(SelfDestructComponent), typeof(ViewComponent));
        private readonly IEntityCollection _defaultCollection;

        public SelfDestructionSystem(IEntityCollectionManager collectionManager)
        { _defaultCollection = collectionManager.GetCollection(); }

        public IObservable<IEntity> ReactToEntity(IEntity entity)
        {
            var selfDestructComponent = entity.GetComponent<SelfDestructComponent>();
            return Observable.Interval(TimeSpan.FromSeconds(selfDestructComponent.Lifetime)).First().Select(x => entity);
        }

        public void Process(IEntity entity)
        { _defaultCollection.RemoveEntity(entity.Id); }
    }
}