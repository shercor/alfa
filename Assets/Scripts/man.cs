using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.Experimental.Rendering.Universal;
//using UnityEngine.Experimental.Rendering.LWRP;
using UnityEngine.SceneManagement;

public class man : MonoBehaviour
{
    // Start is called before the first frame update
    public float JumpForce;
    public float Speed;
    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    public bool Grounded = true;
    public float velocity;
    public Animator animator;
    //Light lt;
    public GameObject Lights; // drag-drop this in Inspector
    public float lucidez = 12313;
    public string name = "Pinochet";
    private float maxHP = 10000;
    private float HP = 10000;
    public float actualHP;
    public float heal = 0;
    public Lucidez interfaz;
    public int keys = 0;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        //lt = GetComponent<Light>();
        //foreach (Transform child in hit.transform)
        //    GameObject light = child.GetChild(0).gameObject;
        //light.enabled = true;
        Lights.SetActive(false);
        Debug.Log("Hola");
        //StartCoroutine("Esperar");
;    }

    IEnumerator Esperar(){
        yield return new WaitForSeconds(10);
        Lights.SetActive(false);
        Debug.Log("LUCES APAGADAS");
        heal = 0;
        }



    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        //Debug.Log(lucidez);

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.286917f, 1.658214f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.286917f, 1.658214f,1.0f);
        animator.SetFloat("Speed", Mathf.Abs(Horizontal));
        HP = HP - 1 + 1 * heal;
        if (HP >= maxHP){
            HP = maxHP;
        }
        //Debug.Log(HP);
        if (HP <= 0){
            SceneManager.LoadScene("Juego");
        }
        if (HP % 10 == 0){
            //Debug.Log(HP);
            //RECORDAR DESCOMENTAR ESTO
        actualHP = HP;
        }
        //Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
        //if (Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
        //{
        //    Grounded = true;
        //}
        //else Grounded = false;

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            animator.SetBool("IsJumping", true);
            Jump();
        }
        
        if (Input.GetKeyDown("r"))
        {
            //Jump();
            SceneManager.LoadScene("Juego");
        };
        if (Input.GetKeyDown(KeyCode.Return))
        {
            //Jump();
            SceneManager.LoadScene("Main Menu");
        };

        
        
    }

    private void Jump(){
        Rigidbody2D.AddForce(Vector2.up * JumpForce);
        Grounded = false;
    }

    public void LightsOn(){
        float currentTime = 0;
        float maxTime = 8000;
        Debug.Log("LUCES ENCENDIDAS");
        Lights.SetActive(true);
        heal = 1;
        StartCoroutine("Esperar");
        //waitfor(5);
    }

    public IEnumerator waitfor(int n){
        yield return new WaitForSeconds(2);
        Lights.SetActive(true);
    }
    private void FixedUpdate(){
        Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
    }
    
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Grounded = true;
        //Lights.SetActive(false);
        animator.SetBool("IsJumping", false);
        if(collision == null)
        {
            //Debug.Log("LUUUZ");
            //Destroy(collision.gameObject);
        }
    }

    public void quemarse(){
        //Debug.Log(":D");
        HP = HP + 2;
        if (HP >= maxHP){
            HP = maxHP;
        }
        actualHP = HP;
    }

    public void damage(){
        //Debug.Log("ME QUEMOO");
        HP = HP - 5;
        actualHP = HP;
    }

    public void antorcha(){

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Key"){
            Debug.Log("ES UNA LLAVEEE");
            //cosa = other;
            //other.gameObject.GetComponent<man>().LightsOn();
            //cosa.gameObject.SetActive(false);
            interfaz.GetComponent<Lucidez>().newkey();
            Destroy(other.gameObject);
            keys += 1;
            //other.gameObject.GetComponent<man>(). = 0;
            //StartCoroutine("Respawnear");
            //Reactivar(other);
            //Invoke("Reactivar",10);
            //other.SetActive(false);
        }

        if (other.tag == "Puerta"){
            Debug.Log("LA PUERTA");
            //cosa = other;
            //other.gameObject.GetComponent<man>().LightsOn();
            //cosa.gameObject.SetActive(false);
            if (keys >= 1){
                Debug.Log("GANASTE MAN");
                keys -= 1;
                interfaz.GetComponent<Lucidez>().usekey();
                SceneManager.LoadScene("Final");
            }
            else{
                Debug.Log("VE A BUSCAR LA KEY MAN");
            }
            //other.gameObject.GetComponent<man>(). = 0;
            //StartCoroutine("Respawnear");
            //Reactivar(other);
            //Invoke("Reactivar",10);
            //other.SetActive(false);
        }
        
    }

    
}
