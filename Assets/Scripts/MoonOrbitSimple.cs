using UnityEngine;

public class MoonOrbitSimple : MonoBehaviour
{
    public Transform earth;
    public Transform moonPivot;

    public float orbitSpeed = 50f;

    void Update()
    {
        if (earth == null || moonPivot == null) return;

        moonPivot.position = earth.position;

        moonPivot.Rotate(Vector3.up * orbitSpeed * Time.deltaTime);
    }
}
