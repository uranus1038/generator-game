using UnityEngine;
public class CandyDemo : MonoBehaviour
{
    public static CandyDemo star;
    // Resources
    protected string playerObject_0;
    protected string playerObject_1;
    private GameObject player_0;
    private void Awake()
    {
        this.Init();
        if (star == null)
        {
            star = this;
        }
        else if (star != this)
        {
            Debug.Log($"UMI::DESTROY()->INSTANCE");
            Destroy(this);
        }
    }
    private void Start()
    {
        this.player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load(this.playerObject_0,
            typeof(GameObject)), Vector3.zero, Quaternion.identity);
    }
    private void Init()
    {
        this.playerObject_0 = "GameAssets/Characters/viewChar/boyChar";
        this.playerObject_1 = "GameAssets/Characters/viewChar/boyCharPlayer";
    }
}
