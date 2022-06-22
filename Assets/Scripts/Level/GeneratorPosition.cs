using UnityEngine;

public sealed class GeneratorPosition : MonoBehaviour
{
    [SerializeField] private LevelData _level;

    private void Awake()
    {
        if (_level.XCount < 6)
            transform.position += new Vector3(1.5f, 0);
    }
}
