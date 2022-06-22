using System;
using UnityEngine;

public sealed class EndGame : MonoBehaviour
{
    public event Action OnEnded;
    [SerializeField] private LevelData _level;
    [SerializeField] private CardCollector _collector;
    private int _count;

    private void OnEnable()
    {
        _count = _level.XCount * _level.YCount;
        _collector.OnCollected += Check;
    }
    private void OnDisable() => _collector.OnCollected -= Check;

    private void Check()
    {
        _count -= 2;
        if (_count <= 0)
            OnEnded.Invoke();
    }

}
