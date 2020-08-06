using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit_Code: MonoBehaviour
{
 public void QuiteApp()
    {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_STANDALONE
                               Application.Quit();
            #elif UNITY_WEBGL
                              Application.OpenURL("about:blank");
            #endif

    }
    

   
}
