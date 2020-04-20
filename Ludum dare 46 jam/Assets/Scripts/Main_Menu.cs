using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Menu : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            AllScenesManager.manager.OpenScene(1);
        }
    }
}
