using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState 
{
    None,
    Reading,
    LookingInInventory
}

public static class PlayerCurrentState
{
    public static PlayerState CurrentPlayerState = PlayerState.None;
}
