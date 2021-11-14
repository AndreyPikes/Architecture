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
            //coinsDebug.text = this.bankInteractor.coins.ToString();
            //Debug.Log(this.bankInteractor.coins);

            StartCoroutine(StartGameRoutine());
        }


        IEnumerator StartGameRoutine()
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


        }

        private void Update()
        {
            if (!BankI)

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.bankInteractor.AddCoins(this, 5);
                coinsDebug.text = this.bankInteractor.coins.ToString();
                Debug.Log(this.bankInteractor.coins);
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.bankInteractor.SpendCoins(this, 10);
                coinsDebug.text = this.bankInteractor.coins.ToString();
                Debug.Log(this.bankInteractor.coins);

            } 
                
        }
    }
}

