using System;
using UnityEngine;
using UnityEngine.Events;

public sealed class CardCollector : MonoBehaviour
{
    public event Action OnCollected;

    private CardSelector _firstCard;
    private CardSelector _secondCard;

    public void Open(CardSelector card)
    {
        if (_firstCard == null)
        {
            _firstCard = card;
        }
        else
        {
            _secondCard = card;
            Invoke(nameof(TryCollect), 0.1f);
        }       
    }
    private void TryCollect()
    {
        var firstSprite = _firstCard.GetFrontSide();
        var secondSprite = _secondCard.GetFrontSide();

        if (_firstCard.transform.position == _secondCard.transform.position)
            return;

        if(firstSprite == secondSprite)
        {
            Destroy(_firstCard.gameObject);
            Destroy(_secondCard.gameObject);
            OnCollected.Invoke();
        }
        else
        {
            _firstCard.TurnBack(true);
            _secondCard.TurnBack(true);
            _firstCard = null;
            _secondCard = null;
        }
    }
}
