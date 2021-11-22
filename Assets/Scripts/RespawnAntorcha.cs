using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAntorcha : MonoBehaviour
{
    UnityEngine.Collider2D cosa;
    //new Vector3 n = transform.position; 
    // Start is called before the first frame update
    int k = 1;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (k == 0){

        }
    }

    public void Saludar(){
        Debug.Log("HOLA SOY RESPAWN");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Antorcha"){
            Debug.Log("ES UNA ANTORCHAA");
            cosa = other;
            //other.gameObject.GetComponent<man>().LightsOn();
            cosa.gameObject.SetActive(false);
            other.gameObject.GetComponent<CogerAntorcha>().on = 0;
            //StartCoroutine("Respawnear");
            //Reactivar(other);
            Invoke("Reactivar",10);
            //other.SetActive(false);
        }
        
    }

    IEnumerator Respawnear(){
        yield return new WaitForSeconds(5);
        Debug.Log("LA ANTORCHA DEBÍA HABER VUELTOOOOO");
        k = 1;
    }

    private void Reactivar(){
        cosa.gameObject.SetActive(true);
        k = 0;
    }

    //UnityEngine.Collider2D other         esto va como parámetro en Reactivar
}
