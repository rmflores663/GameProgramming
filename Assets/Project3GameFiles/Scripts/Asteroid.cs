using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AsteroidGameObject", menuName = "Asteroid")]
public class Asteroid : ScriptableObject
{
    public Sprite image;
    public float scale;
    public int lives;
    public int type;
}
