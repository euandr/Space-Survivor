using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public GameObject creditsPanel;
    public Image muteIcon;
    public Sprite muteSprite;
    public Sprite unmuteSprite;
    public GameObject AudioBk;
    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }



    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenMenu()
    {
         SceneManager.LoadScene("Menu");;
    }

    public void Mute()
    {
        if (AudioBk.activeSelf)
        {
            // está ativo
            AudioBk.SetActive(false);
            muteIcon.sprite = unmuteSprite;
        }
        else
        {
            // está desativado
            AudioBk.SetActive(true);
            muteIcon.sprite = muteSprite;
        }
       
    }
}