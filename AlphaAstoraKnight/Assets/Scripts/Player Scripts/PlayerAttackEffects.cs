using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffects : MonoBehaviour
{
    [Header("Attack FX")]
    public List<GameObject> spawnFx;
    public List<GameObject> prefabFx;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GroundImpact()
    {
        Instantiate(prefabFx[0], spawnFx[0].transform.position, Quaternion.identity);
    }

    void Kick()
    {
        Instantiate(prefabFx[1], spawnFx[1].transform.position, Quaternion.identity);
    }

    void FireTornado()
    {
        Instantiate(prefabFx[2], spawnFx[2].transform.position, Quaternion.identity);
    }

    void FireShield()
    {
        GameObject fireObject = Instantiate(prefabFx[3], spawnFx[3].transform.position, Quaternion.identity) as GameObject;

        fireObject.transform.SetParent(transform);
    }

    void Heal()
    {
        Vector3 temporalPosition = transform.position;
        temporalPosition.y += 2.0f;

        GameObject healObject = Instantiate(prefabFx[4], temporalPosition, Quaternion.identity);

        healObject.transform.SetParent(transform);
    }

    void ThunderAttack()
    {
        for(int i = 0;i<8;i++)
        {
            Vector3 thunderPosition = Vector3.zero;

            if(i == 0)
            {
                thunderPosition = new Vector3(transform.position.x - 4.0f, transform.position.y + 2.0f,transform.position.z);

            }else if (i == 1)
            {
                thunderPosition = new Vector3(transform.position.x + 4.0f, transform.position.y + 2.0f, transform.position.z);
            }
            else if (i == 2)
            {
                thunderPosition = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z - 4.0f);
            }
            else if (i == 3)
            {
                thunderPosition = new Vector3(transform.position.x, transform.position.y + 2.0f, transform.position.z + 4.0f);
            }
            else if (i == 4)
            {
                thunderPosition = new Vector3(transform.position.x + 2.5f, transform.position.y + 2.0f, transform.position.z + 2.5f);
            }
            else if (i == 5)
            {
                thunderPosition = new Vector3(transform.position.x - 2.5f, transform.position.y + 2.0f, transform.position.z + 2.5f);
            }
            else if (i == 6)
            {
                thunderPosition = new Vector3(transform.position.x - 2.5f, transform.position.y + 2.0f, transform.position.z - 2.5f);
            }
            else if (i == 7)
            {
                thunderPosition = new Vector3(transform.position.x + 2.5f, transform.position.y + 2.0f, transform.position.z + 2.5f);
            }

            Instantiate(prefabFx[5],thunderPosition,Quaternion.identity);
        }
    }
}
