using Unity.VisualScripting;
using UnityEngine;

public class PlanetCollision : MonoBehaviour
{
    [Header("Explosão")]
    public GameObject explosionPrefab;

    [Header("Referências")]
    public PlanetModeController planetModeController;
    public GameObject planetRoot;

    [Header("Objeto extra para explodir")]
    public GameObject extraObjectToDestroy;

    bool exploded = false;

    private void OnTriggerEnter(Collider other)
    {
        if (exploded) return;

        PlanetCollision otherPlanet = other.GetComponent<PlanetCollision>();

        if (otherPlanet == null) return;

        if (otherPlanet.exploded) return;

        exploded = true;
        otherPlanet.exploded = true;

        Explode(other.transform);
    }

    void Explode(Transform otherPlanet)
    {
        Vector3 pos =
            (transform.position + otherPlanet.position) / 2f;

        Instantiate(explosionPrefab, pos, Quaternion.identity);

        if (planetModeController != null)
        {
            planetModeController.isDestroyed = true;
        }

        PlanetCollision otherPlanetCollision =
            otherPlanet.GetComponent<PlanetCollision>();

        if (
            otherPlanetCollision != null &&
            otherPlanetCollision.planetModeController != null
        )
        {
            otherPlanetCollision.planetModeController.isDestroyed = true;
        }

        if (extraObjectToDestroy != null)
        {
            extraObjectToDestroy.SetActive(false);
        }

        if (
            otherPlanetCollision != null &&
            otherPlanetCollision.extraObjectToDestroy != null
        )
        {
            otherPlanetCollision.extraObjectToDestroy.SetActive(false);
        }

        planetRoot.SetActive(false);

        if (otherPlanetCollision != null)
        {
            otherPlanetCollision.planetRoot.SetActive(false);
        }
    }

    public void ResetCollision()
    {
        exploded = false;

        planetRoot.SetActive(true);

        if (planetModeController != null)
        {
            planetModeController.ResetPlanet();
        }
    }
}
