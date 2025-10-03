using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

namespace Players
{
    public class Hammer : Weapon
    {
        private const float Cooldown = 0.3f;
        [SerializeField] private Transform pivotPoint;
        [SerializeField] private PlayableDirector playableDirector;

        private bool _isOnCooldown;

        public override void Attack()
        {
            if (_isOnCooldown) return;

            playableDirector.Play();
            StartCoroutine(nameof(StartCooldown));
        }

        private IEnumerator StartCooldown()
        {
            _isOnCooldown = true;
            yield return new WaitForSeconds(Cooldown);
            _isOnCooldown = false;
        }
    }
}