using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISupporter : MonoBehaviour
{
    void Start()
    {
        DebugUIBuilder.instance.Show();
        /*DebugUIBuilder.instance.AddLabel("ABCD");
        DebugUIBuilder.instance.RemoveLabel(0);
        DebugUIBuilder.instance.Show();*/
    }

    void Update()
    {
        
    }

    public void itemNotice(string itemName)
    {
        while (DebugUIBuilder.instance.rectNum() > 0)
            DebugUIBuilder.instance.RemoveLabel(0);
        DebugUIBuilder.instance.AddLabel(itemName);
        DebugUIBuilder.instance.Show();
    }

    public void closeNotice()
    {
        DebugUIBuilder.instance.RemoveLabel(0);
    }
}
