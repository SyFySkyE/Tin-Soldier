using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState 
{
    None,
    Reading
}

public static class PlayerCurrentState
{
    public static PlayerState currentPlayerState = PlayerState.None;
}
