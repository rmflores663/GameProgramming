using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Feature Point Use of Classes
public class Cloud : MonoBehaviour
{
    Vector3 direction = new Vector3(1, 0, 0);

    [SerializeField]
    GameObject snowflake;
    [SerializeField]
    GameObject rain;

    //Feature Point UI Slider
    public Slider difficulty;
    Score score;
    bool startRain = false;
    int speed = 7;
    int width = 9;
    int state = 0;
    int pscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        difficulty.value = 0;
        score = FindObjectOfType<Score>();
        //Feature Point Random Value/Range
        Invoke("ChangeDirectionRan", Random.Range(1f, 3f));
        Invoke("spawnSnow", 0.75f);

    }

    // Update is called once per frame
    void Update()
    {
        //Feature Point Time.deltaTime
        transform.position += (direction * speed * Time.deltaTime);

        float xval = transform.position.x;

        if(xval> width-1 || xval < -width+1)
        {
            changeDirection();
            xval = Mathf.Clamp(xval, -width+1, width-1);
        }
        //Feature Point Enforeced Boundries
        transform.position = new Vector3(xval, transform.position.y, transform.position.z);


        if (score.GetScore() > pscore+7)
        {
            state = 1;
        }
        if (score.GetScore() > pscore+25)
        {
            state = 2;
        }
        if(score.GetScore() > pscore+35)
        {
            state = 3;
        }
        if (score.GetScore() > pscore+50)
        {
            state = 4;
        }

        //Feature Point Switch
        switch (state)
        {
            case 0:
                break;
            case 1:
                StartRain();
                difficulty.value = 1;
                break;
            case 2:
                difficulty.value = 2;
                break;
            case 3:
                difficulty.value = 3;
                break;
            case 4:
                difficulty.value = 4;
                break;
        }
    }

    void StartRain()
    {
        if (!startRain)
        {
            Invoke("spawnRain", Random.Range(3f, 5f));
            startRain = true;
        }
    }

    void ChangeDirectionRan()
    {
        changeDirection();
        Invoke("ChangeDirectionRan", Random.Range(1f, 3f));
    }

    void changeDirection()
    {
        speed *= -1;
    }

    void spawnSnow()
    {
        //Feature Point Instantiate Prefabs
        Instantiate(snowflake, transform.position, transform.rotation);

        //Feature Point Switch
        switch (state)
        {
            case 0:
                Invoke("spawnSnow", 1);
                break;
            case 1:
                Invoke("spawnSnow", 0.75f);
                break;
            case 2:
                Invoke("spawnSnow", 0.6f);
                break;
            case 3:
                Invoke("spawnSnow", 0.5f);
                break;
            case 4:
                Invoke("spawnSnow", 0.35f);
                break;
        }
    }

    void spawnRain()
    {
        //Feature Point Instantiate Prefabs
        Instantiate(rain, transform.position, transform.rotation);
        //Feature Point Invoke/Invoke Repeating
        if (state < 3)
        {
            Invoke("spawnRain", Random.Range(3f, 5f));
        }
        else
        {
            Invoke("spawnRain", Random.Range(2f, 4f));
        }
    }
    public void lowerState(int _state)
    {
        if(_state < state)
        {
            pscore = score.GetScore();
            state = _state;
        }
    }
    public float getState()
    {
        return state;
    }
}
