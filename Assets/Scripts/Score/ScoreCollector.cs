using System;
using UnityEngine;
using Random = UnityEngine.Random;

public sealed class ScoreCollector : MonoBehaviour
{
    public event Action<int> OnRecievedNewRecord;
    public event Action<int, int> OnAdded;

    [SerializeField] private CardCollector _collector;

    [SerializeField, Min(5)] private int _minCount;
    [SerializeField, Min(10)] private int _maxCount;
    private int _bestScoreCount;
    private int _scoreCount;
    private const string BestScore = "BestRecord";

    private void OnEnable()
    {
        _collector.OnCollected += Add;
        _bestScoreCount = PlayerPrefs.GetInt(BestScore, 0);
    }

    private void OnDisable() => _collector.OnCollected -= Add;

    private void Add()
    {
        var randomCount = Random.Range(_minCount, _maxCount);
        _scoreCount += randomCount;
        var previousCount = _scoreCount - randomCount;
        OnAdded.Invoke(_scoreCount, previousCount);
        TryRecieveNewRecord();
    }
    private void TryRecieveNewRecord()
    {
        if (_scoreCount >= _bestScoreCount)
        {
            _bestScoreCount = _scoreCount;
            OnRecievedNewRecord.Invoke(_bestScoreCount);
            Save();
        }
        else
            OnRecievedNewRecord.Invoke(_bestScoreCount);
    }

    private void Save()
    {
        PlayerPrefs.SetInt(BestScore, _bestScoreCount);
    }
}
