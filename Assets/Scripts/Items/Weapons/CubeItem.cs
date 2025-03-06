using UnityEngine;
using Assets.Scripts;

public class CubeItem : MonoBehaviour,IInteractableItem
{
    Color[] colors = { Color.red,Color.black,Color.blue,Color.yellow,Color.green,Color.white};
    int currentColor;
    private void Awake()
    {
        currentColor = 0;
    }
    public void Interact()
    {
        if (currentColor == colors.Length)
            currentColor = 0;
        else
        {
            GetComponent<Outline>().OutlineColor = colors[currentColor];
            currentColor++;
        }
    }
}
