using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class RepositoriesBase
    {
        private Dictionary<Type, Repository> repositoriesMap;

        public RepositoriesBase()
        {
            this.repositoriesMap = new Dictionary<Type, Repository>();
        }

        public void CreateAllRepositories()
        {
            CreateRepository<BankRepository>();
        }

        private void CreateRepository<T>() where T : Repository, new()
        {
            var repository = new T();
            var type = typeof(T);
            //this.interactorsMap.Add(type, interactor); а так можно?
            this.repositoriesMap[type] = repository;
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

