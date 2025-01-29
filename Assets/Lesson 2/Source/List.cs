using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class List : MonoBehaviour
{
    [SerializeField] private string _value;

    [SerializeField] private List<string> _list;

    [ContextMenu("Print")]
    private void Print()
    {
        _list.Sort();
        _list.Add(_value);
        _list.Remove(_value);
        string msg = "List: ";
        for (int i = 0; i < _list.Count; ++i)
            msg += $"\n{_list[i]}";
        Debug.Log(msg);
    }

    [ContextMenu("Clear List")]
    private void ClearList()
    {
        _list.Clear();
        Debug.Log("List cleared.");
    }
}
