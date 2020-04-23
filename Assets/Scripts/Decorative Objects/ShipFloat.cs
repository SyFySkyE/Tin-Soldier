using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFloat : MonoBehaviour
{
    [Header("Animation Parameters")]
    [Range(0.5f, 5f)] [SerializeField] private float minSpeedMultiplier = 0.5f;
    [Range(0.5f, 5f)] [SerializeField] private float maxSpeedMultiplier = 5f;

    private Animator shipAnim;

    private void Start()
    {
        shipAnim = GetComponent<Animator>();
        shipAnim.SetFloat("ShipSpeed", Random.Range(minSpeedMultiplier, maxSpeedMultiplier));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shipAnim.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shipAnim.enabled = true;
        }
    }
}
