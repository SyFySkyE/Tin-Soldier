using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For implementing behavior when player looks at interactive objects.
/// </summary>
public class PlayerInteract : MonoBehaviour
{
    [Header("Raycast Parameters")]
    [Tooltip("How far the raycast will travel, in meters")]
    [SerializeField] private float maxRaycastDistance = 3f;

    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, maxRaycastDistance);
        Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward * maxRaycastDistance, Color.cyan); // Must multiplay dir and distance in second parameter
    }
}
