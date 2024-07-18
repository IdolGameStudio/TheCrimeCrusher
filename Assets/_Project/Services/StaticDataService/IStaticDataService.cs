using _Project.StaticData.Enemy;
using _Project.StaticData.Level;
using _Project.StaticData.Player;
using _Project.StaticData.Special;
using _Project.StaticData.Weapon;

namespace _Project.Services.StaticDataService
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