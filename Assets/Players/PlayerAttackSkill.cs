using System.Threading.Tasks;
using UnityEngine;

namespace Players
{
    public class PlayerAttackSkill
    {
        private readonly Vector3 _originalScale;
        private readonly PlayerController _player;
        private bool _isAttacking;

        public PlayerAttackSkill(PlayerController player)
        {
            // _player = player;
            // _player.AttackStarted += OnAttackStarted;
            // _originalScale = Vector3.one;
            // _player.transform.localScale = _originalScale;
        }

        private void OnAttackStarted()
        {
            // if (_isAttacking) return;
            //
            // _isAttacking = true;
            // var targetScale = _originalScale * 3.0f;
            //
            // TaskHelper.Run(Attack(_originalScale, targetScale), () =>
            // {
            //     _isAttacking = false;
            //     ServiceLocator<PlayerController>.Service.EndAttack();
            // });
        }

        private async Task Attack(Vector3 originalScale, Vector3 targetScale)
        {
            // await Scale(targetScale);
            // await Scale(originalScale);
        }

        private async Task Scale(Vector3 targetScale)
        {
            // var attackSpeed = ServiceLocator<PlayerAttributes>.Service.attackSpeed;
            // var duration = 0.5f;
            // var timer = 0f;
            //
            // while (true)
            // {
            //     if (_player.transform.localScale == targetScale) break;
            //
            //     var step = timer / duration;
            //     _player.transform.localScale = Vector3.Lerp(_player.transform.localScale, targetScale, step);
            //
            //     timer += Time.deltaTime * attackSpeed;
            //     await Task.Delay(1);
            // }
            //
            // _player.transform.localScale = targetScale;
        }
    }
}