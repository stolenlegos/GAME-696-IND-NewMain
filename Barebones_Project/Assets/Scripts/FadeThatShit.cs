using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeThatShit : MonoBehaviour {
  [SerializeField] private Animator darkness;
  [SerializeField] private Animator text;
  [SerializeField] private Animator quitText;

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
  }

  void Update () {
    if (Input.GetKeyDown(KeyCode.Escape) && gameOverManGameOver) {
      Application.Quit();
    }
  }
}
