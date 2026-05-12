using Unity.Mathematics;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public GameObject ItemToDrop;
    public void Drop()
    {
        if(ItemToDrop == null)
        {
            return;
        }
        if(ItemToDrop != null){
        Instantiate(ItemToDrop, transform.position + new Vector3(0f, 1f, 0f), quaternion.identity);
        
    }
        else if (ItemToDrop == null)
        {
            Debug.LogError("ERROR:: Item to drop is null");
        }
        else
        {
            Debug.Log("ERROR: unkown Error has occured");
        }
    }
}
