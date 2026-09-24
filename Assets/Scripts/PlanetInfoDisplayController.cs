using UnityEngine;

public class PlanetInfoDisplayController : MonoBehaviour
{
    [Header("Configurações do Planeta")]
    public PlanetModeController planetMode;

    public PlanetInfo planetInfo;

    public Transform planet;

    [Header("Configurações da Interface")]
    public GameObject radialInfo;

    [Header("Painel Global")]
    public PlanetInfoUI panelUI;

    [Header("Configurações")]
    public float panelDistance = 5f;

    [Header("Sol")]
    public bool isSun = false;

    static PlanetInfoDisplayController currentFocusedPlanet;

    Camera cam;

    bool paused = false;

    void Start()
    {
        cam = Camera.main;

        radialInfo.SetActive(false);
    }

    void Update()
    {
        if (planet == null || cam == null || planetMode == null)
            return;

        float dist =
            Vector3.Distance(
                cam.transform.position,
                planet.position
            );

        bool closeEnough = dist <= panelDistance;

        if (planetMode.isDestroyed)
        {
            radialInfo.SetActive(false);

            if (currentFocusedPlanet == this)
            {
                panelUI.Hide();

                currentFocusedPlanet = null;
            }

            if (paused)
            {
                ResumeSystem();
            }

            return;
        }

        if (planetMode.IsOrbiting())
        {
            if (closeEnough)
            {
                currentFocusedPlanet = this;

                radialInfo.SetActive(true);

                if (!paused)
                {
                    PauseSystem();
                }
            }
            else
            {
                radialInfo.SetActive(false);

                if (currentFocusedPlanet == this)
                {
                    currentFocusedPlanet = null;
                }

                if (paused)
                {
                    ResumeSystem();
                }
            }
            if (currentFocusedPlanet == this)
            {
                panelUI.Hide();
            }
        } else
        {
            radialInfo.SetActive(false);

            if (closeEnough)
            {
                currentFocusedPlanet = this;

                panelUI.Show(planetInfo);
            }
            else
            {
                if (currentFocusedPlanet == this)
                {
                    panelUI.Hide();

                    currentFocusedPlanet = null;
                }
            }

            if (paused)
            {
                ResumeSystem();
            }
        }
    }

    void PauseSystem()
    {
        paused = true;
        Time.timeScale = 0.05f;
    }

    void ResumeSystem()
    {
        paused = false;
        Time.timeScale = 1f;
    }
}
