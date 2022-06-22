using UnityEngine;

[RequireComponent(typeof(Animation), typeof(BoxCollider2D), typeof(SpriteRenderer))]

public sealed class CardSelector : MonoBehaviour
{
    [SerializeField] private Sprite _backSide;
    [SerializeField] private CardCollector _collector;

    private Animation _animation;
    private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _frontSide;

    private BoxCollider2D _BoxCollider;
    private const string FirstAnimation = "ToBack";
    private const string SecondAnimation = "ToFront";
    private bool _isBackSide = true;

    private void Awake()
    {
        _animation = GetComponent<Animation>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _BoxCollider = GetComponent<BoxCollider2D>();
    }
    private void OnMouseDown()
    {
        if(!PauseManager.Instance.IsPaused)
        Turn();
    }
    public void TurnBack(bool use)
    {
        PlayAnimation();
        SetEnableCollider(use);
    }
    public Sprite GetFrontSide()
    {
        return _frontSide;
    }

    public void SetFrontSide(Sprite frontSide)
    {
        _frontSide = frontSide;
    }
    private void SetEnableCollider(bool enable)
    {
        _BoxCollider.enabled = enable;
    }

    private void PlayAnimation()
    {
        _isBackSide = !_isBackSide;
        _animation.Play(_isBackSide ? FirstAnimation : SecondAnimation);
        _spriteRenderer.sprite = _isBackSide ? _backSide : _frontSide;
    }
    private void Turn()
    {
        PlayAnimation();
        SetEnableCollider(false);
        _collector.Open(this);
    }

}
