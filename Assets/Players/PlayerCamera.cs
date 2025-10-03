using UnityEngine;

namespace Players
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private float verticalDistance;
        [SerializeField] private float horizontalDistance;

        private void Update()
        {
            if (Camera.main == null) return;

            Camera.main.transform.position = transform.position
                                             + verticalDistance * Vector3.up
                                             + horizontalDistance * Vector3.back;
            Camera.main.transform.LookAt(transform.position);
        }
    }
}