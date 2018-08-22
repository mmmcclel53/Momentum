using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager {
 
  private Dictionary<string, string> parameters;
  public int COMPLEXITY = 0;
  public string[] SOLUTION;

  public void Load(string sceneName, Dictionary<string, string> newParams = null) {
    parameters = newParams;
    SceneManager.LoadScene(sceneName);
  }

  public void Load(string sceneName, string paramKey, string paramValue) {
    parameters = new Dictionary<string, string>();
    parameters.Add(paramKey, paramValue);
    SceneManager.LoadScene(sceneName);
  }

  public Dictionary<string, string> getSceneParameters() {
    return parameters;
  }

  public string getParam(string paramKey) {
    if (parameters == null) return "";
    return parameters[paramKey];
  }

  public void setParam(string paramKey, string paramValue) {
    if (parameters == null)
      parameters = new Dictionary<string, string>();
    parameters.Add(paramKey, paramValue);
  }
}
