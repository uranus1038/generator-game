using UnityEngine;
public class CandyDemo : MonoBehaviour
{
    public static CandyDemo star;
    // Resources
    protected string playerObject_0;
    protected string playerObject_1;
    protected string playerObject_2;
    private GameObject player_0;
    private void Awake()
    {
        this.Init();
            star = this;
    }
    private void Start()
    {
        this.player_0 = (GameObject)UnityEngine.Object.Instantiate((GameObject)Resources.Load(this.playerObject_1,
            typeof(GameObject)), Vector3.zero, Quaternion.identity);
    }
    private void Init()
    {
        this.playerObject_0 = "GameAssets/Characters/viewChar/maleChar";
        this.playerObject_1 = "GameAssets/Characters/viewChar/femaleChar";
    }
}