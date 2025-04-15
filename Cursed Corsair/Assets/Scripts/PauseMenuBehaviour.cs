using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenuBehaviour : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuPanel;

    [SerializeField] Button closePauseMenuButton;
    [SerializeField] Button resumeGameButton;
    [SerializeField] Button backToMenuButton;
    [SerializeField] Button quitToDesktopButton;

    private float targetScale = 1f;
    private float scaleSpeed = 10f;

    void Start()
    {
        closePauseMenuButton.onClick.AddListener(ResumeGame);
        resumeGameButton.onClick.AddListener(ResumeGame);
        backToMenuButton.onClick.AddListener(BackToMenu);
        quitToDesktopButton.onClick.AddListener(QuitToDesktop);
    }

    void Update()
    {
        CheckButtonHoverState(closePauseMenuButton);
        CheckButtonHoverState(resumeGameButton);
        CheckButtonHoverState(backToMenuButton);
        CheckButtonHoverState(quitToDesktopButton);
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

    public void ResumeGame()
    {
        pauseMenuPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        pauseMenuPanel.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void QuitToDesktop()
    {
        Application.Quit();
    }
}
