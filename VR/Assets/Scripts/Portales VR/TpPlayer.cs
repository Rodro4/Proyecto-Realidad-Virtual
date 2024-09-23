using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpPlayer : MonoBehaviour
{
    public Transform player;
    public Transform copyPlayer;

    void Update()
    {
        // Los clones del jugador copian su posición y rotación
        copyPlayer.position = player.position;
        copyPlayer.rotation = player.rotation;
    }
}
