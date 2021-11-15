using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class SceneConfigExample : SceneConfig
    {
        public const string SCENE_NAME = "ArchitectureTest";
        public override string sceneName => SCENE_NAME;

        public override Dictionary<Type, Repository> CreateAllRepositories()
        {
            var repositiriesMap = new Dictionary<Type, Repository>();

            this.CreateRepository<BankRepository>(repositiriesMap);

            return repositiriesMap;
        }

        public override Dictionary<Type, Interactor> CreateAllInteractors()
        {
            var interactorsMap = new Dictionary<Type, Interactor>();

            this.CreateInteractor<BankInteractor>(interactorsMap);
            this.CreateInteractor<PlayerInteractor>(interactorsMap);

            return interactorsMap;
        }
    }
}

