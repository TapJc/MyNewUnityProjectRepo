using UnityEngine;
using System.Collections;

/*
 * Brian Sida
 * Assignment 6
 * Description: Creates a singleton 
*/
public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T instance;

    public static T Instance
    {
        get { return Instance;  }
    }

    public static bool isInitiaalized
    {
        get { return instance != null; }
    }
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("[Singleton] Trying to instantiate a" +
                " second instance of a singleton class.");
        }
        else
        {
            instance = (T)this;
        }
    }

    protected virtual void OnDestroy()
    {
        // if this object is destroyed, make instance null so another can be created
        if (instance == this)
        {
            instance = null;
        }
    }
}
