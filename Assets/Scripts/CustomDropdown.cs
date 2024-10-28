using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomDropdown : Dropdown
{
    // Update is called once per frame
    void Update()
    {
        
    }

    protected override GameObject CreateBlocker(Canvas rootCanvas)
    {
        return null;
    }
}
