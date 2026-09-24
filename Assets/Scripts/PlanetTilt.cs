using UnityEngine;

public class PlanetTilt : MonoBehaviour
{
    [Header("Configuração")]
    public string planetName;

    void Start()
    {
        float tilt = 0f;

        switch (planetName)
        {
            case "Mercury": tilt = 0.03f; break;
            case "Venus": tilt = 177.4f; break;
            case "Earth": tilt = 23.5f; break;
            case "Mars": tilt = 25f; break;
            case "Jupiter": tilt = 3f; break;
            case "Saturn": tilt = 26.7f; break;
            case "Uranus": tilt = 97.8f; break;
            case "Neptune": tilt = 28.3f; break;
        }

        transform.localRotation = Quaternion.Euler(tilt, 0, 0);
    }
}
