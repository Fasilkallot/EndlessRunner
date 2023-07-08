using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Invoke("SetDeactivate", 4f);
        }
    }
    void SetDeactivate()
    {
        this.gameObject.SetActive(false);
    }
}
