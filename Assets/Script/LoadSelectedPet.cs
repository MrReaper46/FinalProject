using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadSelectedPet : MonoBehaviour
{
    public GameObject[] PetPrefabs;
    public Transform SpawnPosition;
    public TMP_Text PetName;
    public RuntimeAnimatorController Animator;
    
    private void Start()
    {
        LoadPet();
    }

    private void LoadPet()
    {
        //Create Pet
        int selectedPet = PlayerPrefs.GetInt("SelectedPet");
        GameObject prefabs = PetPrefabs[selectedPet];
        GameObject clone = Instantiate(prefabs, SpawnPosition.position, Quaternion.identity, GameObject.Find("Pet").transform);
        PetName.text = prefabs.name;

        //Add Component
        clone.AddComponent<Rigidbody>();
        clone.AddComponent<CapsuleCollider>();

        //Set Rigidbody
        var cloneRb = clone.GetComponent<Rigidbody>();
        cloneRb.freezeRotation = true;

        //Set Collider
        var cloneCollider = clone.GetComponent<CapsuleCollider>();
        cloneCollider.center = new Vector3(0, 1, 0);
        cloneCollider.height = 2;
        cloneCollider.radius = 0.45f;

        //Set Animator
        string PetPath;
        PetPath = $"Forest Animals/{PetName.text}/3D/{PetName.text} Default";
        Animator = Resources.Load(PetPath) as RuntimeAnimatorController;
        var cloneAnimator = clone.GetComponent<Animator>();
        cloneAnimator.runtimeAnimatorController = Animator;
    }
}
