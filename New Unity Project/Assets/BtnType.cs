using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnType : MonoBehaviour
{
    public BTNType currentType;
    public void OnBtnClick()
    {
        switch(currentType)
        {

            case BTNType.New:

                Debug.Log("New game");
                break;
            case BTNType.Continue:
                Debug.Log("continue");
                break;
        }
    }
}
