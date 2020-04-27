using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    [Header("Y pos to trigger respawn")]
    [SerializeField] private float yPosRespawnTrigger = -100f;

    private Vector3 spawnPos;
    private GameSceneManager gameScene;

    // Start is called before the first frame update
    void Start()
    {
        gameScene = FindObjectOfType<GameSceneManager>();
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= yPosRespawnTrigger)
        {
            gameScene.ReloadCurrentScene(); // TODO Should reload at checkpoints, have fade out anim
        }
    }
}
