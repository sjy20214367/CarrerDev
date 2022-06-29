using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public GameObject Main;
    public GameObject Start;
    public GameObject ReStart;
    public GameObject Option;
    public GameObject Challenge;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Main.SetActive(false);
            Start.SetActive(true);
            ReStart.SetActive(false);
            Option.SetActive(false);
            Challenge.SetActive(false);
        }
    }
}
