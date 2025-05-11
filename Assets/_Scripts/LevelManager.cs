using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject GamePlayPanel;
    public GameObject LevelPanal;


    public void BackBtn()
    {
        LevelPanal.SetActive(false);
        GamePlayPanel.SetActive(true);
    }
  

    public void LoadLevel(int levelNumber)
    {
        string sceneName = "level "+(levelNumber+1);
        Debug.Log("Scene to load : " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}