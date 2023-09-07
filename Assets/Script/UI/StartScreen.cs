using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedPet", PetSelect.Instance.SelectedPet);
        SceneManager.LoadScene("GameScene");
    }
}
