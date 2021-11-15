using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture 
{
    public class InteractorsBase
    {
        private Dictionary<Type, Interactor> interactorsMap;
        private SceneConfig sceneConfig;

        public InteractorsBase(SceneConfig sceneConfig)
        {
            this.sceneConfig = sceneConfig;
        }

        public void CreateAllInteractors()
        {
            this.interactorsMap = this.sceneConfig.CreateAllInteractors();
        }

        
        public void SendOnCreateToAllInteractors()
        {
            var allInteractors = this.interactorsMap.Values;
            foreach (var interactor in allInteractors)
            {
                interactor.OnCreate();
            }
        }

        public void SendInitializeToAllInteractors()
        {
            var allInteractors = this.interactorsMap.Values;
            foreach (var interactor in allInteractors)
            {
                interactor.Initialize();
            }
        }

        public void SendOnStartToAllInteractors()
        {
            var allInteractors = this.interactorsMap.Values;
            foreach (var interactor in allInteractors)
            {
                interactor.OnStart();
            }
        }

        //самый важный метод
        public T GetInteractor<T>() where T : Interactor
        {
            var type = typeof(T);
            return (T)interactorsMap[type];
        }
    }
}


