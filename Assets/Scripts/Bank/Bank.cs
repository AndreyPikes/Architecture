using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public static class Bank //бан по сути тот же интерактор и может то же самое
    {
        public static event Action OnBankInitializedEvent;
        public static int coins
        {
            get
            {
                CheckClass();
                return bankInteractor.coins;
            }
        }
        public static bool isInitialized { get; private set; }

        public static BankInteractor bankInteractor;
        public static void Initialize(BankInteractor interactor)
        {
            bankInteractor = interactor;
            isInitialized = true;
            OnBankInitializedEvent?.Invoke();
        }

        public static bool isEnoughCoins(int value)
        {
            CheckClass();
            return bankInteractor.isEnoughCoins(value);
        }

        public static void AddCoins(object sender, int value)
        {
            CheckClass();
            bankInteractor.AddCoins(sender, value);
            Debug.Log("Add");
        }

        public static void SpendCoins(object sender, int value)
        {
            CheckClass();
            bankInteractor.SpendCoins(sender, value);
            Debug.Log("Spend");
        }

        private static void CheckClass()
        {
            if (!isInitialized) throw new Exception("Bank not initialized yet");
        }
    }
}

