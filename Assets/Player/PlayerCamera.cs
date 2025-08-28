using UnityEngine;

namespace Player
{
    public class PlayerCamera : MonoBehaviour
    {
        [SerializeField] private new Camera camera;
        [SerializeField] private float verticalDistance;
        [SerializeField] private float horizontalDistance;

        private void Update()
        {
            camera.transform.position = ServiceLocator<PlayerController>.Service.transform.position
                                        + verticalDistance * Vector3.up
                                        + horizontalDistance * Vector3.back;
            camera.transform.LookAt(ServiceLocator<PlayerController>.Service.transform.position);
        }
    }
}