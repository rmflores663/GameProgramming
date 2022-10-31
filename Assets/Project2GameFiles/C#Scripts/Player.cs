using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 mousePos;
    Vector3 newPos;
    [SerializeField]
    GameObject IceShard;
    GameObject Head;
    GameObject Body;
    GameObject Base;

    // Start is called before the first frame update
    void Start()
    {
        Head = this.gameObject.transform.GetChild(0).gameObject;
        Body = this.gameObject.transform.GetChild(1).gameObject;
        Base = this.gameObject.transform.GetChild(2).gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        //Feature Point Mouse Tracking
        mousePos = Input.mousePosition;
        newPos = Camera.main.ScreenToWorldPoint(mousePos);
        newPos.y = transform.position.y;
        newPos.z = transform.position.z;

        newPos.x = Mathf.Clamp(newPos.x, -9, 9);

        transform.position = newPos;

        //Feature Point Input system (input get)
        if (Input.GetKeyDown(KeyCode.S))
        {
            shoot();
        }
    }
    void shoot()
    {
        //FeaturePoint Shooting
        //Feature Point Instantiate Prefabs
        Instantiate(IceShard, transform.position, transform.rotation);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        //Feature Point getChild()
        Gizmos.DrawSphere(this.gameObject.transform.GetChild(0).gameObject.transform.position, this.gameObject.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>().bounds.size.x);
        Gizmos.DrawSphere(this.gameObject.transform.GetChild(1).gameObject.transform.position, this.gameObject.transform.GetChild(1).gameObject.GetComponent<CircleCollider2D>().bounds.size.x);
        Gizmos.DrawSphere(this.gameObject.transform.GetChild(2).gameObject.transform.position, this.gameObject.transform.GetChild(2).gameObject.GetComponent<CircleCollider2D>().bounds.size.x);
    }
}
