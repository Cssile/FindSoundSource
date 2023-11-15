using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private string horizontalInputName = "Horizontal";
    [SerializeField] private string verticalInputName = "Vertical";
    [SerializeField] private CatMove catMoveScript; // Référence au script du chat

    [SerializeField] private float movementSpeed = 2f;
    [SerializeField] private float interactionDistance = 5f; // Distance à partir de laquelle le joueur peut interagir avec le chat

    private CharacterController charController;
    private bool canInteract = false; // Indique si le joueur peut interagir avec le chat

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();

        // Détection du clic de souris
        if (Input.GetMouseButtonDown(0))
        {
            HandleMouseClick();
        }
    }

    private void PlayerMovement()
    {
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;

        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);
    }

    private void HandleMouseClick()
    {
        // Créer un rayon depuis la position de la souris dans la direction de la caméra
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Vérifier si le rayon intersecte quelque chose
        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            // Si l'objet cliqué a le tag "Cat", changer la cachette du chat
            if (hit.collider.CompareTag("Cat"))
            {
                catMoveScript.SetNewTargetHidingSpot();
            }
        }
    }

    private void OnGUI()
    {
        // Afficher un message à l'écran pour indiquer au joueur qu'il peut interagir avec le chat
        if (canInteract)
        {
            GUI.Label(new Rect(Screen.width / 2 - 100, Screen.height - 50, 200, 50), "Cliquez pour interagir");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Activer la possibilité d'interagir lorsque le joueur entre dans la zone d'interaction avec le chat
        if (other.CompareTag("Cat"))
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Désactiver la possibilité d'interagir lorsque le joueur sort de la zone d'interaction avec le chat
        if (other.CompareTag("Cat"))
        {
            canInteract = false;
        }
    }
}
