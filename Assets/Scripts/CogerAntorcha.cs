using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CogerAntorcha : MonoBehaviour
{
    Inventario inventario;
    RespawnAntorcha RespawnAntorcha;
    man man;
    public int on = 1;
    private UnityEngine.Object enemyRef;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        enemyRef = Resources.Load("Antorcha");
        inventario = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventario>();
        
    }

    void Update(){
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player"){
            other.gameObject.GetComponent<man>().LightsOn();
            other.gameObject.GetComponent<RespawnAntorcha>().Saludar();
            //Destroy(gameObject);
            //gameObject.SetActive(false);
            //spriteRenderer.enabled = false;
            //Invoke("Respawn",5);
            //gameObject.SetActive(false);
            //gameObject.SetActive(true);
            //StartCoroutine("Respawnear");
            //other.gameObject.GetComponent<man>().LightsOn();
            //other.gameObject.GetComponent<RespawnAntorcha>().Saludar();
        }
        
    }

    public void Saludar(){
        Debug.Log("AHORA TE SALUDO YO LA ANTORCHA");
    }

    IEnumerator Respawnear(){
        yield return new WaitForSeconds(5);
        gameObject.SetActive(true);
        Debug.Log("LA ANTORCHA DEBÍA HABER VUELTOOOOO");
        }
    void Respawn(){
        gameObject.SetActive(true);
        GameObject enemyClone = (GameObject)Instantiate(enemyRef);
        enemyClone.transform.position = transform.position;
        //Destroy(gameObject);
    }
}
