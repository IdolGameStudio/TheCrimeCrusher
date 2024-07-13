using System;
using UnityEngine;

namespace _Project.Data
{
    [Serializable]
    public class PlayerProgress
    {
        [SerializeField] private int _currentHealth;
        [SerializeField] private int _coins;
        [SerializeField] private int _level;
        [SerializeField] private int _experience;
        [SerializeField] private int _laserPistolLevel;
        [SerializeField] private int _plasmaRifleLevel;
        [SerializeField] private int _electromagneticHammerLevel;
        [SerializeField] private int _fireDroneLevel;
        public PlayerProgress()
        {
            _currentHealth = 100;
            _coins = 0;
            _level = 0;
            _experience = 0;
            _laserPistolLevel = 1;
            _plasmaRifleLevel = 1;
            _electromagneticHammerLevel = 0;
            _fireDroneLevel = 1;
        }

        public int CurrentHealth => _currentHealth;
        public int Coins => _coins;
        public int Level => _level;
        public int Experience => _experience;
        public int LaserPistolLevel => _laserPistolLevel;
        public int PlasmaRifleLevel => _plasmaRifleLevel;
        public int ElectromagneticHammerLevel => _electromagneticHammerLevel;
        public int FireDroneLevel => _fireDroneLevel;
        
        
    }
}