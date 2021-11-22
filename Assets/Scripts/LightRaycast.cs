using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LightRaycast : MonoBehaviour
{
    // Start is called before the first frame update
    RaycastHit2D rchit;
    RaycastHit2D rchit2;
    RaycastHit2D inlight;
    //Collider2D[] lt;
    [SerializeField] float distance;
    public float radius = 10;
    public Color gizmoColor = Color.green;
    public bool showGizmos = true;
    public float lucidez;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //rchit = Physics2D.Raycast(gameObject.transform.position, Vector2.right * 10, distance);
        //rchit2 = Physics2D.Raycast(gameObject.transform.position, Vector2.left * 10, distance);
        //inlight = Physics2D.CircleCast(gameObject.transform.position, 10);
        
        //if(rchit.collider != null) {
        //    Debug.Log("MAN ESTÁ CERCA");
        //    Debug.DrawRay(gameObject.transform.position, Vector2.right * distance, Color.red);
        //}
        //if(rchit2.collider != null && rchit2.transform.CompareTag("Player")) {
        //    Debug.Log("MAN ESTÁ CERCA");
        //   Debug.DrawRay(gameObject.transform.position, Vector2.left * distance, Color.red);
        //}
        //for (int i = 0; i < lt.lenght; i = i + 1){
        //    Debug.Log("ALO");
        //}
        Collider2D[] lt = Physics2D.OverlapCircleAll(gameObject.transform.position, radius);
        foreach (Collider2D l in lt){
            //Debug.Log("HOLAaaa");
            
            if (l != null && l.transform.CompareTag("Player"))
            {
                //Debug.Log("MAN ESTÁ CERCA PERO AHORA EN CIRCULAR");
                lucidez = l.gameObject.GetComponent<man>().lucidez;     
                //Debug.Log(lucidez);
                l.gameObject.GetComponent<man>().quemarse();
            }
                
            
            else
            {
            }
        }
         //if (lt != null && lt.transform.CompareTag("Player"))
         //{
         //    Debug.Log("MAN ESTÁ CERCA PERO AHORA EN CIRCULAR");
         //}
         //else
         //{
             //Debug.Log("MAN ESTÁ LEJOS");
             //IsOverlap = false;
         //}

         var collider = Physics2D.OverlapCircle(gameObject.transform.position, radius);
    }

    private void OnDrawGizmos() {
        if (showGizmos){
            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(transform.position, radius);
        }
        
    }



    public void Interactuar(){
        
    }
}
