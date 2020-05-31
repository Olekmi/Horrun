using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;


public class GameManager : MonoBehaviour
{
    public GameObject endMenuUI;
    public static bool GameIsPaused = false;

    void EndMenu()
    {
        endMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

    }

    public void EndGame()
    {
        Debug.Log("GAME OVER");
        EndMenu();
    }

}
