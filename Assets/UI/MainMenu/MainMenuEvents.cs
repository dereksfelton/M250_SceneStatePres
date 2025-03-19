using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    private UIDocument uiMenu;
    private Button btnNewGame;
    private Button btnQuitGame;
    private List<Button> allButtons;
    
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        uiMenu = GetComponent<UIDocument>();

        // Query my UI document, starting at the root (top) element
        // looking for a Button named "NewGameButton"
        btnNewGame = uiMenu.rootVisualElement.Query<Button>("NewGameButton");

        // Register a callback method to handle when New Game is clicked
        btnNewGame.RegisterCallback<ClickEvent>(OnNewGameClick);

        // do same for Quit Button
        btnQuitGame = uiMenu.rootVisualElement.Query<Button>("QuitGameButton");
        btnQuitGame.RegisterCallback<ClickEvent>(OnQuitGameClick);

        // find and register a callback for ALL buttons
        allButtons = uiMenu.rootVisualElement.Query<Button>().ToList();
        foreach(var button in allButtons)
        {
            button.RegisterCallback<ClickEvent>(OnAnyButtonClick);
        }
    }

    void OnDisable()
    {
        // Unregister all of our callbacks
        btnNewGame.UnregisterCallback<ClickEvent>(OnNewGameClick);
        btnQuitGame.UnregisterCallback<ClickEvent>(OnQuitGameClick);
        foreach(var button in allButtons)
        {
            button.UnregisterCallback<ClickEvent>(OnAnyButtonClick);
        }
    }

    private void OnNewGameClick(ClickEvent evt)
    {
        SceneManager.LoadScene("Level01");
    }

    private void OnQuitGameClick(ClickEvent evt)
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    private void OnAnyButtonClick(ClickEvent evt)
    {
        audioSource.Play();
    }
}
