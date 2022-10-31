using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

//Feature Point Singleton
//Feature Point Scoring System
//Feature Point Singleton
public class AstScore : MonoBehaviour
{
    GameObject score;
    int i = 0;

    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("Score");
    }

    
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Asteroids")
        {
            score.GetComponent<TextMeshProUGUI>().text = "Score: " + i;

        }
        else if (SceneManager.GetActiveScene().name == "AstScoreScreen")
        {
            i = PlayerPrefs.GetInt("Score", -1);
            score.GetComponent<TextMeshProUGUI>().text = i.ToString(); ;
        }
    }


    public void saveScore()
    {
        PlayerPrefs.SetInt("Score", i);
    }
    public void AddScore()
    {
        i++;
    }
    //Feature Point Setter
    public void AddScore(int _i)
    {
        i += _i;
    }
    //Feature Point Setter
    public void subtractScore(int _i)
    {
        i -= _i;
    }
    //Feature Point Getter
    public int GetScore()
    {
        return i;
    }
}
