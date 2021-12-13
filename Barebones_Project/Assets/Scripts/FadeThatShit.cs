using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeThatShit : MonoBehaviour {
  [SerializeField] private Animator darkness;
  [SerializeField] private Animator text;
  [SerializeField] private Animator quitText;
  [SerializeField] private Animator restartText;
  private bool gameOverManGameOver;

  public void ThisGameHasEndedYouDontHaveToGoHomeButYouCantStayHereWellIGuessYouCanSinceThereIsARestartButton () {
    darkness.SetBool("GameEnd", true);
    StartCoroutine("TextFade");
    gameOverManGameOver = true;
  }

  private IEnumerator TextFade () {
    yield return new WaitForSeconds(5);
    text.SetBool("TextGo", true);

    yield return new WaitForSeconds(2);
    quitText.SetBool("TextGo", true);
    restartText.SetBool("TextGo", true);
  }

  void Update () {
    if (Input.GetKeyDown(KeyCode.Escape) && gameOverManGameOver) {
      Application.Quit();
    } else if (Input.GetKeyDown(KeyCode.R) && gameOverManGameOver) {
      Scene scene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(scene.name);
    }
  }
}
