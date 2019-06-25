using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteNumber : MonoBehaviour
{
    public enum OrderKind
    {
        center,
        right,
        left
    }
    public OrderKind orderKind;
    public int value = 0;
    public Sprite[] sprites = new Sprite[10];
    public float spacing;
    List<GameObject> numbers = new List<GameObject>();

    void Update()
    {
        SetNumber(value);
    }

    void SetNumber(int value)
    {
        for (int i = 0; i < numbers.Count; i++)
        {
            Destroy(numbers[i]);
        }
        numbers.Clear();
        float lengh = 0;
        if(value == 0)
        {
            int digit = 0;
            GameObject temp = new GameObject();
            temp.transform.parent = transform;
            temp.transform.localPosition = Vector3.zero;
            temp.transform.localScale = Vector3.one;
            temp.AddComponent<Image>().sprite = sprites[digit];
            temp.GetComponent<Image>().SetNativeSize();
            lengh += sprites[digit].rect.width;
            numbers.Add(temp);
        }
        while (value > 0)
        {
            int digit = value % 10;
            GameObject temp = new GameObject();
            temp.transform.parent = transform;
            temp.transform.localPosition = Vector3.zero;
            temp.transform.localScale = Vector3.one;
            temp.AddComponent<Image>().sprite = sprites[digit];
            temp.GetComponent<Image>().SetNativeSize();
            lengh += sprites[digit].rect.width;
            numbers.Add(temp);
            value /= 10;
        }
        lengh += (numbers.Count - 1) * spacing;
            float sum = 0;
        if (orderKind == OrderKind.center)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i].transform.localPosition += new Vector3((lengh / 2) - sum - (numbers[i].GetComponent<Image>().sprite.rect.width / 2), 0, 0);
                sum += numbers[i].GetComponent<Image>().sprite.rect.width + spacing;
            }
        }
        else if(orderKind == OrderKind.right)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i].transform.localPosition += new Vector3(- sum - (numbers[i].GetComponent<Image>().sprite.rect.width / 2), 0, 0);
                sum += numbers[i].GetComponent<Image>().sprite.rect.width + spacing;
            }
        }
        else if(orderKind == OrderKind.left)
        {
            for (int i = 0; i < numbers.Count; i++)
            {
                numbers[i].transform.localPosition += new Vector3(lengh - (numbers[i].GetComponent<Image>().sprite.rect.width / 2) - sum, 0, 0);
                sum += numbers[i].GetComponent<Image>().sprite.rect.width + spacing;
            }
        }
    }
}
