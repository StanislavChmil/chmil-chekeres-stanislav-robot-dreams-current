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
        string msg = "List: ";
        for (int i = 0; i < _list.Count; ++i)
            msg += $"\n{_list[i]}";
        Debug.Log(msg);
    }

    [ContextMenu("Add")]
    private void Add()
    {
        _list.Add(_value);
    }

    [ContextMenu("Remove")]
    private void Remove()
    {
        if (_list.Contains(_value))
        {
            _list.Remove(_value);
            Debug.Log($"Removed: {_value}");
        }
        else
        {
            Debug.Log($"Item '{_value}' not found in the list.");
        }
    }

    [ContextMenu("Sort")]
    private void Sort()
    {
        _list.Sort();
        Debug.Log("List sorted.");
    }

    [ContextMenu("Clear List")]
    private void ClearList()
    {
        _list.Clear();
        Debug.Log("List cleared.");
    }
}
