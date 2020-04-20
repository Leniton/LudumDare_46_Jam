using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class AllScenesManager : MonoBehaviour
{

    public static AllScenesManager manager;

    void Awake()
    {
        if(manager != this)
        {
            if(manager == null)
            {
                manager = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }
    }

    public void OpenScene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
