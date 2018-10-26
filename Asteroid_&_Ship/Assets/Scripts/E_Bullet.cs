using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_Bullet : MonoBehaviour
{
    private float speed = -10;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * -(speed));

    }
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

    }
}
