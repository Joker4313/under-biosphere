using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorLogic : MonoBehaviour
{

    public GameObject AxePrefab;//以斧子为例子
    private float t1, t2;
   
    // Start is called before the first frame update
    void Start()
    {
        t1 = 0;
        GameObject node = Object.Instantiate(AxePrefab, null);
        node.transform.position = Vector3.zero;
        node.transform.localEulerAngles = Vector3.zero;//创建基本物体
    }

    // Update is called once per frame
    void Update()
    {
    
        t2 = Time.realtimeSinceStartup;
        if(t2-t1>=1)//1将替换成9999999999999999使得只创建一次随机物体。
        {
            Debug.Log("111");
            TestFire();

        }
        
        
       
            
       
    }
    private void TestFire()
    {
        GameObject node= Object.Instantiate(AxePrefab,null);//随机生成物体（预制体，生成的位置，方向）。Instantiate(AxePrefab, null);
      
        float z = Random.Range(-50f, 50f);//规定z轴方向上的范围
                                  
        float x = Random.Range(-50f, 50f);//规定x轴方向上的范围
        //根据自己场景的实际情况去规定范围
        AxePrefab.transform.position = new Vector3(x, 0, z);
        t1= Time.realtimeSinceStartup;
    }
 
}
