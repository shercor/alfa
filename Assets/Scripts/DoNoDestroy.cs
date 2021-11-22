using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoNoDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    int num = 0;
    private void Start() {
        if (num == 0){
            GameObject[] musicObj = GameObject.FindGameObjectsWithTag("GameMusic");
            num = 1;
        }
        
    }

    private void Update() {
        num = num + 1;
        
        //if(musicObj.Length > 1)
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
        if(ifScene_CurrentlyLoaded_inEditor("Juego") || ifScene_CurrentlyLoaded_inEditor("Main Menu"))
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject); 
        
    }
    bool ifScene_CurrentlyLoaded_inEditor(string sceneName_no_extention) {
          for(int i = 0; i<SceneManager.sceneCount; ++i) {
             Scene scene = SceneManager.GetSceneAt(i);
             Debug.Log(scene.name);
             Debug.Log(sceneName_no_extention);

             if(scene.name == sceneName_no_extention) {
                 //the scene is already loaded
                 return true;
             }
         }
         //scene not currently loaded in the hierarchy:
         return false;
     }
}
