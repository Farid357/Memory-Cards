using UnityEngine;

public sealed class DifficultySelector : MonoBehaviour
{
    [SerializeField] private LevelData _level;

    public void SelectTheme(ThemeData theme)
    {
        _level.SetSprites(theme.Sprites);
    }
    public void SelectSize(int xCount)
    {
        var yCount = 2;
        _level.SetSize(xCount, yCount);
    }
}
