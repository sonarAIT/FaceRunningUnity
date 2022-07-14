using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WindowSizeScript : MonoBehaviour
{
    Tuple<int, int>[] windowSizes = {
        new Tuple<int, int>(1125, 750),
        new Tuple<int, int>(1500, 1000),
        new Tuple<int, int>(2250, 1500),
        new Tuple<int, int>(3000, 2000)
    };

    public void ChangeWindowSize(int idx) {
        Screen.SetResolution(windowSizes[idx].Item1, windowSizes[idx].Item2, FullScreenMode.Windowed, 60);
    }
}
