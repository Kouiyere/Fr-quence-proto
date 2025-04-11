using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNPC : MonoBehaviour
{
    public GameObject fire;
    public bool isOnFire;


    private void Start()
    {
        fire.SetActive(false);
        isOnFire = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<HackWaste>())
        {
            if (collision.gameObject.GetComponent<HackWaste>().isOnFire == true)
            {
                fire.SetActive(true);
                isOnFire = true;
            }
        }
    }
}
