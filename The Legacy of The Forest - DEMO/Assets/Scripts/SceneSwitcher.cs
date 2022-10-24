using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public Animator animator;

    private int sceneToLoad;

    public void playGame()
    {
        sceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
