using UnityEngine;
using UnityEngine.UI;

public sealed class RecieveSound : MonoBehaviour
{
    [SerializeField] private CardCollector _collector;
    [SerializeField] private AudioSource _recieveSound;
    [SerializeField] private Button _onSFXButton;

    private void OnEnable()
    {
        _collector.OnCollected += Play;
    }
    private void OnDestroy()
    {
        _collector.OnCollected -= Play;
    }
    private void Play()
    {
        if(_onSFXButton.gameObject.activeInHierarchy)
        _recieveSound.Play();
    }
}
