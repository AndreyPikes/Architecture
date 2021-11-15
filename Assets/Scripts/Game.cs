using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public static class Game
    {
        public static event Action OnGameInitializedEvent;

        public static SceneManagerBase sceneManager { get; private set; }

        public static void Run()
        {
            sceneManager = new SceneManagerExample();
            Coroutines.StartRoutine(InitialiazeGameRoutine());
        }

        private static IEnumerator InitialiazeGameRoutine()
        {
            sceneManager.InitSceneMap();
            yield return sceneManager.LoadCurrentSceneAsync();
            OnGameInitializedEvent?.Invoke();
        }

        public static T GetInteractor<T>() where T: Interactor
        {
            return sceneManager.GetInteractor<T>();
        }

        public static T GetRepository<T>() where T : Repository
        {
            return sceneManager.GetRepository<T>();
        }
    }
}

