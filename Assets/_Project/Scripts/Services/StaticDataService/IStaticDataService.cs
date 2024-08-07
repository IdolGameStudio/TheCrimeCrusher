using _Project.Scripts.StaticData.Enemy;
using _Project.Scripts.StaticData.Level;
using _Project.Scripts.StaticData.Player;
using _Project.Scripts.StaticData.Special;
using _Project.Scripts.StaticData.Weapon;

namespace _Project.Scripts.Services.StaticDataService
{
    public interface IStaticDataService
    {
        void Initialize();
        PlayerStaticData PlayerData { get; }
        LevelStaticData GetLevelStaticData(string levelName);
        EnemyData GetEnemyData(EnemyType enemyType);
        WeaponStaticData GetWeaponData(WeaponID weaponID);
        SpecialStaticData GetSpecialData(SpecialID specialID);
    }
}