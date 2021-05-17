using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coordinates
{
    [Header("Coordinates Attributes")]
    public float x;
    public float y;
    public float z;

   public Coordinates(int x,int y)
    {
        this.x = x;
        this.y = y;
        z = -1;
    }

    public Coordinates(int x,int y,int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public Coordinates(Vector3 vector)
    {
        this.x = vector.x;
        this.y = vector.y;
        this.z = vector.z;
    }

    public Vector3 ConvertToVector()
    {
        return new Vector3(x,y,z);
    }


}
