using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScriptNew : MonoBehaviour
{
    public GameObject fire;
    public GameObject explosionPrefab;
    public Transform explosionPosition;
    public bool isOnFire = false;
    public bool isExplosive = false;

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

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log($"{gameObject.name} touché par particules d'eau -> feu éteint");
            ResetFire();
        }
        else
        {
            if (!isOnFire)
            {
                SetOnFire();
            }
        }
    }

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
        OnCollisionEnter(collision);
    }

    private void OnTriggerEnter(Collider other)
    {
        FireScriptNew otherFire = other.gameObject.GetComponent<FireScriptNew>();
        if (otherFire != null && otherFire.isOnFire)
        {
            SetOnFire();
        }
    }

    public void SetOnFire()
    {
        if (isExplosive && explosionPrefab != null && isOnFire == false)
        {
            AudioManager.Instance.PlaySound("Explosion", transform.position);
            Instantiate(explosionPrefab, explosionPosition.position, Quaternion.identity);
        }

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