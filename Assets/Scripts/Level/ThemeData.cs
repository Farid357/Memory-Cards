using UnityEngine;

[CreateAssetMenu(fileName = "Theme", menuName = "Theme")]
public sealed class ThemeData : ScriptableObject
{
    public Sprite[] Sprites => _sprites;
    [SerializeField] private Sprite[] _sprites;

}
