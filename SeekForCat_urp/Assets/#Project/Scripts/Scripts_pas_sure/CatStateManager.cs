using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class CatStateManager : MonoBehaviour
{
    public CatMoodManager moodManager;

    // Méthode appelée pour ajuster le comportement du chat en fonction de la jauge d'humeur
    public void AdjustCatBehavior()
    {
        // Exemple de logique : ajuster le comportement du chat en fonction de la valeur de la jauge
        if (moodManager.MoodValue <= 10f)
        {
            Debug.Log("Chat très peureux");
            // Ajoutez ici les actions spécifiques pour un chat très peureux
        }
        else if (moodManager.MoodValue <= 30f)
        {
            Debug.Log("Chat fuyant");
            // Ajoutez ici les actions spécifiques pour un chat fuyant
        }
        else if (moodManager.MoodValue <= 50f)
        {
            Debug.Log("Chat à l'aise");
            // Ajoutez ici les actions spécifiques pour un chat à l'aise
        }
        else if (moodManager.MoodValue <= 70f)
        {
            Debug.Log("Chat très à l'aise");
            // Ajoutez ici les actions spécifiques pour un chat très à l'aise
        }
        else
        {
            Debug.Log("Chat affectueux");
            // Ajoutez ici les actions spécifiques pour un chat affectueux
        }
    }

    // Renommer la méthode pour éviter le conflit
    public void UpdateCatMood(float value)
    {
        // Ajoutez ici toute logique supplémentaire si nécessaire
        moodManager.UpdateMood(value);
    }
}

