using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PetManager : MonoBehaviour
{
    [SerializeField] private Transform spawnPosition;
    public Transform SpawnPosition { get => spawnPosition; set => spawnPosition = value; }
    
    [SerializeField] private GameObject[] petPrefabs;
    public GameObject[] PetPrefabs { get => petPrefabs; set => petPrefabs = value; }

    [SerializeField] private string petName;
    public string PetName { get => petName; set => petName = value; }

    [SerializeField] private RuntimeAnimatorController petAnimator;
    public RuntimeAnimatorController PetAnimator { get => petAnimator; set => petAnimator = value; }

    [SerializeField] private GameObject clonePet;
    public GameObject ClonePet { get => clonePet; set => clonePet = value; }

    [SerializeField] private Rigidbody cloneRb;
    public Rigidbody CloneRb { get => cloneRb; set => cloneRb = value; }

    [SerializeField] private CapsuleCollider cloneCollider;
    public CapsuleCollider CloneCollider { get => cloneCollider; set => cloneCollider = value; }

    [SerializeField] private Animator cloneAnimator;
    public Animator CloneAnimator { get => cloneAnimator; set => cloneAnimator = value; }

    private static PetManager instance;
    public static PetManager Instance { get => instance; set => instance = value; }

    private void Start()
    {
        instance = this;
    }
    public void LoadPet()
    {
        //Load Pet Prefabs
        PetPrefabs = new GameObject[3];
        PetPrefabs[0] = Resources.Load("Forest Animals/Bear/3D/Bear") as GameObject;
        PetPrefabs[1] = Resources.Load("Forest Animals/Moose/3D/Moose") as GameObject;
        PetPrefabs[2] = Resources.Load("Forest Animals/Deer/3D/Deer") as GameObject;

        //Set Spawn Loacation
        spawnPosition = GameObject.Find("Pet").transform;

        //Create Pet
        int selectedPet = PlayerPrefs.GetInt("SelectedPet");
        GameObject prefabs = PetPrefabs[selectedPet];
        clonePet = Instantiate(prefabs, SpawnPosition.position, Quaternion.identity, GameObject.Find("Pet").transform);
        petName = prefabs.name;

        //Add Component
        clonePet.AddComponent<Rigidbody>();
        clonePet.AddComponent<CapsuleCollider>();

        //Set Rigidbody
        cloneRb = clonePet.GetComponent<Rigidbody>();
        cloneRb.freezeRotation = true;

        //Set Collider
        cloneCollider = clonePet.GetComponent<CapsuleCollider>();
        cloneCollider.center = new Vector3(0, 1, 0);
        cloneCollider.height = 2;
        cloneCollider.radius = 0.45f;

        //Set Animator
        string PetPath;
        PetPath = $"Forest Animals/{petName}/3D/{petName} Default";
        PetAnimator = Resources.Load(PetPath) as RuntimeAnimatorController;
        cloneAnimator = clonePet.GetComponent<Animator>();
        cloneAnimator.runtimeAnimatorController = PetAnimator;

    }
}
