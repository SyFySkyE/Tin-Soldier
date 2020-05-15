using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckpoint : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;

    public Vector3 GetRespawnPoint()
    {
        return respawnPoint.position;
    }
}
