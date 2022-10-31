using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonManager : MonoBehaviour
{
    public void ButtonClicked(int state)
    {
        if(state == 20)
        {
            SceneLoader.load(SceneLoader.Scene.Title);
        }
        if(state == 30)
        {
            AstSceneLoader.load(AstSceneLoader.Scene.AstTitle);
        }
    }
}
