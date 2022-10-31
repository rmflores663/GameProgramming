using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstButtonManager : MonoBehaviour
{
    public void ButtonClicked(int val)
    {
        if (val == 30)
        {
            AstSceneLoader.load(AstSceneLoader.Scene.AstTitle);
        }
        if (val == 33)
        {
            AstSceneLoader.load(AstSceneLoader.Scene.AstHowToPlay);
        }
        if (val == 31)
        {
            AstSceneLoader.load(AstSceneLoader.Scene.Asteroids);
        }
        if (val == 32)
        {
            AstSceneLoader.load(AstSceneLoader.Scene.AstScoreScreen);
        }
        if(val == 1)
        {
            AstSceneLoader.load(AstSceneLoader.Scene.GameSelect);
        }
    }
}

