using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricStunCollider : MonoBehaviour
{
    public float stunDuration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        AnimationTest animTest = other.GetComponent<AnimationTest>();

        if (animTest != null)
        {
            animTest.StartCoroutine(StunCharacter(animTest, stunDuration));
        }
    }

    private System.Collections.IEnumerator StunCharacter(AnimationTest character, float duration)
    {
        character.isStunned = true;
        yield return new WaitForSeconds(duration);
        character.ResetStun();
    }
}