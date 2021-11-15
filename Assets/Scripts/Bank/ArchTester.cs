using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture
{
    public class ArchTester : MonoBehaviour
    {
        public Text coinsDebug;
        private Player player;

        private void Start()
        {
            Game.Run();
            Game.OnGameInitializedEvent += OnGameInitialized;
        }

        private void OnGameInitialized()
        {
            Game.OnGameInitializedEvent -= OnGameInitialized;
            //как вытащить игрока? о котором мы ничего не знаем
            var playerInteractor = Game.GetInteractor<PlayerInteractor>();
            this.player = playerInteractor.player;
        }

        private void Update()
        {
            if (!Bank.isInitialized) return;

            if (player == null) return;

            Debug.Log($"Player position = {player.transform.position}");

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

