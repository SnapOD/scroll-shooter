using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level creation/BackgroundPart", fileName = "BackgroundPart")]
public class BackgroundPart : ScriptableObject
{
    public int width;
    public int height;
    public Sprite sprite;
}
