using System.Collections;
using Commons;
using UnityEngine;

namespace Players
{
    public class PlayerWeapon : MonoBehaviour, IWeapon
    {
        private const float Cooldown = 0.5f;
        [SerializeField] private Projectile _projectilePrefab;
        private bool _isOnCooldown;
        private int _number;

        public void Attack()
        {
            if (_isOnCooldown) return;

            Shoot();
            StartCoroutine(nameof(StartCooldown));
        }

        private void Shoot()
        {
            var projectile = Instantiate(_projectilePrefab);
            projectile.Initialize(transform.position, transform.forward,
                ServiceLocator<PlayerAttributes>.Service.attackSpeed);
        }

        private IEnumerator StartCooldown()
        {
            _isOnCooldown = true;
            yield return new WaitForSeconds(Cooldown);
            _isOnCooldown = false;
        }
    }
}