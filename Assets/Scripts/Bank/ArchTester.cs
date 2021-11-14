using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture
{
    public class ArchTester : MonoBehaviour
    {
        public Text coinsDebug;

        private BankRepository bankRepository;
        private BankInteractor bankInteractor;

        private void Start()
        {
            this.bankRepository = new BankRepository();
            this.bankRepository.Initialize();

            this.bankInteractor = new BankInteractor(bankRepository); //плохо
            this.bankRepository.Initialize();

            coinsDebug.text = this.bankInteractor.coins.ToString();
            Debug.Log(this.bankInteractor.coins);
        }

        private void Update()
        {
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

