using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SelectionNiveau : MonoBehaviour
{
    public GameObject loadingScreen, loadingIcon;
    public Text loadingText;
    public Text scoreNiveau1, scoreNiveau2;
    // Start is called before the first frame update
    void Start()
    {
        scoreNiveau1.text = "Score plus récent: " + PlayerPrefs.GetInt("ScoreNiveau1",0)+"%";
        scoreNiveau2.text = "Score plus récent: " + PlayerPrefs.GetInt("ScoreNiveau2",0)+"%";
    }

    // Update is called once per frame
    void Update(){ }

    public void CommencerNiveau1() {
        StartCoroutine(LoadStart("Level 1"));
    }

    public void CommencerNiveau2()
    {
        StartCoroutine(LoadStart("Level 2"));
    }

    public IEnumerator LoadStart(string niveauChoisi)
    {
        loadingScreen.SetActive(true);

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(niveauChoisi);

        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {
            if (asyncLoad.progress >= .9f)
            {
                loadingText.text = "Appuire sur une touche pour continuer";
                loadingIcon.SetActive(false);

                if (Input.anyKeyDown)
                {
                    asyncLoad.allowSceneActivation = true;

                    Time.timeScale = 1f;
                }
            }

            yield return null;
        }
    }
}
