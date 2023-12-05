using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedroomSwitch : MonoBehaviour
{
    public CatMoodManager catMoodManager; // Assurez-vous de lier le CatMoodManager dans l'inspecteur Unity

    public GameObject lightsParent1;
    public GameObject lightsParent2;

    void OnMouseDown()
    {
        // Inverser l'état des lumières
        lightsParent1.SetActive(!lightsParent1.activeSelf);
        lightsParent2.SetActive(!lightsParent2.activeSelf);

        // Appeler la méthode dans CatMoodManager pour ajuster la jauge d'humeur
        if (catMoodManager != null)
        {
            if (lightsParent1.activeSelf || lightsParent2.activeSelf)
            {
                // Si au moins une lumière est allumée, diminuer la jauge d'humeur
                catMoodManager.DecreaseMood(1f); // Ajustez la valeur selon vos besoins
            }
            else
            {
                // Si toutes les lumières sont éteintes, augmenter la jauge d'humeur
                catMoodManager.IncreaseMood(1f); // Ajustez la valeur selon vos besoins
            }
        }
    }
}
