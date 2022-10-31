using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class AstSceneLoader
{
    public enum Scene { AstTitle, Asteroids, AstScoreScreen, AstHowToPlay, GameSelect};

    public static void load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
