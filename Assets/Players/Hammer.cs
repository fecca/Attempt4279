using System.Collections;
using Items;
using UnityEngine;

namespace Players
{
    public class Hammer : MonoBehaviour, IWeapon
    {
        private const float Cooldown = 0.5f;
        [SerializeField] private Transform pivotPoint;
        [SerializeField] private BoxCollider collider;
        private bool _isOnCooldown;

        private void Awake()
        {
            collider.enabled = false;
        }

        public void Attack()
        {
            if (_isOnCooldown) return;

            StartCoroutine(nameof(StartAttack));
            StartCoroutine(nameof(StartCooldown));
        }

        private IEnumerator StartAttack()
        {
            collider.enabled = true;
            float angle;
            var timer = 0f;
            const float time = 0.2f;
            while (timer < time)
            {
                angle = Time.deltaTime * 90 * 4.0f;
                transform.RotateAround(pivotPoint.position, pivotPoint.right, angle);
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            timer = 0f;
            while (timer < time)
            {
                angle = Time.deltaTime * 90 * 4.0f;
                transform.RotateAround(pivotPoint.position, pivotPoint.right, -angle);
                timer += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            collider.enabled = false;
        }

        private IEnumerator StartCooldown()
        {
            _isOnCooldown = true;
            yield return new WaitForSeconds(Cooldown);
            _isOnCooldown = false;
        }
    }
}