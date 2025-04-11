using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScriptNew : MonoBehaviour
{
    public GameObject fire;
    public bool isOnFire = false;

    private void Start()
    {
        if (fire != null)
            fire.SetActive(false);
    }

    private void Update()
    {
        if (isOnFire && fire != null && !fire.activeSelf)
        {
            fire.SetActive(true);
        }
    }

    // Quand touché par des particules (ex: flammes)
    private void OnParticleCollision(GameObject other)
    {
        if (!isOnFire)
        {
            SetOnFire();
        }
    }

    // Si on entre en collision avec un objet déjà en feu
    private void OnCollisionEnter(Collision collision)
    {
        FireScriptNew otherFire = collision.gameObject.GetComponent<FireScriptNew>();
        if (otherFire != null && otherFire.isOnFire)
        {
            SetOnFire();
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Continue de propager le feu même après la première collision
        OnCollisionEnter(collision);
    }

    public void SetOnFire()
    {
        isOnFire = true;
        if (fire != null)
            fire.SetActive(true);
    }

    public void ResetFire()
    {
        isOnFire = false;
        if (fire != null)
            fire.SetActive(false);
    }
}
