using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PetSelect : MonoBehaviour
{
    public GameObject[] Pets;
    public int SelectedPet = 0;

    private static PetSelect instance;
    public static PetSelect Instance
    {
        get { return instance; }
    }

    public void Start()
    {
        instance = this;
        LeanTween.rotateAround(this.gameObject, Vector3.up, 360, 10.0f).setLoopClamp();
    }

    public void NextPet()
    {
        Pets[SelectedPet].SetActive(false);
        SelectedPet = (SelectedPet + 1) % Pets.Length;
        Pets[SelectedPet].SetActive(true);
    }

    public void PreviousPet()
    {
        Pets[SelectedPet].SetActive(false);
        SelectedPet--;
        if (SelectedPet < 0)
        {
            SelectedPet += Pets.Length;
        }
        Pets[SelectedPet].SetActive(true);
    }
}
