using UnityEngine;

[CreateAssetMenu(fileName = "PlanetInfo", menuName = "Scriptable Objects/PlanetInfo")]
public class PlanetInfo : ScriptableObject
{
    [Header("Configurações")]

    [Tooltip("Informe o nome do planeta.")]
    public string planetName;

    [Tooltip("Composição Principal")]
    public string mainComposition;

    [Tooltip("Pressão Atmosférica")]
    public string atmosphericPressure;

    [Tooltip("Luas")]
    public string moons;

    [Tooltip("Informe uma descrição ao planeta.")]
    [TextArea(3, 10)]
    public string planetDescription;
}
