using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndPopup : MonoBehaviour
{
    public GameObject popup;
    public CanvasGroup background;

    public TextMeshProUGUI durationText;

    public void ShowEndPopup()
    {
        StartCoroutine(ShowBackground());
    }

    private IEnumerator ShowBackground()
    {
        yield return new WaitForSeconds(3f);
        while(background.alpha < 1)
        {
            background.alpha += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        popup.SetActive(true);
        durationText.text = string.Format("{0:D2}:{1:D2}", (int)GameManager.timeSinceGameStart/60, (int)GameManager.timeSinceGameStart%60);       
    }

    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
