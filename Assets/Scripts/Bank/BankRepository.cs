using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class BankRepository : Repository
    {
        private const string KEY = "BANK_KEY";

        public int coins { get; set; }

        public override void Initialize()
        {
            this.coins = PlayerPrefs.GetInt(KEY, 0);
            Debug.Log($"Initialize {this.coins}");
        }

        public override void Save()
        {
            PlayerPrefs.SetInt(KEY, coins);
        }
    }
}

