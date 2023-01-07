using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private VisualElement rootContainer;
    private VisualElement mainMenuContainer;
    private VisualElement quitConfirmationModal;
    private VisualElement settingsModal;

    private Button buttonStart;
    private Button buttonSettings;
    private Button buttonExit;
    private Button buttonYes;
    private Button buttonNo;
    private Button buttonClose;

    private void Awake()
    {
        rootContainer = GetComponent<UIDocument>().rootVisualElement;
        
        mainMenuContainer = rootContainer.Q<VisualElement>("MainMenuContainer");
        quitConfirmationModal = rootContainer.Q<VisualElement>("QuitConfirmationModal");
        settingsModal = rootContainer.Q<VisualElement>("SettingsModal");

        quitConfirmationModal.style.display = DisplayStyle.None;
        settingsModal.style.display = DisplayStyle.None;
        
        buttonStart = mainMenuContainer.Q<Button>("ButtonStart");
        buttonSettings = mainMenuContainer.Q<Button>("ButtonSettings");
        buttonExit = mainMenuContainer.Q<Button>("ButtonExit");

        buttonYes = quitConfirmationModal.Q<Button>("ButtonYes");
        buttonNo = quitConfirmationModal.Q<Button>("ButtonNo");

        buttonClose = settingsModal.Q<Button>("ButtonClose");
    }

    private void OnEnable()
    {
        buttonStart.clicked += () => Debug.Log("Start");
        buttonSettings.clicked += toggleSettingsModal;
        buttonExit.clicked += toggleQuitConfirmationModal;

        buttonYes.clicked += () => QuitApplication.Quit();
        buttonNo.clicked += toggleQuitConfirmationModal;

        buttonClose.clicked += toggleSettingsModal;
    }

    private void toggleQuitConfirmationModal()
    {
        quitConfirmationModal.style.display = (quitConfirmationModal.style.display == DisplayStyle.None) ? DisplayStyle.Flex : DisplayStyle.None;
    }

    private void toggleSettingsModal()
    {
        settingsModal.style.display = (settingsModal.style.display == DisplayStyle.None) ? DisplayStyle.Flex : DisplayStyle.None;
    }
}
