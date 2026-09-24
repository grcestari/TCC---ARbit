using TMPro;
using UnityEngine;
using static UnityEngine.AdaptivePerformance.Provider.AdaptivePerformanceSubsystemDescriptor;

public class PlanetInfoUIRadial : MonoBehaviour
{
    [Header("Data")]
    public PlanetInfo planetInfo;

    [Header("Texts")]
    public TextMeshPro nameText;
    public TextMeshPro compositionText;
    public TextMeshPro pressureText;
    public TextMeshPro moonsText;
    public TextMeshPro descriptionText;

    void Start()
    {
        if (planetInfo == null) return;

        nameText.text = planetInfo.planetName;
        compositionText.text = planetInfo.mainComposition;
        pressureText.text = planetInfo.atmosphericPressure;
        moonsText.text = planetInfo.moons;
        descriptionText.text = planetInfo.planetDescription;
    }
}
