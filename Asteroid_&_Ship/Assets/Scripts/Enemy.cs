using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float Speed = 25;
    public GameObject MinimumBoundary;
    public GameObject MaximumBoundary;
    public GameObject ObjectToSpawn;
    public GameObject Death;
    private int HP = 100;
    public int Score = 0;
    public bool AmmoFlag = true;
    // Use this for initialization
    void Start()
    {
        Invoke("Shoot", 3);
    }
    void Shoot()
    {

            GameObject go = Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
            go.AddComponent<E_Bullet>();
            go.gameObject.name = "E_Bullet";
            go.AddComponent<Rigidbody>();
            go.GetComponent<Rigidbody>().useGravity = false;

        Invoke("Shoot", 3);




    }

    // Update is called once per frame
    void Update()
    {
       
       


        Transform currentTransform = transform;
        float horizontal = Input.GetAxis("Horizontal") * Speed * Time.deltaTime*-1;
        currentTransform.Translate(Vector3.right * horizontal);

        float x = Mathf.Clamp(currentTransform.position.x, MinimumBoundary.transform.position.x, MaximumBoundary.transform.position.x);



        float vertical = Input.GetAxis("Vertical") * Speed * Time.deltaTime ;
        currentTransform.Translate(Vector3.up * vertical);

        float y = Mathf.Clamp(currentTransform.position.z, MinimumBoundary.transform.position.z, MaximumBoundary.transform.position.z);
        transform.position = new Vector3(x, 0.0f, y);

       
       

    }

   
    void ResetColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
