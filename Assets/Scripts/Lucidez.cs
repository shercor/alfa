using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lucidez : MonoBehaviour
{
    public Image lifeBar;
    public Text lifeText;
    public Text keys;
    // Start is called before the first frame update
    public float myLife;
    private float currentLife;
    private float calculateLife;
    public man man;
    private float life;
    private int nkeys = 0;
    void Start()
    {
        currentLife = myLife;
        life = man.GetComponent<man>().actualHP;
        
    }

    // Update is called once per frame
    void Update()
    {
        calculateLife = currentLife / myLife;
        lifeBar.fillAmount = Mathf.MoveTowards(lifeBar.fillAmount, calculateLife, Time.deltaTime);
        lifeText.text = "" + (int)currentLife/100;
        life = man.GetComponent<man>().actualHP;
        //Debug.Log("WOOOO");
        //Debug.Log("Vida actual: " + life);
        currentLife = life;

    }

    public void Damage(float damage){
        currentLife -= damage;
    }

    public void newkey(){
        Debug.Log("SUMAR LLAVE");
        nkeys += 1;
        keys.text = "" + (int)nkeys;

    }

    public void usekey(){
        Debug.Log("RESTAR LLAVE");
        nkeys -= 1;
        keys.text = "" + (int)nkeys;

    }
}
