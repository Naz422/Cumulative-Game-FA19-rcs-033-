using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Splash : MonoBehaviour
{
    // Start is called before the first frame update
    public static int scene;
    void Start()
    {
        if(scene == 0)
        {
            StartCoroutine(splashes());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator splashes()
    {
        yield return new WaitForSeconds(5);
        scene = 1;
        SceneManager.LoadScene(1);
    }
}
