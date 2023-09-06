using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.SetInt("SelectedPet", PetSelect.Instance.SelectedPet);
        SceneManager.LoadScene("GameScene");
    }
}
