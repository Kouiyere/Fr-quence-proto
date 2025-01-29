using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public bool toggled = false;

    private void OnMouseDown()
    {
        toggled = !toggled;
    }
}
