using UnityEngine;

namespace BrokenVector.LowPolyFencePack
{
    /// <summary>
    /// This class toggles the door animation.
    /// The gameobject of this script has to have the DoorController script which needs an Animator component
    /// and some kind of Collider which detects your mouse click applied.
    /// </summary>
    [RequireComponent(typeof(DoorController))]
    public class DoorToggle : MonoBehaviour
    {
        bool mouseOnObject;
        private GameObject Jogador;
        private DoorController doorController;
        [Range(0.1f, 10.0f)] private float distancia = 7.5f;
        

        void Awake()
        {
            doorController = GetComponent<DoorController>();
        }

        void Start()
        {
            Jogador = GameObject.FindWithTag("Player");
        }

        void Update()
        {
            if (mouseOnObject == true && Vector3.Distance(transform.position, Jogador.transform.position) < distancia && Input.GetKeyDown(KeyCode.F))
            {
                doorController.ToggleDoor();
            }
        }
        private void OnMouseEnter()
        {
            mouseOnObject = true;
        }

        private void OnMouseExit()
        {
            mouseOnObject = false;
        }
    }
}