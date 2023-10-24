using UnityEngine;

public class SingleTon<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = GameObject.Find(typeof(T).Name);
                if (go == null)
                {
                    go = new GameObject(typeof(T).Name);
                    _instance = go.AddComponent<T>();
                }
                else
                {
                    _instance = go.GetComponent<T>();
                }
            }

            return _instance;
        }
    }

    public void Awake()
    {
        var parentGo = GameObject.Find("Managers");
        if (!parentGo)
        {
            parentGo = new GameObject("Managers");
            gameObject.transform.parent = parentGo.transform;
            DontDestroyOnLoad(parentGo);
        }
        else
        {
            gameObject.transform.parent = parentGo.transform;
        }
    }
}
