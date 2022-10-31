using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

//Feature Point Reuse script
public class Collide : MonoBehaviour
{
    // Start is called before the first frame update
    Score score;
    Cloud cloud;
    PlaySound sound;
    bool ChangedScore = false;
    //Feature Point Enums
    enum projectile { snow, rain };
    [SerializeField]
    projectile proType;
    public Sprite Snow;


    void Start()
    {
        score = FindObjectOfType<Score>();
        cloud = FindObjectOfType<Cloud>();
        sound = FindObjectOfType<PlaySound>();
        if (proType == projectile.snow) 
        {
            addComponent();
        }
    }
    // Feature Point Collision (on collision Enter 2D)
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (proType == projectile.snow)
            {
                if (!ChangedScore)
                {
                    //Feature Point Triggered Sound
                    sound.playChime();
                    score.AddScore();
                    //Feature Point Coroutine
                    StartCoroutine(Fade());
                    ChangedScore = true;
                }
                Destroy(this.gameObject, .75f);

            }
            if(proType == projectile.rain)
            {
                if (!ChangedScore)
                {
                    //Feature Point Triggered Sound
                    sound.playOuch();
                    score.subtractScore(5);
                    ChangedScore = true;
                }
                Destroy(this.gameObject);
            }
        }
        if (collision.gameObject.tag == "Ground" && !ChangedScore && proType != projectile.rain)
        {
            //Feature Point Tags
            GameObject[] collect = GameObject.FindGameObjectsWithTag("Collectables");

            //Feature Point Foreach
            foreach (GameObject snow in collect)
                GameObject.Destroy(snow);

            GameObject[] PlayerL = GameObject.FindGameObjectsWithTag("Player");
            if (PlayerL.Length != 1)
            {
                GameObject first = PlayerL[0];
                GameObject.Destroy(first);
                cloud.lowerState(1);
            }
            else
            {
                score.saveScore();
                SceneLoader.load(SceneLoader.Scene.ScoreScreen);
            }

            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag == "Ground" && proType == projectile.rain)
        {
            Destroy(this.gameObject);
        }
    }
    //Feature Point OnTrigger Enter 2D
    public void OnTriggerEnter2D(Collider2D collider)
    {
        if(proType == projectile.rain)
        {
            if(collider.gameObject.tag == "Shard")
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Snow;
                proType = projectile.snow;
            }
        }

    }
    
    IEnumerator Fade()
    {
        Color colour = GetComponent<SpriteRenderer>().color;
        for (float alpha = 1f; alpha >= 0; alpha -= .1f)
        {
            colour.a = alpha;
            GetComponent<SpriteRenderer>().color = colour;
            yield return new WaitForSeconds(.1f); 
        }
    }
    void addComponent()
    {
        //feature Point Add Component
        gameObject.AddComponent<Rigidbody2D>();
    }
    //Feature Point Gizmos 
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, GetComponent<BoxCollider2D>().bounds.size);
    }
}
