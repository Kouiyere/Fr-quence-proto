using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorTextureDefault;
    public Texture2D hoverCursor;

    void Start()
    {
        Cursor.SetCursor(cursorTextureDefault, Vector2.zero, CursorMode.Auto);
    }

    public void SetCursorClick(bool isHover)
    {
        if(isHover)
        {
            Cursor.SetCursor(hoverCursor, Vector2.zero, CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(cursorTextureDefault, Vector2.zero, CursorMode.Auto);
        }
    }
}
