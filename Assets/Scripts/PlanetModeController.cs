using System.Collections;
using UnityEngine;

public class PlanetModeController : MonoBehaviour
{
    public string planetName;

    [Header("Referências")]
    public GameObject orbitVisual;
    public PlanetOrbitDynamic orbitScript;
    public Transform planetTarget;
    public Transform sunTarget;
    public PlanetInfo planetInfo;
    public PlanetCollision collisionScript;

    [Header("Retorno")]
    public float returnSpeed = 2f;

    [HideInInspector]
    public bool isDestroyed = false;

    bool isOrbiting = false;
    Coroutine returnRoutine;
    Vector3 smoothVelocity = Vector3.zero;

    private void Start()
    {
        orbitScript.enabled = false;
    }

    void Update()
    {
        if (!isOrbiting && returnRoutine == null && planetTarget != null)
        {
            orbitScript.planet.position = planetTarget.position;
        }
    }

    public void StartOrbit(int index)
    {
        if (isDestroyed)
            return;

        isOrbiting = true;

        orbitVisual.SetActive(true);

        orbitScript.sunTarget = sunTarget;
        orbitScript.planetTarget = planetTarget;

        orbitScript.SetOrbitIndex(index);

        orbitScript.InitializeOrbit();

        orbitScript.enabled = true;
    }

    public void StopOrbit()
    {
        if (isDestroyed) return;

        isOrbiting = false;

        orbitScript.enabled = false;

        if (returnRoutine != null)
            StopCoroutine(returnRoutine);

        returnRoutine = StartCoroutine(ReturnToTarget());
    }

    IEnumerator ReturnToTarget()
    {
        smoothVelocity = Vector3.zero;

        while (Vector3.Distance(orbitScript.planet.position, planetTarget.position) > 0.01f)
        {
            orbitScript.planet.position = Vector3.SmoothDamp(
                orbitScript.planet.position,
                planetTarget.position,
                ref smoothVelocity,
                returnSpeed
            );

            yield return null;
        }

        orbitScript.planet.position = planetTarget.position;

        returnRoutine = null;
    }

    public void ResetPlanet()
    {
        isDestroyed = false;

        isOrbiting = false;

        orbitScript.enabled = false;

        if (returnRoutine != null)
        {
            StopCoroutine(returnRoutine);
            returnRoutine = null;
        }

        smoothVelocity = Vector3.zero;

        orbitScript.planet.position = planetTarget.position;
    }

    public bool IsOrbiting()
    {
        return isOrbiting;
    }
}
