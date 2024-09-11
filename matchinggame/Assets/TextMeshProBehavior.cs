using System.Globalization;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(TextMesh))]
public class TextMeshProBehavior : MonoBehaviour
{
    private TextMesh label;
    public UnityEvent startEvent;

    private void Start ()
    {
        label = GetComponent<TextMesh>();
        startEvent.Invoke();

    }
    public void UpdateLabel(IntData obj)
    {
        label.text = obj.value.ToString(CultureInfo.InvariantCulture);
    }

   
}