using System.Collections;
using Commons;
using UnityEngine;

namespace Players
{
    public class PlayerWeapon : MonoBehaviour
    {
        private const float Cooldown = 0.5f;
        private bool _isOnCooldown;
        private int _number;

        public void Attack()
        {
            if (_isOnCooldown) return;

            StartCoroutine(nameof(Shoot));
            StartCoroutine(nameof(StartCooldown));
        }

        private IEnumerator Shoot()
        {
            var projectile = GameObject.CreatePrimitive(PrimitiveType.Cube);
            projectile.gameObject.name = "Projectile " + _number++;
            projectile.transform.position = transform.position + transform.forward;
            projectile.transform.forward = transform.forward;
            projectile.transform.localScale = Vector3.one * 0.2f;
            const float lifetime = 2.0f;
            var timer = 0f;

            while (timer < lifetime)
            {
                var target = projectile.transform.forward * Time.deltaTime *
                             ServiceLocator<PlayerAttributes>.Service.attackSpeed;
                projectile.transform.position += target;
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            Destroy(projectile);
        }

        private IEnumerator StartCooldown()
        {
            _isOnCooldown = true;
            yield return new WaitForSeconds(Cooldown);
            _isOnCooldown = false;
        }
    }
}