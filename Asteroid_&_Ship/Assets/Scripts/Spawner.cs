using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject ObjectToSpawn;
    public GameObject MinimumBoundary;
    public GameObject MaximumBoundary;
    public float MinSpeed;
    public float MaxSpeed;



    void CreateAsteroid()
    {
        GameObject go= Instantiate(ObjectToSpawn, transform.position, Quaternion.identity);
        go.AddComponent<Rigidbody>();
        go.AddComponent<BoxCollider>();
        go.AddComponent<Rock>();
        go.GetComponent<Rigidbody>().useGravity = false;
        go.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationX;

        go.GetComponent<Rock>().speed = Random.Range(MinSpeed,MaxSpeed);

    }

    void RandomMove()
    {
        Transform currentTransform = transform;

        transform.position = new Vector3(Random.Range(MinimumBoundary.transform.position.x, MaximumBoundary.transform.position.x), 0.0f, MinimumBoundary.transform.position.z);

        CreateAsteroid();



        Invoke("RandomMove", 2);
    }

    // Use this for initialization
    void Start()
    {
        Invoke("RandomMove", 2);
    }

    // Update is called once per frame
    void Update()
    {
       
       

    }
}
