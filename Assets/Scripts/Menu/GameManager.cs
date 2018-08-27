using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameManager {
 
  private static Dictionary<string, string> parameters;

  public static void Load(string sceneName, Dictionary<string, string> newParams = null) {
    parameters = newParams;
    SceneManager.LoadScene(sceneName);
  }

  public static Dictionary<string, string> getSceneParameters() {
    return parameters;
  }

  public static string getParam(string paramKey) {
    if (parameters == null || !parameters.ContainsKey(paramKey)) {
      return "";
    }
    return parameters[paramKey];
  }

  public static void setParam(string paramKey, string paramValue) {
    if (parameters == null) {
      parameters = new Dictionary<string, string>();
      parameters.Add(paramKey, paramValue);
    } else if (parameters.ContainsKey(paramKey)) {
      parameters[paramKey] = paramValue;
    } else {
      parameters.Add(paramKey, paramValue);
    }
  }
}
