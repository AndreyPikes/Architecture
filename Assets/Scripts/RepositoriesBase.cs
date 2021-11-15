using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class RepositoriesBase
    {
        private Dictionary<Type, Repository> repositoriesMap;
        private SceneConfig sceneConfig;

        public RepositoriesBase(SceneConfig sceneConfig)
        {
            this.sceneConfig = sceneConfig;
        }

        public void CreateAllRepositories()
        {
            this.repositoriesMap = this.sceneConfig.CreateAllRepositories();
        }

        

        public void SendOnCreateToAllRepositories()
        {
            var allRepositories = this.repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnCreate();
            }
        }

        public void SendInitializeToAllRepositories()
        {
            var allRepositories = this.repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.Initialize();
            }
        }

        public void SendOnStartToAllRepositories()
        {
            var allRepositories = this.repositoriesMap.Values;
            foreach (var repository in allRepositories)
            {
                repository.OnStart();
            }
        }

        //самый важный метод
        public T GetRepository<T>() where T : Repository
        {
            var type = typeof(T);
            return (T)repositoriesMap[type];
        }
    }
}

