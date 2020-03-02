using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDecoration : MonoBehaviour
{
    [Header("What color the material will lerp to, from black")]
    [SerializeField] private Color colorToTransition;

    [Header("Minimum Trantion Speed")]
    [Range(0.3f, 2f)] [SerializeField] private float minTransitionMultiplier = 0f;

    [Header("Maximum Trantion Speed")]
    [Range(0.3f, 2f)] [SerializeField] private float maxTransitionMultiplier = 1f;

    private float transitionMultiplier;

    private Material currentMaterial;

    // Start is called before the first frame update
    void Start()
    {
        currentMaterial = GetComponent<Renderer>().material;
        transitionMultiplier = Random.Range(minTransitionMultiplier, maxTransitionMultiplier);
    }

    // Update is called once per frame
    void Update()
    {
        currentMaterial.color = Color.Lerp(Color.black, colorToTransition, Mathf.PingPong(Time.time * transitionMultiplier, 1));
    }
}