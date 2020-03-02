using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For implementing behavior when player looks at interactive objects.
/// </summary>
public class PlayerCheckInteract : MonoBehaviour
{
    [Header("Raycast Parameters")]
    [Tooltip("How far the raycast will travel, in meters")]
    [SerializeField] private float maxRaycastDistance = 3f;

    private Camera mainCam;

    public IInteractable InteractiveObjInSight
    {
        get { return this.interactiveObjInSight; }
        private set { this.interactiveObjInSight = value; }
    }

    private IInteractable interactiveObjInSight;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward * maxRaycastDistance, Color.cyan); // Must multiplay dir and distance in second parameter

        RaycastHit hitInfo;
        bool isRayHit = Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hitInfo, maxRaycastDistance);

        if (isRayHit)
        {
            switch (hitInfo.transform.tag)
            {
                case "Interactable":
                    interactiveObjInSight = hitInfo.collider.gameObject.GetComponent<IInteractable>();
                    break;
                default:
                    interactiveObjInSight = null;
                    break;
            }           
        }
        else
        {
            interactiveObjInSight = null;
        }
    }
}
