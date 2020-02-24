using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    private Material currentMaterial;

    // Start is called before the first frame update
    void Start()
    {
        currentMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        currentMaterial.color = Color.Lerp(Color.gray, Color.black, Mathf.PingPong(Time.time, 1));
    }
}
