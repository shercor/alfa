using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform spawnPoint;
    public float radius = 2;

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Player")){
            collision.gameObject.GetComponent<man>().damage();
        }   
        //SceneManager.LoadScene("Juego");
        //collision.transform.position = spawnPoint.position;
    }

    void Update(){
        Collider2D[] lt = Physics2D.OverlapCircleAll(gameObject.transform.position, radius);
        foreach (Collider2D l in lt){
            if (l != null && l.transform.CompareTag("Player"))
            {
                Debug.Log("DAMAGE DEL ENEMIGO");
                l.gameObject.GetComponent<man>().damage();
            }
                
            
            else
            {
                //Debug.Log("Aló");
                //IsOverlap = false;
            }
        }
    }
    
}
