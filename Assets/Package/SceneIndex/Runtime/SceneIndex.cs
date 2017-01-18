
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

[Serializable]
public class SceneIndex
{
  // TIPS:
  // シーン名に紐づけられるデータのため、インスペクターには表示しない
  // エディター拡張側で使用するため SerializeField 属性が必要
  [SerializeField]
  int _number = 0;
  public int number { get { return _number; } }


  [SerializeField]
  string _name = string.Empty;
  public string name { get { return _name; } }

  public void Load()
  {
    SceneManager.LoadScene( _name, LoadSceneMode.Single );
  }
}
