using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BillboardLookCamera : MonoBehaviour
{
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void LateUpdate()
    {
        if (cam == null) return;

        transform.rotation = Quaternion.LookRotation(cam.transform.forward, Vector3.up);
    }
}
