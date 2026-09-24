using UnityEngine;

public class PlanetOrbitDynamic : MonoBehaviour
{
    [Header("Targets")]
    public Transform sunTarget;
    public Transform planetTarget;

    [Header("Objetos")]
    public Transform orbitPivot;
    public Transform planet;

    [Header("Config")]
    public float orbitSpeed = 30f;
    public float radiusSmoothSpeed = 5f;
    public float spacing = 0.2f;

    [Header("Dynamic Velocity")]
    public float baseOrbitSpeed = 30f;
    public float distanceInfluence = 0.5f;

    float currentRadius;
    float targetRadius;
    int orbitIndex;

    Vector3 direction;

    void Start()
    {
        enabled = false;
    }

    public void SetOrbitIndex(int index)
    {
        orbitIndex = index;
    }

    public void InitializeOrbit()
    {
        if (sunTarget == null || planetTarget == null || planet == null)
            return;

        currentRadius =
            Vector3.Distance(
                sunTarget.position,
                planet.position
            );

        targetRadius = currentRadius;

        direction =
            (planet.position - sunTarget.position).normalized;
    }

    void Update()
    {
        if (sunTarget == null || planetTarget == null)
            return;

        UpdateOrbitRadius();
        UpdateOrbitPosition();
    }

    void UpdateOrbitRadius()
    {
        targetRadius = Vector3.Distance(sunTarget.position, planetTarget.position);
        targetRadius += orbitIndex * spacing;

        currentRadius = Mathf.Lerp(currentRadius, targetRadius, Time.deltaTime * radiusSmoothSpeed);
    }

    void UpdateOrbitPosition()
    {
        orbitPivot.position = sunTarget.position;

        float safeRadius = Mathf.Max(currentRadius, 0.2f);
        float dynamicSpeed = baseOrbitSpeed / Mathf.Pow(safeRadius, distanceInfluence);

        direction = Quaternion.AngleAxis(dynamicSpeed * Time.deltaTime, Vector3.up) * direction;

        planet.position = sunTarget.position + direction * currentRadius;
    }
}
