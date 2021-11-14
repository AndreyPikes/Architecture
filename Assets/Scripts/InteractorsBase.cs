using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture 
{
    public class InteractorsBase
    {
        private Dictionary<Type, Interactor> interactorsMap;

        public InteractorsBase()
        {
            this.interactorsMap = new Dictionary<Type, Interactor>();
        }

        public void CreateAllInteractors()
        {
            CreateInteractor<BankInteractor>();
        }

        private void CreateInteractor<T>() where T : Interactor, new()
        {
            var interactor = new T();
            var type = typeof(T);
            //this.interactorsMap.Add(type, interactor); а так можно?
            this.interactorsMap[type] = interactor;
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


