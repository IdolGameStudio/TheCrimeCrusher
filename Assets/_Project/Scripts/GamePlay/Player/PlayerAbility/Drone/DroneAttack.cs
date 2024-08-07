using _Project.Scripts.Infrastructure.Factories;
using UnityEngine;
using Zenject;

namespace _Project.Scripts.GamePlay.Player.PlayerAbility.Drone
{
    public class DroneAttack : Ability
    {
        [SerializeField] private DroneAttackData _data;
        private GameObject _droneInstance;
        private float _remainingDuration;
        private EnemyGroupFinder _enemyGroupFinder;
        private AreaDamage _areaDamage;
        private bool _isReady;
        private IGameFactory _gameFactory;

        [Inject]
        private void Construct(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        private void Start() =>
            Initialize();

        public void Initialize()
        {
            _enemyGroupFinder = new EnemyGroupFinder(_gameFactory.Enemies);
            _areaDamage = new AreaDamage();
            _areaDamage.Initialize(_gameFactory.Enemies);
        }
        public override void Activate()
        {
            if (_isReady)
            {
                Vector3? targetPosition = _enemyGroupFinder.FindBestTargetPosition(_data.Range);

                if (targetPosition == null)
                {
                    Debug.Log("No enemies found.");
                    return;
                }

                _droneInstance = Instantiate(_data.DronePrefab, transform.position, Quaternion.identity);
                _droneInstance.GetComponent<Drone>().Initialize(targetPosition.Value, _data, _areaDamage);
                _remainingDuration = _data.Duration;
                _isReady = false;
            }
        }

        protected override void UpdateAbility()
        {
            if (!_isReady)
            {
                _remainingDuration -= Time.deltaTime;
                if (_remainingDuration <= 0)
                {
                    Destroy(_droneInstance);
                    _isReady = true;
                }
            }
        }
    }
}