using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public ParticleSystem fireParticles;
    public GameObject prefabFire;
    public GameObject firePaper;
    public bool isOnFire = false;


    private void Start()
    {
        firePaper.SetActive(false);
    }

    private void OnParticleCollision(GameObject particle)
    {
        Invoke(nameof(FirePaper), 1f);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<ParticleCollision>())
        {
            if (isOnFire == true)
            {
                Instantiate(prefabFire);
                prefabFire.transform.position = collision.gameObject.transform.position;
                Destroy(collision.gameObject);
                Destroy(gameObject);

            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponent<HackDrone>())
        {
            if (other.gameObject.GetComponent<HackDrone>().fire)
            {
                FirePaper();
            }
        }
    }


    private void FirePaper()
    {
        firePaper.SetActive(true);
        isOnFire = true;
        Invoke(nameof(FireGrow), 15f);
    }

    private void FireGrow()
    {
        fireParticles.startSize = 6f;
    }

    private void DestroyPaper()
    {
        Destroy(gameObject);
    }
}
