using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloGenerator : MonoBehaviour
{
    public Vector3[] haloP = new Vector3[18];
    public GameObject halo;
    public GameObject halos;
    public float duration = 5;
    public int total=0;
    public int[] location=new int[18];
    public static HaloGenerator instance;

    private void Awake()
    {
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        /*if (GameManager.instance.currentState == state.inGame&&total < 18)
        {
           if (duration > 0)
           {
            duration -= Time.deltaTime;
            
           }
           else
           {
            int x = Random.Range(0,18);
            while (location[x] == 1)
            {
              x = Random.Range(0, 18);
            }
            Vector3 p = haloP[x];
            GameObject temp;
            temp= Instantiate(halo, p, Quaternion.identity);
            EventAdder.AddEvent(temp, "HaloManager", new string[1] { "index" }, new object[1] { x });
            temp.AddComponent<Rigidbody>();
            temp.name = "halo";
            temp.transform.parent = halos.transform;
            location[x] = 1;
            total = total + 1;
            duration = 5;
            
           
            }
        }*/
        
    }

   public void init()
    {
        for (int i = 0; i < 18; i++)
        {
            location[i] = 0;
        }
        total = 0;
        duration = 5;
    }
}
