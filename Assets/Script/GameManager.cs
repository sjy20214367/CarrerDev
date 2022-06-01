using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int sceneNumberToLoad;   
    public static bool isTouchedScreen;

    private void Awake()
    {
        sceneNumberToLoad = 1;
    }
}
