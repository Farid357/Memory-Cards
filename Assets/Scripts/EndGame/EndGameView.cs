using UnityEngine;

public sealed class EndGameView : MonoBehaviour
{
    [SerializeField] EndGame _game;
    [SerializeField] private GameObject _endPanel;

    private void OnEnable()
    {
        _game.OnEnded += ShowPanel;
    }
    private void OnDisable()
    {
        _game.OnEnded -= ShowPanel;
    }
    private void ShowPanel()
    {
        _endPanel.SetActive(true);
    }
}
