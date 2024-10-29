using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EasyTab;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Enter : MonoBehaviour
{
    /** The current game object */
    private GameObject _current;
    /** Indicates if dropdown is opened */
    private bool isOpen = false;
    /** The last selected dropdown */
    private CustomDropdown dropdown;

    void Start()
    {
        /** The button click event */
        GetComponent<Button>().onClick.AddListener(() =>
        {
            /** If a dropdown object has previously been selected */
            if (dropdown != null)
            {
                /** If the dropdown is not open */
                if (!isOpen)
                {
                    /** If the current object is not a dropdown */
                    if (_current.GetComponent<CustomDropdown>() != dropdown)
                    {
                        /** The current object is focused */
                        EventSystem.current.SetSelectedGameObject(_current.gameObject);
                        return;
                    }
                    /** The dropdown is opened */
                    dropdown.Show();
                    /** The dropdown is marked as open */
                    isOpen = true;

                    _current = _current.transform.Find("Dropdown List").gameObject;
                    EventSystem.current.SetSelectedGameObject(_current);

                    /** The current value of the dropdown is highlighted and checked */
                    var easyTabSolver = new EasyTabSolver();
                    /** The value of the last selected dropdown */
                    int value = dropdown.value;
                    /** The next dropdown item is fetched and selected */
                    for (int count = 0; count <= value; count++)
                    {                        
                        var next = easyTabSolver.GetNext(_current, false);
                        if (next && next.TryGetComponent(out Selectable nextSelectable))
                        {
                            nextSelectable.Select();
                            _current = nextSelectable.gameObject;
                        }
                    }
                    /** The current object is set to the last selected dropdown */
                    _current = dropdown.gameObject;
                }
                else
                {
                    /** If the dropdown is opened, then it is closed */
                    dropdown.Hide();
                    /** The dropdown is marked as closed */
                    isOpen = false;
                    /** The last selected dropdown object is focused */
                    EventSystem.current.SetSelectedGameObject(dropdown.gameObject);
                }                              
            }
            else
            {
                /** If a dropdown object has not previously received focus, then the current object is focused */
                EventSystem.current.SetSelectedGameObject(_current.gameObject);
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
        if (_current != null && _current.GetComponent<CustomDropdown>() != null && _current.GetComponent<CustomDropdown>().GetType() == typeof(CustomDropdown))
        {
            dropdown = _current.GetComponent<CustomDropdown>();
        }
    }
}
