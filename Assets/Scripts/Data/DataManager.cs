using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelManagement.Data
{
    public class DataManager : MonoBehaviour
    {
        private SaveData _saveData;
        private JsonSaver _jsonSaver;

        public float SfxVolume
        {
            get { return _saveData.sfxVolume; }
            set { _saveData.sfxVolume = value; }
        }

        public float MusicVolume
        {
            get { return _saveData.musicVolume; }
            set { _saveData.musicVolume = value; }
        }


        // initialize SaveData and JsonSaver objects
        private void Awake()
        {
            _saveData = new SaveData();
            _jsonSaver = new JsonSaver();
        }

        // save the data using the JsonSaver
        public void Save()
        {
            _jsonSaver.Save(_saveData);
        }

        // load the data using the JsonSaver
        public void Load()
        {
            _jsonSaver.Load(_saveData);
        }

    }
}
