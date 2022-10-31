using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCollide : MonoBehaviour
{
    AstScore score;
    void Start()
    {
        score = FindObjectOfType<AstScore>();
    }
    void OnCollisionEnter2D(Collision2D collide)
    {
        print(collide.gameObject.name);
        if (collide.gameObject.tag == "Enemy")
        {
            GameObject[] PlayerL = GameObject.FindGameObjectsWithTag("Lives");

            if (PlayerL.Length != 1)
            {
                GameObject first = PlayerL[0];
                GameObject.Destroy(first);
            }
            else
            {
                score.saveScore();
                AstSceneLoader.load(AstSceneLoader.Scene.AstScoreScreen);
            }

            GameObject[] Asteroids = GameObject.FindGameObjectsWithTag("Enemy");

            foreach (GameObject ast in Asteroids)
            {
                GameObject.Destroy(ast);
            }
        }
    }
}
