using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePetStats
{
    private string petName;
    private int petLevel;
    private BaseStats petStats;

    private int decaySpd;
    private int hunger;
    private int happiness;

    public int DecaySpd
    {
        get { return decaySpd; }
        set { decaySpd = value; }
    }
    public int Hunger
    {
        get { return hunger; }
        set { hunger = value; }
    }
    public int Happiness
    {
        get { return happiness; }
        set { happiness = value; }
    }

}
