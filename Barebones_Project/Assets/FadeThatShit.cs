using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeThatShit : MonoBehaviour {
  [SerializeField] private Animator darkness;
  [SerializeField] private Animator text;
  [SerializeField] private Animator quitText;
  [SerializeField] private Animator restartText;

  public void ThisGameHasEndedYouDontHaveToGoHomeButYouCantStayHereWellIGuessYouCanSinceThereIsARestartButton () {
    darkness.SetBool("GameEnd", true);
    StartCoroutine("TextFade");
  }

  private IEnumerator TextFade () {
    yield return new WaitForSeconds(5);
    text.SetBool("TextGo", true);

    yield return new WaitForSeconds(2);
    quitText.SetBool("TextGo", true);
    restartText.SetBool("TextGo", true);
  }
}
