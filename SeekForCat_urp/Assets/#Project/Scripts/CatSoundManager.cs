using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSoundManager : MonoBehaviour
{
    // Référence au chat (le GameObject qui émet le son)
    public GameObject cat;

    // Références aux GameObjects parents des lumières
    public GameObject[] lightsParents;

    // Référence à l'AudioSource du chat
    private AudioSource catAudioSource;

    
    void Start()
    {
        // Assurez-vous que le GameObject du chat a un AudioSource attaché
        catAudioSource = cat.GetComponent<AudioSource>();
        if (catAudioSource == null)
        {
            Debug.LogError("L'objet du chat ne contient pas de composant AudioSource.");
        }
    }

    // Méthode appelée lorsqu'on clique sur l'interrupteur
    void Update()
    {
        // Vérifiez l'état des lumières
        bool lightsAreOn = CheckLightsState();

        // Si les lumières sont éteintes, jouez le son du chat
        if (!lightsAreOn)
        {
            if (!catAudioSource.isPlaying)
            {
                catAudioSource.Play();
            }
        }
        // Si les lumières sont allumées, arrêtez le son du chat
        else
        {
            if (catAudioSource.isPlaying)
            {
                catAudioSource.Stop();
            }
        }
    }

    // Méthode pour vérifier l'état des lumières
    bool CheckLightsState()
    {
        // Parcourir tous les parents d'objets (lumières)
        foreach (GameObject lightsParent in lightsParents)
        {
            // Si au moins une lumière est active, retourner true (lumières allumées)
            if (lightsParent.activeSelf)
            {
                return true;
            }
        }
        // Si aucune lumière n'est active, retourner false (lumières éteintes)
        return false;
    }
}
