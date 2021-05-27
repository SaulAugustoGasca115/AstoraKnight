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


    public static float DotProduct(Coordinates vector1,Coordinates vector2)
    {
        return vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z;
    }

    public static float Angle(Coordinates vector1,Coordinates vector2)
    {
        float dotProduct = DotProduct(vector1, vector2) / Distance(new Coordinates(0, 0, 0), vector1) * Distance(new Coordinates(0, 0, 0), vector2);

        return Mathf.Acos(dotProduct);
    }


    public static Coordinates OwnRotation(Coordinates vector,float angle,bool clockwise)
    {
        if(clockwise)
        {
            angle = 2 * Mathf.PI - angle;
        }

        float xValue = vector.x * Mathf.Cos(angle) - vector.y * Mathf.Sin(angle);

        float yValue = vector.x * Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);

        return new Coordinates(xValue, yValue, 0.0f);
    }


    public static Coordinates CrossProduct(Coordinates vector1,Coordinates vector2)
    {
        float xCrossValue = vector1.y * vector2.z - vector1.z * vector2.y;
        float yCrossValue = vector1.z * vector2.x - vector1.x * vector2.z;
        float zCrossValue = vector1.x * vector2.y - vector1.y * vector2.x;

        return new Coordinates(xCrossValue,yCrossValue,zCrossValue);
    }

}
