using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Update()
    {
        if(transform.position.x > 10 || transform.position.x < -10 || transform.position.y > 6 || transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        Destroy(this.gameObject);
    }
}
