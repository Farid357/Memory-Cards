using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Collections.Generic;

public sealed class ButtonOutline : MonoBehaviour
{

    [SerializeField] private Vector2 _effectDistance;
    [SerializeField] private List<Outline> _outlines = new List<Outline>();
    [SerializeField] private string _key = "msd";

    private void Start()
    {
        int index = PlayerPrefs.GetInt(_key, 0);
        _outlines[index].effectDistance = _effectDistance;
        Clear(_outlines.Where(w => w != _outlines[index]));
        Save(_outlines.IndexOf(_outlines[index]));
    }

    private void Clear(IEnumerable<Outline> outlines)
    {
        foreach (var outline in outlines)
        {
            outline.effectDistance = Vector2.zero;
        }
    }

    public void OnChoise(Outline outline)
    {
        outline.effectDistance = _effectDistance;
        Save(_outlines.IndexOf(outline));
        Clear(_outlines.Where(i => i != outline));
    }
    private void Save(int index)
    {
        PlayerPrefs.DeleteKey(_key);
        PlayerPrefs.SetInt(_key, index);
    }
}

