using UnityEngine;

namespace Interactables
{
    public class Tree : MonoBehaviour, IInteractable
    {
        public void Interact()
        {
            GetComponent<Rigidbody>().centerOfMass = Vector3.up * 5.0f;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().AddForce(Vector3.one, ForceMode.Impulse);
            Unhighlight();
            Destroy(this);
        }

        public Vector3 GetPosition()
            => transform.position;

        public void Highlight()
            => transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);

        public void Unhighlight()
            => transform.localScale = new Vector3(1, 1, 1);
    }
}