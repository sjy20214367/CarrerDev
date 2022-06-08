using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject Main;
    public GameObject NewGame;
    public GameObject ReStart;
    public GameObject Option;

    public void MainCilck_Start()
    {
        Main.SetActive(false);
        NewGame.SetActive(true);
        ReStart.SetActive(false);
        Option.SetActive(false);
    }
    public void MainCilck_ReStart()
    {
        Main.SetActive(false);
        ReStart.SetActive(true);
        NewGame.SetActive(false);
        Option.SetActive(false);
    }
    public void MainCilck_Option()
    {
        Main.SetActive(false);
        Option.SetActive(true);
        ReStart.SetActive(false);
        NewGame.SetActive(false);
    }
    public void MainCilck_Exit()
    {
        // ���� ����
        Application.Quit();
        // ����Ƽ������ ����
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
