using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CityPeople
{
    public class DemoCamera : MonoBehaviour
    {
        public AnimationCurve easingCurve;
        public float motionTimeTotal = 1.0f;
        public Camera[] cameraTargets;
        public GameObject TextLeft;
        public GameObject TextRight;
        public Text TextCharName;
        public string HintMessage;
        public List<Material> MaterialRef;
        public Texture[] Textures;

        private int currentCamera;
        private Collider hoveredCollider;
        private CityPeople hoveredPeople;
        private Vector3 hoveredStoredPos;
        private Quaternion hoveredStoredRotation;
        private Vector3 hoveredStoredScale;
        private float motionTime = 2.1f;
        private Vector3 startPosition;
        private Vector3 targetPosition;


        private void Start()
        {
            motionTime = motionTimeTotal + 0.1f;
            DisableArrows();
            if (cameraTargets.Length > 0)
            {
                var startCam = cameraTargets[currentCamera];
                if (startCam != null) transform.position = cameraTargets[currentCamera].transform.position;
            }

            TextCharName.text = HintMessage;
        }

        private void Update()
        {
            if (motionTime < motionTimeTotal)
            {
                motionTime = motionTime + Time.deltaTime;
                var normalizedTime = motionTime / motionTimeTotal;
                var easedTime = easingCurve.Evaluate(normalizedTime);
                transform.position = Vector3.Lerp(startPosition, targetPosition, easedTime);
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) OnRightClick();

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) OnLeftClick();


            CharacterClicks(); //notOK
            MouseMove();
            HoverSpin();
        }

        private void HoverSpin()
        {
            if (hoveredPeople != null) hoveredPeople.transform.Rotate(0, 90f * Time.deltaTime, 0);
        }

        private void MouseMove()
        {
            var mousePos = Input.mousePosition;
            if (mousePos.x >= 0 && mousePos.x <= Screen.width && mousePos.y >= 0 && mousePos.y <= Screen.height)
            {
                var ray = Camera.main.ScreenPointToRay(mousePos);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    var currentCollider = hit.collider;
                    if (currentCollider != hoveredCollider)
                    {
                        if (hoveredCollider != null) ColliderExit(hoveredCollider);

                        ColliderEnter(currentCollider);
                        hoveredCollider = currentCollider;
                    }
                }
                else
                {
                    if (hoveredCollider != null)
                    {
                        ColliderExit(hoveredCollider);
                        hoveredCollider = null;
                    }
                }
            }
        }

        private void ColliderEnter(Collider currentCollider)
        {
            hoveredPeople = currentCollider.gameObject.GetComponent<CityPeople>();
            if (hoveredPeople != null)
            {
                if (TextCharName != null)
                    TextCharName.text =
                        $"{hoveredPeople.transform.parent.name} > {hoveredPeople.name} (mat: {hoveredPeople.CurrentPaletteName})";

                var t = hoveredPeople.gameObject.transform;
                hoveredStoredPos = t.position;
                hoveredStoredScale = t.localScale;
                hoveredStoredRotation = t.rotation;
                t.position += new Vector3(0, 0, 1f);
                t.localScale = Vector3.one * 1.5f;
            }
        }

        private string CharacterInfo(CityPeople cityPeople)
        {
            var s = $"{cityPeople.transform.parent.name} > {cityPeople.name} ";
            var rends = cityPeople.GetComponentsInChildren<Renderer>();
            foreach (var rend in rends)
            {
                // var matName = mesh.sharedMaterial.name 
            }

            return s;
        }

        private void ColliderExit(Collider currentCollider)
        {
            hoveredPeople = currentCollider.gameObject.GetComponent<CityPeople>();
            if (hoveredPeople != null)
            {
                var t = hoveredPeople.gameObject.transform;
                t.position = hoveredStoredPos;
                t.localScale = hoveredStoredScale;
            }

            if (TextCharName != null) TextCharName.text = HintMessage;

            hoveredPeople = null;
        }

        private void CharacterClicks()
        {
            if (Input.GetMouseButtonDown(0))
                if (hoveredPeople != null)
                {
                    var idx = MaterialRef.FindIndex(m => m.name == hoveredPeople.CurrentPaletteName);
                    idx += 1;
                    if (idx == MaterialRef.Count) idx = 0;
                    hoveredPeople.SetPalette(MaterialRef[idx]);
                    if (TextCharName != null)
                        TextCharName.text =
                            $"{hoveredPeople.transform.parent.name} > {hoveredPeople.name} (mat: {hoveredPeople.CurrentPaletteName})";
                }
        }

        private void GoTo(Camera cam)
        {
            startPosition = transform.position;
            targetPosition = cam.transform.position;
            motionTime = 0;
        }

        public void OnLeftClick()
        {
            if (currentCamera > 0)
            {
                currentCamera--;
                var nextCam = cameraTargets[currentCamera];
                GoTo(nextCam);
                DisableArrows();
            }
        }

        public void OnRightClick()
        {
            if (currentCamera < cameraTargets.Length - 1)
            {
                currentCamera++;
                var nextCam = cameraTargets[currentCamera];
                GoTo(nextCam);
                DisableArrows();
            }
        }


        private void DisableArrows()
        {
            if (TextRight != null && TextLeft != null)
            {
                TextRight.SetActive(currentCamera < cameraTargets.Length - 1);
                TextLeft.SetActive(currentCamera > 0);
            }
        }
    }
}