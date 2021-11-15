using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture
{
    public class ArchTester : MonoBehaviour
    {
        public Text coinsDebug;


        //не хорошо:
        public static InteractorsBase interactorsBase;
        public static RepositoriesBase repositoriesBase;

        private void Start()
        {

            this.StartCoroutine(this.StartGameRoutine());
        }


        private IEnumerator StartGameRoutine()
        {
            interactorsBase = new InteractorsBase();
            repositoriesBase = new RepositoriesBase();

            interactorsBase.CreateAllInteractors();
            repositoriesBase.CreateAllRepositories();
            yield return null;//пропуск кадра

            interactorsBase.SendOnCreateToAllInteractors();
            repositoriesBase.SendOnCreateToAllRepositories();
            yield return null;

            interactorsBase.SendInitializeToAllInteractors();
            repositoriesBase.SendInitializeToAllRepositories();
            yield return null;

            interactorsBase.SendOnStartToAllInteractors();
            repositoriesBase.SendOnStartToAllRepositories();
            yield return null;

            coinsDebug.text = Bank.coins.ToString();
            
        }

        private void Update()
        {
            if (!Bank.isInitialized) return;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
               Debug.Log("Up");
               Bank.AddCoins(this, 5);
               coinsDebug.text = Bank.coins.ToString();
                
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Debug.Log("Down");
                Bank.SpendCoins(this, 10);
                coinsDebug.text = Bank.coins.ToString();
                

            } 
                
        }
    }
}

