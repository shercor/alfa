using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.CompareTag("Enemy"))
        {
            Debug.Log("Enemy Defeated");
            Destroy(collision.gameObject);
        }
    }
}