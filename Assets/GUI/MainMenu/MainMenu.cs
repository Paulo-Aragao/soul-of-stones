using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    private GameObject _panelMenu;
    private GameObject _panelOptions;
    private GameObject _panelCredits;
    private Button _BT_continue;
    private Button _BT_start;
    private Button _BT_options;
    private Button _BT_credits;
    private Button _BT_quit;
    // Start is called before the first frame update
    void Start()
    {
        _BT_continue = GameObject.FindGameObjectWithTag("BTcontinue").GetComponent<Button>();
        _BT_start = GameObject.FindGameObjectWithTag("BTstart").GetComponent<Button>();
        _BT_options = GameObject.FindGameObjectWithTag("BToptions").GetComponent<Button>();
        _BT_credits = GameObject.FindGameObjectWithTag("BTcredits").GetComponent<Button>();
        _BT_quit = GameObject.FindGameObjectWithTag("BTquit").GetComponent<Button>();
        _panelMenu = GameObject.FindGameObjectWithTag("panelMenu");
        _panelOptions = GameObject.FindGameObjectWithTag("panelOptions");
        _panelOptions.SetActive(false);
        _panelCredits = GameObject.FindGameObjectWithTag("panelCredits");
        _panelCredits.SetActive(false);
        //buttom
        _BT_continue.onClick.AddListener(ContinueOnClick);
        _BT_options.onClick.AddListener(OptionsOnClick);
        _BT_credits.onClick.AddListener(CreditsOnClick);
        _BT_start.onClick.AddListener(StartOnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ContinueOnClick(){
        Debug.Log ("Continue game  !!!");
    }
    private void StartOnClick(){
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
    private void OptionsOnClick(){
        _panelOptions.SetActive(true);
        _panelCredits.SetActive(false);
    }
    private void CreditsOnClick(){
        _panelCredits.SetActive(true);
        _panelOptions.SetActive(false);
    }
    private void QuitOnClick(){
        Application.Quit();
    }
}
