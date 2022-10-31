using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchState : MonoBehaviour
{
    public void buttonClicked(int val)
    {
        if (val == 20)
        {
            SceneLoader.load(SceneLoader.Scene.Title);
        }
        if (val == 1)
        {
            SceneLoader.load(SceneLoader.Scene.GameSelect);
        }
        if (val == 23)
        {
            SceneLoader.load(SceneLoader.Scene.HowToPlay);
        }
        if(val == 21)
        {
            SceneLoader.load(SceneLoader.Scene.ApplePickerProject);
        }
        if (val == 22)
        {
            SceneLoader.load(SceneLoader.Scene.ScoreScreen);
        }
    }
}
