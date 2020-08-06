using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class Main_menu : MonoBehaviour
{
    public GameObject mainmenu_panel;
    public GameObject hummingbird_panel;
    // Start is called before the first frame update
    void Start()
    {
        mainmenu_panel.SetActive(true);
    }
    public void Penguingame()
    {
        SceneManager.LoadScene("Penguins");
    }
    public void Hummingbirdmenu()
    {
        hummingbird_panel.SetActive(true);
        mainmenu_panel.SetActive(false);
    }
    public void MlAgent()
    {
        SceneManager.LoadScene("Training");
    }
    public void Battlewithmlagent()
    {
        SceneManager.LoadScene("FlowerIsland");
    }
    public void back()
    {
        mainmenu_panel.SetActive(true);
        hummingbird_panel.SetActive(false);



    }



}