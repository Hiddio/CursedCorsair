using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    [SerializeField] GameObject _mainMenu;
    [SerializeField] GameObject _pauseMenu;

    [SerializeField] List<GameObject> _remainingEnemies;

    [SerializeField] GameObject _winScreen;
    void Start()
    {
        _mainMenu.SetActive(true);
    }
    void Update()
    {
        PauseGameCheck();
        EnemyLifeCheck();
        WinGameCheck();
    }

    void PauseGameCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !_mainMenu.activeSelf)
        {
            //Switches between an on and off pause menu
            _pauseMenu.SetActive(!_pauseMenu.activeSelf);
        }
    }
    void EnemyLifeCheck()
    {
        // Check if any objects in the list have been destroyed
        for (int i = _remainingEnemies.Count - 1; i >= 0; i--)
        {
            if (_remainingEnemies[i] == null)
            {
                _remainingEnemies.RemoveAt(i);
            }
        }
    }
    void WinGameCheck()
    {
        if(_remainingEnemies.Count == 0)
        {
            _winScreen.SetActive(true);
        }
    }
}
