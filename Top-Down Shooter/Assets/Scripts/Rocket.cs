using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject explosionEffectPrefab;            // Holds the prefab for the explosion effect

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Instantiate(explosionEffectPrefab, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}
