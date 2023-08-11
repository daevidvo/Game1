using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float multiplier = 5.0f;
    public float Duration = 2f;
    void OnTriggerEnter2D(Collider2D paper) 
    {
        if (paper.CompareTag("Player"))
        {
            StartCoroutine( Pickup(paper) );
        }
    }
    IEnumerator Pickup(Collider2D player)
    {
        Debug.Log("Power up picked up");
        PlayerMovement MOOvement = player.GetComponent<PlayerMovement>();

        MOOvement.moveSpeed *= multiplier;

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        yield return new WaitForSeconds (Duration);

        MOOvement.moveSpeed /= multiplier;

        Destroy(gameObject);
    }
}
