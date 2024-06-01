using System.Collections.Generic;
using UnityEngine;


namespace HackedDesign
{
    [System.Serializable]
    public class GameData
    {
        public string version = "0.1";

        public static GameData Instance { get; private set; }

        public GameData()
        {
            Instance = this;
        }

        public void Reset(Settings settings)
        {
        }
    }
}