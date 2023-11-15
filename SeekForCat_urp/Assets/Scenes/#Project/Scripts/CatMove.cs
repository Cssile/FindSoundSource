using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatMove : MonoBehaviour
{
    public string hidingSpotTag = "HidingSpot"; // Tag des cachettes
    private GameObject[] hidingSpots; // Tableau des cachettes

    private Transform targetHidingSpot; // Cachette actuelle du chat
    private int currentHidingSpotIndex = 0; // Index de la cachette actuelle

    private NavMeshAgent navMeshAgent; // Composant NavMeshAgent pour les déplacements

    private bool isMoving = false; // Variable de contrôle

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        // Initialiser la première cachette comme cible
        SetNewTargetHidingSpot();
    }

    void Update()
    {
        // Déplacer le chat vers la cachette si la variable de contrôle le permet
        if (isMoving && navMeshAgent.remainingDistance < 0.5f)
        {
            // Le chat est arrivé à la cachette, désactiver la variable de contrôle
            isMoving = false;
        }
    }

    public void SetNewTargetHidingSpot()
    {
        // Si le chat n'est pas déjà en mouvement
        if (!isMoving)
        {
            // Trouver toutes les cachettes avec le tag spécifié
            hidingSpots = GameObject.FindGameObjectsWithTag(hidingSpotTag);

            // Choisir une nouvelle cachette aléatoire
            currentHidingSpotIndex = Random.Range(0, hidingSpots.Length);
            targetHidingSpot = hidingSpots[currentHidingSpotIndex].transform;

            // Activer la variable de contrôle pour permettre au chat de se déplacer
            isMoving = true;

            // Utiliser le NavMeshAgent pour déplacer le chat vers la cachette
            navMeshAgent.SetDestination(targetHidingSpot.position);
        }
    }
}
