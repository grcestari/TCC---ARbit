using UnityEngine;
using Vuforia;

public class PlanetTargetHandler : MonoBehaviour
{
    public bool isSun = false;
    public PlanetModeController planetController;
    public PlanetInfo planetInfo;

    ObserverBehaviour observer;

    void Start()
    {
        observer = GetComponent<ObserverBehaviour>();

        if (observer)
            observer.OnTargetStatusChanged += OnStatusChanged;
    }

    void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            if (isSun)
            {
                SolarSystemManager.Instance.RegisterSun(transform);
            }
            else
            {
                planetController.gameObject.SetActive(true);
                SolarSystemManager.Instance.RegisterPlanet(planetController);
            }
        }
        else
        {
            planetController.gameObject.SetActive(false);
        }
    }
}
