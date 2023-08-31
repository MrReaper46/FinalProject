using UnityEngine;
using System.Collections;

public class BaseStats
{
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
