using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    void Start()
    {
        //esc押すとカーソルロックが解除される
        Cursor.lockState = CursorLockMode.Locked;
    }
}
