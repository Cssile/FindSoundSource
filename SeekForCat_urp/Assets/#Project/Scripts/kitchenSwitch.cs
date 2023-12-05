using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kitchenSwitch : MonoBehaviour
{
    public CatMoodManager catMoodManager; // Assurez-vous de lier le CatMoodManager dans l'inspecteur Unity

    public GameObject lightsParent1;
    public GameObject lightsParent2;
    public GameObject lightsParent3;
    public GameObject lightsParent4;
    public GameObject lightsParent5;
    public GameObject lightsParent6;
    public GameObject lightsParent7;

    void OnMouseDown()
    {
        // Inverser l'état des lumières
        lightsParent1.SetActive(!lightsParent1.activeSelf);
        lightsParent2.SetActive(!lightsParent2.activeSelf);
        lightsParent3.SetActive(!lightsParent3.activeSelf);
        lightsParent4.SetActive(!lightsParent4.activeSelf);
        lightsParent5.SetActive(!lightsParent5.activeSelf);
        lightsParent6.SetActive(!lightsParent6.activeSelf);
        lightsParent7.SetActive(!lightsParent7.activeSelf);

        // Appeler la méthode dans CatMoodManager pour ajuster la jauge d'humeur
        if (catMoodManager != null)
        {
            if (lightsParent1.activeSelf || lightsParent2.activeSelf || lightsParent3.activeSelf ||
                lightsParent4.activeSelf || lightsParent5.activeSelf || lightsParent6.activeSelf || lightsParent7.activeSelf)
            {
                // Si au moins une lumière est allumée, diminuer la jauge d'humeur
                catMoodManager.DecreaseMood(10f); // Ajustez la valeur selon vos besoins
            }
            else
            {
                // Si toutes les lumières sont éteintes, augmenter la jauge d'humeur
                catMoodManager.IncreaseMood(10f); // Ajustez la valeur selon vos besoins
            }
        }
    }
}
