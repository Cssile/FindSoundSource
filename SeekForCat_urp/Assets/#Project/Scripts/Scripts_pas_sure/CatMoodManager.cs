using UnityEngine;
using UnityEngine.Events;
using TMPro;
using UnityEngine.UI;

public class CatMoodManager : MonoBehaviour
{
    public float MoodValue { get; private set; }
    public Slider moodSlider;
    public TextMeshProUGUI moodPercentageText;

    public UnityEvent onVeryScared;
    public UnityEvent onScared;
    public UnityEvent onComfortable;
    public UnityEvent onHappy;
    public UnityEvent onVeryHappy;

    void Start()
    {
        // Initialiser la valeur de la jauge d'humeur au centre (onComfortable)
        MoodValue = 50f;

        // Mettre à jour la valeur de la barre de progression
        moodSlider.value = MoodValue;
    }

    void Update()
    {
        // Mettre à jour la valeur de la jauge d'humeur (par exemple, en fonction d'actions du joueur)
        // ...
        UpdateMood(MoodValue);

        // Appeler la mise à jour du texte de pourcentage
        UpdateMoodPercentageText();
    }

    public void UpdateMood(float value)
    {
        // Utiliser Mathf.Clamp pour s'assurer que la valeur reste entre 0 et 100 inclusivement
        MoodValue = Mathf.Clamp(value, 0f, 100f);

        float deltaValue = value - MoodValue;
        float step = deltaValue / 20f;

        // Lerp (interpolation linéaire) pour une transition plus douce
        MoodValue = Mathf.Lerp(MoodValue, value, step);

        // Mettre à jour la valeur de la barre de progression
        moodSlider.value = MoodValue;

        // Déclencher des événements en fonction de la valeur de la jauge
        if (MoodValue <= 10f)
        {
            onVeryScared.Invoke();
        }
        else if (MoodValue <= 30f)
        {
            onScared.Invoke();
        }
        else if (MoodValue <= 70f)
        {
            onComfortable.Invoke();
        }
        else if (MoodValue <= 90f)
        {
            onHappy.Invoke();
        }
        else
        {
            onVeryHappy.Invoke();
        }
    }

    public void DecreaseMood(float value)
    {
        // Diminuer la jauge d'humeur progressivement vers la gauche
        UpdateMood(MoodValue - value);
    }

    public void IncreaseMood(float value)
    {
        // Augmenter la jauge d'humeur progressivement vers la droite
        UpdateMood(MoodValue + value);
    }

    void UpdateMoodPercentageText()
    {
        // Mettre à jour le texte avec le pourcentage de la jauge
        moodPercentageText.text = Mathf.RoundToInt(MoodValue) + "%";
    }
}
