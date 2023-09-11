using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    private static SaveData current;
    public static SaveData Current
    {
        get
        {
            if(current == null)
            {
                current = new SaveData();
            }
            return current;
        }
    }

    public PetProfile profile;
    public int Hunger;
    public int Happiness;
}
