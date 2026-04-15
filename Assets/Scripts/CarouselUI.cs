using UnityEngine;
using UnityEngine.UI;

public class CarouselUI : MonoBehaviour
{
    [SerializeField] Button[] buttons;
    
    
    [ContextMenu("Find all buttons")]
    void FindAllButtons()
    {
         buttons = GetComponentsInChildren<Button>();
    }
    
    [ContextMenu("Some Debug Method")]
    void SomeDebugMethod()
    {
        //Add here debug logic.
    }
}
