using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _transitionDelay = 5f;
    [SerializeField] private InputParser _inputParser;
    public void LevelDone()
    {
        Debug.Log("Finished");
        Invoke(nameof(BackToMenu), _transitionDelay);
        
    }

    public void PlayerDeath()
    {
        Debug.Log("You Died");
        Invoke(nameof(BackToMenu), _transitionDelay);
    }

    private void BackToMenu()
    {
        _inputParser._playerControlsActions.Disable();
        Debug.Log("BackToMenu");
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
}
