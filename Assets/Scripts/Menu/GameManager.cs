using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager {
 
  private static Dictionary<string, string> parameters;
  public static int COMPLEXITY = 0;
  public static string[] SOLUTION;

  public static void Load(string sceneName, Dictionary<string, string> newParams = null) {
    parameters = newParams;
    SceneManager.LoadScene(sceneName);
  }

  public static void Load(string sceneName, string paramKey, string paramValue) {
    parameters = new Dictionary<string, string>();
    parameters.Add(paramKey, paramValue);
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
      parameters = new Dictionary<string, string>();
    parameters.Add(paramKey, paramValue);
  }
}
