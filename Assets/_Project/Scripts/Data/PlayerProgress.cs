using System;
using UnityEngine;

namespace _Project.Scripts.Data
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
        [SerializeField] private int _energyShieldLevel;
        [SerializeField] private int _fieryExplosionLevel;
        [SerializeField] private int _healingLevel;
        
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
            _energyShieldLevel = 1;
            _fieryExplosionLevel = 1;
            _healingLevel = 1;
        }

        public int CurrentHealth => _currentHealth;
        public int Coins => _coins;
        public int Level => _level;
        public int Experience => _experience;
        public int LaserPistolLevel => _laserPistolLevel;
        public int PlasmaRifleLevel => _plasmaRifleLevel;
        public int ElectromagneticHammerLevel => _electromagneticHammerLevel;
        public int FireDroneLevel => _fireDroneLevel;

        public int EnergyShieldLevel => _energyShieldLevel;

        public int FieryExplosionLevel => _fieryExplosionLevel;

        public int HealingLevel => _healingLevel;
    }
}