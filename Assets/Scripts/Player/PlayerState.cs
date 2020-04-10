using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState 
{
    None,
    Reading
}

public class PlayerCurrentState : MonoBehaviour
{
    public PlayerState currentPlayerState { get; set; }
}
