using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [Header("Configuração")]
    public string planetName;

    [Header("Controle do Tempo")]
    public float timeMultiplier = 1f;

    private float rotationSpeed;

    private void Start()
    {
        float hours = GetRotationHours(planetName);
        rotationSpeed = 360f / (hours * 3600f);
    }

    void FixedUpdate()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * timeMultiplier * Vector3.up, Space.Self);
    }

    private float GetRotationHours(string planetName)
    {
        switch (planetName)
        {
            case "Mercury": return 1407.6f;
            case "Venus": return -5832.5f;
            case "Earth": return 24f;
            case "Mars": return 24.6f;
            case "Jupiter": return 9.9f;
            case "Saturn": return 10.7f;
            case "Uranus": return -17.2f;
            case "Neptune": return 16.1f;
            default: return 24f;
        }
    }

    public void SetSpeed(float speed)
    {
        timeMultiplier = speed;
    }
}
