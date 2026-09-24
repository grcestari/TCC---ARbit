using TMPro;
using UnityEngine;

public class PlanetInfoUI : MonoBehaviour
{
    [Header("Dados")]
    public GameObject root;

    [Header("Objetos para esconder")]
    public GameObject objectToHide;

    [Header("Textos")]
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI compositionText;
    public TextMeshProUGUI pressureText;
    public TextMeshProUGUI moonsText;
    public TextMeshProUGUI descriptionText;

    void Start()
    {
        Hide();
    }

    public void Show(PlanetInfo info)
    {
        if (objectToHide != null) objectToHide.SetActive(false);

        if (info == null) return;

        root.SetActive(true);

        nameText.text = info.planetName;
        compositionText.text = info.mainComposition;
        pressureText.text = info.atmosphericPressure;
        moonsText.text = info.moons;
        descriptionText.text = info.planetDescription;
    }

    public void Hide()
    {
        if (objectToHide != null) objectToHide.SetActive(true);

        root.SetActive(false);
    }
}
