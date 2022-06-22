using System.Collections.Generic;
using UnityEngine;

public sealed class PauseManager : MonoBehaviour
{
    public static PauseManager Instance { get; private set; }
    public bool IsPaused { get; private set; }

    private void Awake()
    {
        Instance = this;
    }
    public void Pause()
    {
        IsPaused = true;
    }
    public void UnPause()
    {
        IsPaused = false;
    }
}

