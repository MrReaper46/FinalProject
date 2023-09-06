using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoadSelectedPet : MonoBehaviour
{
    private GameObject[] petPrefabs;
    public GameObject[] PetPrefabs { get => petPrefabs; set => petPrefabs = value; }

    private Transform spawnPosition;
    public Transform SpawnPosition { get => spawnPosition; set => spawnPosition = value; }

    private RuntimeAnimatorController animator;
    public RuntimeAnimatorController Animator { get => animator; set => animator = value; }

    private static LoadSelectedPet instance;
    public static LoadSelectedPet Instance { get => instance; set => instance = value; }

    private void Start()
    {
        instance = this;
        LoadPet();
    }
    public void LoadPet()
    {
        //Create Pet
        int selectedPet = PlayerPrefs.GetInt("SelectedPet");
        GameObject prefabs = PetPrefabs[selectedPet];
        GameObject clone = Instantiate(prefabs, SpawnPosition.position, Quaternion.identity, GameObject.Find("Pet").transform);
        string petName = prefabs.name;

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
        PetPath = $"Forest Animals/{petName}/3D/{petName} Default";
        Animator = Resources.Load(PetPath) as RuntimeAnimatorController;
        var cloneAnimator = clone.GetComponent<Animator>();
        cloneAnimator.runtimeAnimatorController = Animator;
    }
}
