using UnityEngine;

public class ToogleMenu : MonoBehaviour
{
    [Header("Configurações do Menu")]
    public GameObject menu;

    public void ToggleMenu()
    {
        menu.SetActive(!menu.activeSelf);
    }
}
