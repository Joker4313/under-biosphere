using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorLogic : MonoBehaviour
{

    public GameObject AxePrefab;//�Ը���Ϊ����
    private float t1, t2;
   
    // Start is called before the first frame update
    void Start()
    {
        t1 = 0;
        GameObject node = Object.Instantiate(AxePrefab, null);
        node.transform.position = Vector3.zero;
        node.transform.localEulerAngles = Vector3.zero;//������������
    }

    // Update is called once per frame
    void Update()
    {
    
        t2 = Time.realtimeSinceStartup;
        if(t2-t1>=1)//1���滻��9999999999999999ʹ��ֻ����һ��������塣
        {
            Debug.Log("111");
            TestFire();

        }
        
        
       
            
       
    }
    private void TestFire()
    {
        GameObject node= Object.Instantiate(AxePrefab,null);//����������壨Ԥ���壬���ɵ�λ�ã����򣩡�Instantiate(AxePrefab, null);
      
        float z = Random.Range(-50f, 50f);//�涨z�᷽���ϵķ�Χ
                                  
        float x = Random.Range(-50f, 50f);//�涨x�᷽���ϵķ�Χ
        //�����Լ�������ʵ�����ȥ�涨��Χ
        AxePrefab.transform.position = new Vector3(x, 0, z);
        t1= Time.realtimeSinceStartup;
    }
 
}
