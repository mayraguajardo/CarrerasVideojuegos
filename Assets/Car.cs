using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public float speed;
    public Transform target;
    public GameObject canvas;
    public GameObject objetoLap;
    private int lap = 1;
    public GameObject objetoTimer;
    private float tiempo = 0.0f;

    // Start is called before the first frame update

    void Start()
    {
        speed=0;
        Text textoLap = objetoLap.GetComponent<Text>();
        textoLap.text = "Lap: " + lap;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(0,0,1*Time.deltaTime * 5*speed);
        if((Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S))&&speed<7&&speed>-7){
            if(v>0){
               speed+=0.3f; 
            }
            else if(v<0){
                speed-=0.3f; 
            }
        }
        if((Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.A))&speed!=0){
            transform.Rotate(0,h*Time.deltaTime*50,0);
            target.Rotate(0,h*Time.deltaTime*50,0);
        }

        Text textoTimer = objetoTimer.GetComponent<Text>();
        textoTimer.text = "" + tiempo;
        tiempo += Time.deltaTime;
        

    }
    void LateUpdate(){
        
        if(speed<0&&speed>-0.1){
            speed=0;
        }
        else if(speed>0&&speed<0.1){
            speed=0;
        }
        if(speed>0){
            speed-=0.1f;
        }
        if(speed<0){
            speed+=0.1f;
        }
       
    }

    void OnTriggerEnter(Collider c)
    {
        Text textoLap = objetoLap.GetComponent<Text>();
        lap++;
        textoLap.text = "Lap: " + lap;

        if (lap > 3)
        {
            GameObject child =  GameObject.Find("Text2");
            Text t = child.GetComponent<Text>();
            if(t.text!="Ganaste!!!"){
                textoLap.text = "Ganaste!!!";
                textoLap.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1*canvas.GetComponent<RectTransform>().rect.width/2,-1*canvas.GetComponent<RectTransform>().rect.height/4);
            }
            else{
                textoLap.text = "Perdiste!!!";
                textoLap.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1*canvas.GetComponent<RectTransform>().rect.width/2,-1*canvas.GetComponent<RectTransform>().rect.height/4);
            }
            speed -= 0.5f;
            Destroy(this,1f);
        }
    }
}
