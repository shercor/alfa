using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.CompareTag("Player"))
        {
            Debug.Log("Damage Played");
            //Destroy(collision.gameObject);
        }
        if(collision.transform.CompareTag("Item"))
        {
            Debug.Log("Enemy Destroyed");
            Destroy(this);
        }
    }
}
