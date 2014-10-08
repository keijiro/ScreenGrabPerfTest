using UnityEngine;
using System.Collections;

public class SwitchClearFlag : MonoBehaviour
{
    bool doClear = false;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            doClear = !doClear;
            camera.clearFlags = doClear ? CameraClearFlags.SolidColor : CameraClearFlags.Nothing;
        }
    }

    void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 500, 100), "Tap screen to switch the clear flags.\nCurrent: " + camera.clearFlags);
    }
}
