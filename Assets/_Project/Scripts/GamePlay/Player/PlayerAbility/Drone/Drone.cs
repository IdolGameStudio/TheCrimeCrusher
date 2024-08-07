using UnityEngine;

namespace _Project.Scripts.GamePlay.Player.PlayerAbility.Drone
{
    public class Drone : MonoBehaviour
    {
        private Vector3 _targetPosition;
        private bool _isMoving = false;
        private bool _isAttacking = false;
        private DroneAttackData _data;
        private AreaDamage _areaDamage;

        public void Initialize(Vector3 targetPosition, DroneAttackData data, AreaDamage areaDamage)
        {
            _targetPosition = targetPosition;
            _data = data;
            _areaDamage = areaDamage;
            _isMoving = true;
        }

        private void Update()
        {
            if (_isMoving)
            {
                MoveTowardsTarget();
            }

            if (_isAttacking)
            {
                // Вызов анимации огня или других визуальных эффектов
                _areaDamage.ApplyDamage(transform.position, _data.Damage, _data.Range);
            }
        }

        private void MoveTowardsTarget()
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _data.Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, _targetPosition) < (_data.Range / 2))
            {
                _isAttacking = true;
            }

            if (Vector3.Distance(transform.position, _targetPosition) < 0.1f)
            {
                _isMoving = false;
                _isAttacking = false;
                // Дрон может вернуться к игроку или исчезнуть
                Destroy(gameObject);
            }
        }
    }
}