using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSort: MonoBehaviour
{
    public void ListSort()
    {
        GameManager.instance.score = Sort(GameManager.instance.score);
    }
    SimpleList<int> Sort(SimpleList<int> list)
    {
        int tmp;
        bool isSorted;
        for(int i = 0; i < list.length - 1; ++i)
        {
            isSorted = true;
            for(int j =0;j<list.length - i - 1; ++j)
            {
                if (list.GetNodeValueAtPosicion(j) < list.GetNodeValueAtPosicion(j + 1))
                {
                    tmp = list.GetNodeValueAtPosicion(j);
                    list.ModifyAtPosition(list.GetNodeValueAtPosicion(j + 1), j);
                    list.ModifyAtPosition(tmp, j + 1);
                    isSorted = false;
                }
            }
            if(isSorted == true)
            {
                break;
            }
        }
        return list;
    }
}
