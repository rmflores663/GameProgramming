using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstUpdate : MonoBehaviour
{
    public Asteroid aster;
    AstScore score;
    PlaySound sound;

    [SerializeField]
    GameObject MAst;
    [SerializeField]
    GameObject SAst;
    int lives;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(aster.scale, aster.scale, 1);
        lives = aster.lives;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = aster.image;
        score = FindObjectOfType<AstScore>();
        sound = FindObjectOfType<PlaySound>();
    }
    void Update()
    {
        //Feature Point instantiating prefabs
        if (lives <= 0 && aster.type == 1)
        {
            sound.playBoom();
            score.AddScore(3);
            Destroy(this.gameObject);

        }
        else if(lives <= 0 && aster.type == 2)
        {
            Instantiate(SAst, transform.position, transform.rotation);
            Instantiate(SAst, transform.position, transform.rotation);
            score.AddScore(2);
            sound.playBoom();
            Destroy(this.gameObject);

        }
        else if(lives <= 0 && aster.type == 3)
        {
            Instantiate(MAst, transform.position, transform.rotation);
            Instantiate(MAst, transform.position, transform.rotation);
            score.AddScore(1);
            sound.playBoom();
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            lives -= 1;
        }
    }
}
