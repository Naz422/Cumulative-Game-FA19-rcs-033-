using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Main_Menu;
    public GameObject Humming_bird;
    public GameObject Ml_selection;
    public GameObject computational_model;
    public GameObject panelforparenthesisLanguage;
    public GameObject matching_parenthesis;
    public GameObject learnt_items;
    public GameObject Link;
    public GameObject palindrom_language;
    public GameObject parenthesis_language;

    // Start is called before the first frame update
    void Start()
    {
        Main_Menu.SetActive(true);
    }
    //6 button main_menu

    public void MlAgents()
    {
        Ml_selection.SetActive(true);
        Main_Menu.SetActive(false);
    }
    public void computationalmodel()
    {
        computational_model.SetActive(true);
        Main_Menu.SetActive(false);
    }
    public void matchingparenthesis()
    {
        matching_parenthesis.SetActive(true);
        Main_Menu.SetActive(false);
        parenthesis_language.SetActive(false);
    }
    public void learntitems()
    {
        learnt_items.SetActive(true);
        Main_Menu.SetActive(false);

    }
    public void linkpanel()
    {
        Link.SetActive(true);

    }
    public void openniazi()
    {
        Application.OpenURL("http://www.niazilab.com");
    }
    //public void Quit()
    //{
    //  Application.Quit();
    //}
    public void Quit()
    {
        Debug.Log("quit");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
               Application.Quit();
        #elif UNITY_WEBGL
               Application.OpenURL("about:blank");
        #endif

    }
    public void Exit()
    {
        Debug.Log("quit");
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
                        Application.Quit();
        #elif UNITY_WEBGL
                        Application.OpenURL("about:blank");
        #endif

    }

    //3 buttons of ml agents
    public void Penguin()
    {
        SceneManager.LoadScene("Penguins");
    }
    public void Hummingbirds()
    {
        Humming_bird.SetActive(true);
        Main_Menu.SetActive(false);
    }


    public void backml()
    {
        Ml_selection.SetActive(false);
        Main_Menu.SetActive(true);
    }

    // humming birds
    public void Hummingagents()
    {
        SceneManager.LoadScene("Training");
    }
    public void Battlewithmlagent()
    {
        SceneManager.LoadScene("FlowerIsland");
    }


    public void backtomlagents()
    {
        Debug.Log("heloo");
        Ml_selection.SetActive(true);
        Humming_bird.SetActive(false);
    }


    // button of computational model

    public void palindromelanguageclicked()
    {
        palindrom_language.SetActive(true);
    }
    public void palindromeworld()
    {
        SceneManager.LoadScene("MiniGame");
    }
    public void computational()
    {
        computational_model.SetActive(false);
        Main_Menu.SetActive(true);
    }


    // panel for matching parenthesis
    public void parenthesislanguageclicked()
    {
        parenthesis_language.SetActive(true);
    }
    public void parenthesisworld()
    {
        SceneManager.LoadScene("Terrain");
    }
    public void parenthesisreturn()
    {
        panelforparenthesisLanguage.SetActive(false);
        Main_Menu.SetActive(true);
    }

    // for closing course panel,link panel, language panels

    public void PalindromeLanguagescross()
    {
        palindrom_language.SetActive(false);
        computational_model.SetActive(true);
    }
    public void ParenthesisLanguagecross()
    {
        parenthesis_language.SetActive(false);
        panelforparenthesisLanguage.SetActive(true);

    }

    public void crossLearntItems()
    {
        Main_Menu.SetActive(true);
        learnt_items.SetActive(false);

    }


    public void crossLink()
    {
        Link.SetActive(false);
        Main_Menu.SetActive(true);
    }
}
