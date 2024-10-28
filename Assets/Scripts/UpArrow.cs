using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTab;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UpArrow : MonoBehaviour
{
    /** The current game object */
    private GameObject _current;
    /** The last selected dropdown */
    private CustomDropdown dropdown;

    void Start()
    {
        /** The button click event */
        GetComponent<Button>().onClick.AddListener(() =>
        {
            /** If the currently selected object is a toggle item. i.e a dropdown list item and up arrow button is clicked */
            if (_current.GetComponent<Toggle>() != null && _current.GetComponent<Toggle>().GetType() == typeof(Toggle))
            {
                /** The currently selected object is unselected. The previous toggle item will be selected */
                _current.GetComponent<Toggle>().SetIsOnWithoutNotify(false);
            }
            else
            {
                /** If the currently selected object is not a toggle item, then it is selected and the function returns */
                EventSystem.current.SetSelectedGameObject(_current.gameObject);
                return;
            }
            /** The previous toggle item is fetched and selected */
            var easyTabSolver = new EasyTabSolver();
            var next = easyTabSolver.GetNext(_current, true);
            if (next && next.TryGetComponent(out Selectable nextSelectable))
            {
                nextSelectable.Select();
                /** The current dropdown value */
                int currentIndex = dropdown.value;

                // Move to the previous item if possible
                if (currentIndex > 0)
                {
                    dropdown.value = currentIndex - 1;
                }
                else
                {
                    // Optionally, wrap around to the last item if at the start
                    dropdown.value = (dropdown.options.Count - 1); // Wrap to the last item
                }

                /** The next toggle item is checked */
                nextSelectable.GetComponent<Toggle>().SetIsOnWithoutNotify(true);
            }
        });
    }

    void Update()
    {
        /** If the currently selected item is the enter button, then function returns */
        var eventSystemCurrent = EventSystem.current.currentSelectedGameObject;
        if (eventSystemCurrent == gameObject) // gameObject is this button
            return;
        /** The current game object is set to the currently selected game object */
        _current = eventSystemCurrent;
        /** If the current game object is a drop down, then its value is saved to variable */
        if (_current !=null && _current.GetComponent<CustomDropdown>() != null && _current.GetComponent<CustomDropdown>().GetType() == typeof(CustomDropdown))
        {
            dropdown = _current.GetComponent<CustomDropdown>();
        }
    }
}
