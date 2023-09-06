using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadSelectedPet : MonoBehaviour
{
    public GameObject[] PetPrefabs;
    public Transform SpawnPosition;
    public TMP_Text PetName;
    private void Start()
    {
        int selectedPet = PlayerPrefs.GetInt("SelectedPet");
        GameObject prefabs = PetPrefabs[selectedPet];
        GameObject clone = Instantiate(prefabs, SpawnPosition.position, Quaternion.identity);
        PetName.text = prefabs.name;
    }
}
