using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Page
{
    public int pageNum;
    public GameObject pageObj;

    public Page(int num, GameObject obj)
    {
        this.pageNum = num;
        this.pageObj = obj;
    }
}
