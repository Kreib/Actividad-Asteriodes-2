using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Rock : MonoBehaviour {
    public float speed;
    public GameObject Death;
    private int HP = 5;
    public GameObject Recompensa;
    public int RND;

    public GameObject personaje;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	
    void Update () {

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        if(HP<=0)
        {

            GameObject go = Instantiate(Death, transform.position, Quaternion.identity);
            Ship ship = personaje.GetComponent<Ship>();
            ship.Score = ship.Score + 10;
            RND = Random.Range(0, 2);
            if(RND==0)
            {
                GameObject went = Instantiate(Recompensa, transform.position, Quaternion.identity);
                went.AddComponent<Rigidbody>();
                went.GetComponent<Rigidbody>().useGravity = false;
                went.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;
            }
            Destroy(gameObject);
            

        }


    }
    void OnCollisionEnter(Collision collision)
    {
       
        if(collision.gameObject.GetComponent<Renderer>().material.color == Color.red){
            HP--;
        }
        HP--;
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        CancelInvoke("ResetColor");
        Invoke("ResetColor", 0.1f);
       
    }
    void ResetColor()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.white;
    }
}
