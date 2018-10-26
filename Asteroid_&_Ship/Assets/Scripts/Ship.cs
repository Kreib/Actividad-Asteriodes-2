using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float Speed = 25;
    public GameObject MinimumBoundary;
    public GameObject MaximumBoundary;
    public GameObject ObjectToSpawn;
    public GameObject ObjectToSpawn2;
    public GameObject Death;
    private int HP = 100;
    public int Score = 0;
    public bool AmmoFlag = true;
    // Use this for initialization
    void Start()
    {

    }
    void Shoot()
    {
        if (AmmoFlag){
            GameObject go = Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
            go.AddComponent<Bullet>();
        }

        else 
        {
            GameObject go = Instantiate(ObjectToSpawn2, transform.position, Quaternion.identity);
            go.GetComponent<Renderer>().material.color = Color.red;
            go.AddComponent<Bullet>();

        }


       

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("c"))
        {
            AmmoFlag=!AmmoFlag;
        }

        Transform currentTransform = transform;
        float horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        currentTransform.Translate(Vector3.right * horizontal);

        float x = Mathf.Clamp(currentTransform.position.x, MinimumBoundary.transform.position.x, MaximumBoundary.transform.position.x);



        float vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime*-1;
        currentTransform.Translate(Vector3.up * vertical);

        float y = Mathf.Clamp(currentTransform.position.z, MinimumBoundary.transform.position.z, MaximumBoundary.transform.position.z);
        transform.position = new Vector3(x, 0.0f, y);

        if (Input.GetKeyDown("space"))
        {
           Shoot();
        }
        if (HP <= 0)
        {
            GameObject go = Instantiate(Death, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Vida: " + HP);
        GUI.Label(new Rect(10, 30, 100, 20), "Score: " + Score);

    }
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.name == "Rock(Clone)")
        {
            HP=HP-5;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            CancelInvoke("ResetColor");
            Invoke("ResetColor", 0.1f);
        }
        if (collision.gameObject.name == "E_Bullet")
        {
            HP = HP - 5;
            gameObject.GetComponent<Renderer>().material.color = Color.red;
            CancelInvoke("ResetColor");
            Invoke("ResetColor", 0.1f);
        }





    }
    void OnTriggerEnter(Collider trg)
    {
        if (trg.gameObject.name == "Cube(Clone)")
        {

            if (HP >= 95)
            {
                HP = 100;
            }
            else
            {
                HP = HP + 10;
            }

            Score = Score + 10;
            Destroy(trg.gameObject);
        }
    }
    void ResetColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
