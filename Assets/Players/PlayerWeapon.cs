using System.Collections;
using Items.Scripts;
using UnityEngine;
using VContainer;

namespace Players
{
    public class PlayerWeapon : MonoBehaviour, IWeapon
    {
        private const float Cooldown = 0.5f;
        [SerializeField] private Projectile projectilePrefab;
        private bool _isOnCooldown;
        private int _number;
        private PlayerAttributes _playerAttributes;

        public void Attack()
        {
            if (_isOnCooldown) return;

            Shoot();
            StartCoroutine(nameof(StartCooldown));
        }

        [Inject]
        public void Construct(PlayerAttributes playerAttributes)
        {
            _playerAttributes = playerAttributes;
        }

        private void Shoot()
        {
            var projectile = Instantiate(projectilePrefab);
            projectile.Initialize(transform.position, transform.forward, _playerAttributes.attackSpeed);
        }

        private IEnumerator StartCooldown()
        {
            _isOnCooldown = true;
            yield return new WaitForSeconds(Cooldown);
            _isOnCooldown = false;
        }
    }
}