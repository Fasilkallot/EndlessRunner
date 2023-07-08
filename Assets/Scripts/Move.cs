using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private void FixedUpdate()
    {
        if (PlayerControler.isPlayerDead)
        {
            return;
        }
        this.transform.position += PlayerControler.player.transform.forward * -8f* Time.deltaTime;
    }
}
