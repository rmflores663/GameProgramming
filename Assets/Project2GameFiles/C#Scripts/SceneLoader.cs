using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader {

    public enum Scene{ Title, ApplePickerProject, ScoreScreen, HowToPlay, GameSelect};

    public static void load(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
