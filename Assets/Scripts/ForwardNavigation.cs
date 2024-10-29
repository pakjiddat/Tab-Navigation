using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTab;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ForwardNavigation : MonoBehaviour
{
    /** The current game object */
    private GameObject _current;

    void Start()
    {
        /** The button click event */
        GetComponent<Button>().onClick.AddListener(() =>
        {
            var easyTabSolver = new EasyTabSolver();
            /** The next ui object is fetched */
            var next = easyTabSolver.GetNext(_current, false);
            if (next && next.TryGetComponent(out Selectable nextSelectable))
                /** The next ui object is selected */
                nextSelectable.Select();
        });
    }

    void Update()
    {
        /** If the currently selected item is the forward navigation button, then function returns */
        var eventSystemCurrent = EventSystem.current.currentSelectedGameObject;
        if (eventSystemCurrent == gameObject) // gameObject is this button
            return;
        /** The current game object is set to the currently selected game object */
        _current = eventSystemCurrent;
    }
}
