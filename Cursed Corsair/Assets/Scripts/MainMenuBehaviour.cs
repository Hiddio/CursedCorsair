using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuBehaviour : MonoBehaviour
{
    [SerializeField] CameraSwitcher _cameraSwitcher;

    [SerializeField] Button _playGameButton;
    [SerializeField] Button _quitGameButton;

    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _schoonerPlayer;

    private float targetScale = 1f;
    private float scaleSpeed = 1f;

    void Start()
    {
        _playGameButton.onClick.AddListener(OnPlayGameButtonClick);
        _quitGameButton.onClick.AddListener(OnQuitGameButtonClick);
    }

    void OnPlayGameButtonClick()
    {
        _schoonerPlayer.SetActive(true);
        _mainMenu.SetActive(false);
        _cameraSwitcher.SwitchCamera(1);
    }

    void OnQuitGameButtonClick()
    {
        Application.Quit();
    }

    void Update()
    {
        CheckButtonHoverState(_playGameButton);
        CheckButtonHoverState(_quitGameButton);
    }

    void CheckButtonHoverState(Button button)
    {
        RectTransform rectTransform = button.GetComponent<RectTransform>();
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, Input.mousePosition, null, out localPoint);

        if (rectTransform.rect.Contains(localPoint))
        {
            targetScale = 1.1f;
        }
        else
        {
            targetScale = 1.0f;
        }
        button.transform.localScale = Vector3.Lerp(button.transform.localScale, new Vector3(targetScale, targetScale, 1f), Time.deltaTime * scaleSpeed);
    }
}
