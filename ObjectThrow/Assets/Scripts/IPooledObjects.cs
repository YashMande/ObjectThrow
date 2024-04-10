
using UnityEngine;

public interface IPooledObjects 
{
    //seperate Start Function which is used for reusing the objects instead of instantiate
    void OnObjectSpawn();
}
