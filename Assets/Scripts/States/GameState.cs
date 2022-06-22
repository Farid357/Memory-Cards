using System;
using UnityEngine;

public sealed class GameState : MonoBehaviour
{
    private void OnApplicationPause(bool pause)
    {
        if (pause)
           PauseManager.Instance.Pause();
    }

    public void Pause()
    {
        PauseManager.Instance.Pause();
    }
    public void Continue()
    {
        PauseManager.Instance.UnPause();
    }
    public void Exit()
    {
        Application.Quit();
        Debug.Log("Exit");
    }
}
