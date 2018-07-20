using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager {
 
    private static Dictionary<string, string> parameters;
 
    public static void Load(string sceneName, Dictionary<string, string> parameters = null) {
        GameManager.parameters = parameters;
        SceneManager.LoadScene(sceneName);
    }
 
    public static void Load(string sceneName, string paramKey, string paramValue) {
        GameManager.parameters = new Dictionary<string, string>();
        GameManager.parameters.Add(paramKey, paramValue);
        SceneManager.LoadScene(sceneName);
    }
 
    public static Dictionary<string, string> getSceneParameters() {
        return parameters;
    }
 
    public static string getParam(string paramKey) {
        if (parameters == null) return "";
        return parameters[paramKey];
    }
 
    public static void setParam(string paramKey, string paramValue) {
        if (parameters == null)
            GameManager.parameters = new Dictionary<string, string>();
        GameManager.parameters.Add(paramKey, paramValue);
    }
}
