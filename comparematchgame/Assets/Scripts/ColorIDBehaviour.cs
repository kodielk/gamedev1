using UnityEngine;

public class ColorIDBehaviour : IdContainerBehaviour
{
    public ColorIDDataList colorIDDataListObj;

    public void Awake()
    {
        idObj = colorIDDataListObj.currentColor;
    }
}
