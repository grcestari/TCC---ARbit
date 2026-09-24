using UnityEngine;

public class PlanetHeatController : MonoBehaviour
{
    [Header("Targets")]
    public Transform sunTarget;
    public Transform planetTarget;

    [Header("Heat Settings")]
    public float minDistance = 2f;
    public float maxDistance = 4f;

    [Range(0f, 1f)]
    public float heatValue;

    Renderer[] renderers;

    void Start()
    {
        renderers = GetComponentsInChildren<Renderer>();
    }

    void Update()
    {
        if (sunTarget == null || planetTarget == null) return;

        float distance = Vector3.Distance(sunTarget.position, planetTarget.position);

        heatValue = Mathf.InverseLerp(maxDistance, minDistance, distance);

        foreach (Renderer render in renderers)
        {
            render.material.SetFloat("_OceanHeat", heatValue);
        }
    }
}
