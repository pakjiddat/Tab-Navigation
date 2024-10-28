using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTab;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ReverseNavigation : MonoBehaviour
{
    /** The current game object */
    private GameObject _current;

    void Start()
    {
        /** The button click event */
        GetComponent<Button>().onClick.AddListener(() =>
        {
            var easyTabSolver = new EasyTabSolver();
            /** The previous ui object is fetched */
            var next = easyTabSolver.GetNext(_current, true);
            if (next && next.TryGetComponent(out Selectable nextSelectable))
                /** The previous ui object is selected */
                nextSelectable.Select();
        });
    }

    void Update()
    {
        /** If the currently selected item is the reverse navigation button, then function returns */
        var eventSystemCurrent = EventSystem.current.currentSelectedGameObject;
        if (eventSystemCurrent == gameObject) // gameObject is this button
            return;
        /** The current game object is set to the currently selected game object */
        _current = eventSystemCurrent;
    }
}
