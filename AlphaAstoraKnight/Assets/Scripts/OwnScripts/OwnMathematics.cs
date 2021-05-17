using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnMathematics : MonoBehaviour
{
    public static float Square(float value)
    {
        return value * value;
    }


    public static float Distance(Coordinates vector1,Coordinates  vector2)
    {
        float distance = Square(vector1.x - vector2.x) + Square(vector1.y - vector2.y) + Square(vector1.z - vector2.z);

        return Mathf.Sqrt(distance);
    }

    public static Coordinates Normal(Coordinates vector)
    {
        float length = Distance(new Coordinates(0,0,0),vector);

        vector.x /= length;
        vector.y /= length;
        vector.z /= length;

        return vector;
    }


}
