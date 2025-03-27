using UnityEngine;


[CreateAssetMenu()] //Attribute
public class KitchenObjectSO : ScriptableObject
{
    public Transform prefab;
    public Sprite sprite;
    [SerializeField] string objectName;
}
