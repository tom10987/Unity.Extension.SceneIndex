
using UnityEngine;

public class _TEST : MonoBehaviour
{
  [SerializeField]
  SceneIndex _index = null;

  void Start()
  {
    Debug.Log( _index.name );
    Debug.Log( _index.number );
  }

  void Update()
  {
    if ( Input.GetKeyDown( KeyCode.A ) ) { _index.Load(); }
  }
}
