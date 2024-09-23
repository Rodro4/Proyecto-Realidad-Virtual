using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpPlayer : MonoBehaviour
{
    public Transform player;
    public Transform copyPlayer;

    void Update()
    {
        // Los clones del jugador copian su posici�n y rotaci�n
        copyPlayer.position = player.position;
        copyPlayer.rotation = player.rotation;
    }
}
