using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// For implementing behavior when player looks at interactive objects.
/// </summary>
[RequireComponent(typeof(Camera))]
public class PlayerCheckInteract : MonoBehaviour
{
    [Header("Raycast Parameters")]
    [Tooltip("How far the raycast will travel, in meters")]
    [SerializeField] private float maxRaycastDistance = 3f;

    private Camera mainCam;

    /// <summary>
    /// Event raised when player looks at different IInteractable
    /// </summary>

    public static event System.Action<IInteractable> LookedAtInteractableChanged;

    public IInteractable InteractiveObjInSight
    {
        get { return this.interactiveObjInSight; }
        private set 
        { 
            if (this.interactiveObjInSight != value)
            {
                this.interactiveObjInSight = value;
                LookedAtInteractableChanged?.Invoke(interactiveObjInSight);
            }            
        }
    }

    private IInteractable interactiveObjInSight;

    private int currentObjInSightHashCode;    

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        InteractiveObjInSight = GetLookedAtInteractable();
    }
    /// <summary>
    /// Raycasts camera foward for Iinteractable objs
    /// </summary>
    /// <returns>The first Iinteractable found, or null</returns>
    private IInteractable GetLookedAtInteractable()
    {
        Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward * maxRaycastDistance, Color.cyan); // Must multiplay dir and distance in second parameter

        RaycastHit hitInfo;
        bool isRayHit = Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hitInfo, maxRaycastDistance);        

        IInteractable interactiveObj = null;

        if (isRayHit)
        {
            if (hitInfo.collider.GetHashCode() != currentObjInSightHashCode) // If the player is looking at the same object (defined by the hitInfo.collider's unique hashcode, don't use GetComponent every fixed cycle!! 
            {
                currentObjInSightHashCode = hitInfo.collider.GetHashCode(); // Set new hashcode
                interactiveObj = hitInfo.collider.gameObject.GetComponent<IInteractable>();
            }
            else // If the player /is/ looking at the same object, just return what's already cached
            {
                return InteractiveObjInSight;
            }
        }
        else // If the player looks away, reset hashcode
        {
            currentObjInSightHashCode = 0;
        }
        return interactiveObj;
    }
}
