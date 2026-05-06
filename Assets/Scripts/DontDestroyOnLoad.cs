using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public static DontDestroyOnLoad _audioManagerInstance {get; private set;}
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
            DontDestroyOnLoad(gameObject);
        
         
       
    }
    

   
}
