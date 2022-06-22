using System;
using UnityEngine;

public sealed class CardGenerator : MonoBehaviour
{
    public event Action<CardSelector[,]> OnGenerate;

    [SerializeField] private CardSelector _cardPrefab;
    [SerializeField] private LevelData _level;
    private CardSelector[,] _cards;

    private void Start()
    {
        Vector2 offset = _cardPrefab.GetComponent<SpriteRenderer>().bounds.size + new Vector3(0.5f, 0.3f);
        Generate(offset.x, offset.y);
    }
    [ExecuteInEditMode]
    private void Generate(float xOffset, float yOffset)
    {
        _cards = new CardSelector[_level.XCount, _level.YCount];
        var startPositionX = transform.position.x;
        var startPositionY = transform.position.y;

        for (int x = 0; x < _level.XCount; x++)
        {
            for (int y = 0; y < _level.YCount; y++)
            {
                var offset = new Vector2(startPositionX + (x * xOffset), startPositionY + (y * yOffset));
                var newCard = Instantiate(_cardPrefab, offset, Quaternion.identity);
                _cards[x, y] = newCard;
            }
        }
        OnGenerate.Invoke(_cards);
    }
}
