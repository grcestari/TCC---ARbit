using System.Collections.Generic;
using UnityEngine;

public class SolarSystemManager : MonoBehaviour
{
    public static SolarSystemManager Instance;

    public Transform sunAnchor;
    public bool sunDetected = false;

    public List<PlanetModeController> planets = new List<PlanetModeController>();

    void Awake()
    {
        Instance = this;
    }

    public void RegisterSun(Transform sun)
    {
        sunAnchor = sun;
        sunDetected = true;
    }

    public void RegisterPlanet(PlanetModeController planet)
    {
        if (!planets.Contains(planet))
            planets.Add(planet);
    }

    public void StartOrbitDetectionOrder()
    {
        if (!sunDetected)
            return;

        int orbitIndex = 0;

        foreach (var planet in planets)
        {
            if (planet.isDestroyed)
                continue;

            planet.StartOrbit(orbitIndex);

            orbitIndex++;
        }
    }

    public void StopAllOrbits()
    {
        foreach (var planet in planets)
        {
            planet.StopOrbit();
        }
    }

    public void RestorePlanets()
    {
        foreach (var planet in planets)
        {
            if (planet.collisionScript != null)
            {
                planet.collisionScript.ResetCollision();
            }
        }
    }
}
