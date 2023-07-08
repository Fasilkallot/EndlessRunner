using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public static GameObject lastPlatform;
    public static GameObject dummyPlayer;

    private void Awake()
    {
        dummyPlayer= new GameObject("dummy");
    }
    public static void RunDummy()
    {
        GameObject p = ObjectPool.myPool.GetRandom();
        if (p == null) return;

        if(lastPlatform != null) 
        { 
            if(lastPlatform.tag== "PlatformT")
            {
                dummyPlayer.transform.position = lastPlatform.transform.position + PlayerControler.player.transform.forward * 20;
            }
            else
            {
                dummyPlayer.transform.position = lastPlatform.transform.position + PlayerControler.player.transform.forward * 10;
            }
        }
        lastPlatform = p;
        p.SetActive(true);
        p.transform.position = dummyPlayer.transform.position;
        p.transform.rotation= dummyPlayer.transform.rotation;
    }
    
}
