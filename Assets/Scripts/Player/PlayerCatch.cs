using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCatch : MonoBehaviour
{
    [Header("Y pos to trigger respawn")]
    [SerializeField] protected float yPosRespawnTrigger = -100f;

    protected Vector3 spawnPos;
    private GameSceneManager gameScene;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        gameScene = FindObjectOfType<GameSceneManager>();
        spawnPos = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (this.transform.position.y <= yPosRespawnTrigger)
        {
            gameScene.ReloadCurrentScene(); // TODO Should reload at checkpoints, have fade out anim
        }
    }
}
