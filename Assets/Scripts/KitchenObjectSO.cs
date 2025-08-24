using UnityEngine;

[CreateAssetMenu()]
public class KitchenObjectSO : ScriptableObject {
    //read only so that is why it is public, we will not write to it
    public Transform prefab;
    public Sprite sprite;
    public string objectName;
}
