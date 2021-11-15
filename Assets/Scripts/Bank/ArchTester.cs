using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Lessons.Architecture
{
    public class ArchTester : MonoBehaviour
    {
        public Text coinsDebug;
        public static SceneManagerBase sceneManager;

        private void Start()
        {
            sceneManager = new SceneManagerExample();
            sceneManager.InitSceneMap();
            sceneManager.LoadCurrentSceneAsync();
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

