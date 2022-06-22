using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName = "LevelSO")]
public sealed class LevelData : ScriptableObject
{
    public int XCount => _xCount;
    public int YCount => _yCount;

    public Sprite[] Sprites => _sprites;
    [SerializeField] private Sprite[] _sprites;

    [SerializeField, Min(0)] private int _xCount;
    [SerializeField, Range(0, 5)] private int _yCount;

    public void SetSize(int xCount, int yCount)
    {
        _xCount = xCount;
        _yCount = yCount;
    }
    public void SetSprites(Sprite[] cardSprites)
    {
        _sprites = cardSprites;
    }
}
