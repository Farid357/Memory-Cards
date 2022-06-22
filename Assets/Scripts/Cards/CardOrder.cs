using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public sealed class CardOrder : MonoBehaviour
{
    [SerializeField] private CardGenerator _generator;
    [SerializeField] private LevelData _theme;
    private readonly List<int> _indices = new();
    private WaitForSeconds _wait;

    private void OnEnable() => _generator.OnGenerate += Reorder;

    private void OnDisable() => _generator.OnGenerate -= Reorder;

    private void Start()
    {
        _wait = new WaitForSeconds(1.5f);
        StartCoroutine(ShowCards());
    }
    private void Reorder(CardSelector[,] cards)
    {
        SetSprites(cards);
        var indices = GetIndices();

        for (int i = 0; i < _theme.Sprites.Length - 1; i++)
        {
            var randomIndex = Random.Range(0, indices.Count);
            var currentCardSprite = cards[i, 0].GetFrontSide();
            var replacementCard = cards[randomIndex, 1];
            cards[i, 0].SetFrontSide(replacementCard.GetFrontSide());
            replacementCard.SetFrontSide(currentCardSprite);
            indices.Remove(randomIndex);
        }
    }
    private void SetSprites(CardSelector[,] cards)
    {
        for (int x = 0; x < cards.GetLength(0); x++)
        {
            cards[x, 0].SetFrontSide(_theme.Sprites[x]);
        }
        for (int i = 0; i < cards.GetLength(0); i++)
        {
            cards[i, 1].SetFrontSide(_theme.Sprites[i]);
        }
       
    }
    private List<int> GetIndices()
    {
        for (int i = 0; i < _theme.Sprites.Length; i++)
        {
            _indices.Add(i);
        }
        return _indices;
    }
    private IEnumerator ShowCards()
    {
        var cards = FindObjectsOfType<CardSelector>();
        Show(cards, false);      
        yield return _wait;
        Show(cards, true);
    }
    private void Show(CardSelector[] cards, bool use)
    {
        foreach (var card in cards)
        {
            card.TurnBack(use);
        }
    }
}
