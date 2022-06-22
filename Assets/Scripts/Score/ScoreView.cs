using UnityEngine;
using TMPro;
using System.Collections;

public sealed class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _bestScoreText;

    [SerializeField] private ScoreCollector _score;
    private WaitForSeconds _wait;

    private void OnEnable()
    {
        _score.OnAdded += Display;
        _bestScoreText.text = PlayerPrefs.GetInt("BestRecord").ToString();
        _score.OnRecievedNewRecord += DisplayBest;
        _wait = new WaitForSeconds(0.02f);
    }

    private void OnDisable()
    {
        _score.OnAdded -= Display;
        _score.OnRecievedNewRecord -= DisplayBest;
    }
    private void Display(int count, int previousCount)
    {
        StartCoroutine(Calculate(count, previousCount));
    }
    private void DisplayBest(int count)
    {
        _bestScoreText.text = $" Best Score: {count}";
    }
    private IEnumerator Calculate(int count, int previousCount)
    {
        while (previousCount < count)
        {
            previousCount++;
            yield return _wait;
            _scoreText.text = previousCount.ToString();
        }
    }
}
