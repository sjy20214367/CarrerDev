using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.isTouchedScreen = true;
        Debug.LogFormat("{0} from {1}", GameManager.isTouchedScreen, "OnMouseDown");
    }

    private void OnMouseUp() 
    {
        GameManager.isTouchedScreen = false;
        Debug.LogFormat("{0} from {1}", GameManager.isTouchedScreen, "OnMouseUp");        
    }

    private void OnMouseDrag()
    {
        GameManager.isTouchedScreen = true;
        Debug.LogFormat("{0} from {1}", GameManager.isTouchedScreen, "OnMouseDrag");          
    }
}
