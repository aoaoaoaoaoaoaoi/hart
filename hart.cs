using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hurt : MonoBehaviour {

    public GameObject hurtPrefab;
    public GameObject Canvas;

    private readonly int Width = 9;
    private readonly int Height = 8;

    private bool[,] hurtArray;

	// Use this for initialization
	void Start () {
        hurtArray = new bool[Width,Height];
        //赤いイメージを置かないマスはfalse
        for (int x = 0; x < Width; ++x)
        {
            for(int y = 0; y < Height; ++y)
            {
                hurtArray[x, y] = getNull(x,y);

            }
        }
        Debug.Log("hurtArray[0,1]" + hurtArray[0, 1]);
        var c=0;
        for (int x = 0; x < Width; ++x)
        {
            for (int y = Height-1; y > -1; --y) {
                if (!hurtArray[x, y]) {
                    //ハートを作る
                    GameObject obj = Instantiate(hurtPrefab) as GameObject;
                    //obj.transform.SetParent(Canvas.transform,false);
                    obj.transform.position=new Vector2(-1+(x*0.25f),3.0f+(-y*0.25f));
                    c++;
                    Debug.Log(c);
                }
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //その座標がNULLか判断する
    private bool getNull(int x,int y)
    {
        switch (x)
        {
            case 0:
            case 8:
                if (y == 0
                    || y == 4
                    || y == 5
                    || y == 6
                    || y == 7)
                {
                    return true;
                }
                else{ return false;
                }
            case 1:
            case 7:
                if (y == 5
                    || y == 6
                    || y == 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 2:
            case 6:
                if (y == 6
                   || y == 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 3:
            case 5:
                if (y == 0
                   || y == 7)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            case 4:
                if (y == 0
                    || y == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            default:
                return true;
        }
    }

}
