using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class BankInteractor : Interactor
    {
        private BankRepository bankRepository;

        //public int coins { get { return bankRepository.coins; } set { value = bankRepository.coins; } }
        public int coins => bankRepository.coins; // можем только возвращать, не класть

        public BankInteractor(BankRepository bankRepository) //временно
        {
            this.bankRepository = bankRepository;
        }

        public bool isEnoughCoins(int value)
        {
            return value <= coins;
        }

        public void AddCoins (object sender, int value)
        {
            this.bankRepository.coins += value;
            this.bankRepository.Save();
        }

        public void SpendCoins(object sender, int value)
        {
            this.bankRepository.coins -= value;
            this.bankRepository.Save();
        }
    }
    
}

