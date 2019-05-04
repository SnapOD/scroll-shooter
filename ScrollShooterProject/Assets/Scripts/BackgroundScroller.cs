using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public float scrollSpeed;// скорость движения
    public float partLength;// длина в метрах?
    public float partWidth;
    public float zOffset;// сдвиг по z относительно глобального нуля
    public float ySwapPoint;// положение, при котором изображение переставляется наверх 
    public List<GameObject> backgroundParts;
    public List<GameObject> randomParts;

    void Start()
    {
        for (int i = 0; i < backgroundParts.Count; i++)
        {
            backgroundParts[i].transform.position = new Vector3(0, i * partLength /*+ ySwapPoint*/, zOffset);
            RandomParts(backgroundParts[i]);
        }

    }
    public int randomPartsCount;
    public void RandomParts(GameObject container)
    {
        for (int i = 0; i < randomPartsCount; i++)
        {
            int index = Random.Range(0, randomParts.Count);

            GameObject inst = Instantiate(randomParts[index], container.transform);
            inst.transform.localPosition = new Vector2((Random.value - 0.5f) * partWidth, (Random.value - 0.5f) * partLength);
            inst.GetComponent<SpriteRenderer>().sortingOrder = -(int)(inst.transform.localPosition.y * 10);
        }
    }
    void Update()
    {
        for (int i = 0; i < backgroundParts.Count; i++)
        {
            backgroundParts[i].transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
            if (backgroundParts[i].transform.position.y <= ySwapPoint)
            {
                GameObject tmp = backgroundParts[i];
                tmp.transform.position = backgroundParts[backgroundParts.Count - 1].transform.position + new Vector3(0, partLength, 0);
                backgroundParts.RemoveAt(0);
                backgroundParts.Add(tmp);
                i--;
            }
        }
    }

    public void SetScrollSpeed(float newScrollSpeed, float time, bool useLerp = true)
    {
        if (!useLerp)
            scrollSpeed = newScrollSpeed;
        else
            StartCoroutine(ChangeScrollSpeedCoroutine(newScrollSpeed, time));
    }
    public void SetBackground(LevelDesign levelDesign)
    {
        ClearBackground();
        for (int i = 0; i < levelDesign.backgroundParts.Length; i++)
        {
            GameObject part = new GameObject();
            part.transform.SetParent(transform);
            SpriteRenderer renderer = part.AddComponent<SpriteRenderer>();
            renderer.sprite = levelDesign.backgroundParts[i].sprite;
            if (i == 0)
            {
                partLength = renderer.bounds.size.y - 0.01f;
                ySwapPoint = (partLength / 2 + 20) * -1;
            }
            backgroundParts.Add(part);
            part.transform.position = new Vector3(0, i * partLength + ySwapPoint, zOffset);
        }
    }
    void ClearBackground()
    {
        for (int i = 0; i < backgroundParts.Count; i++)
        {
            GameObject.Destroy(backgroundParts[i]);
        }
        backgroundParts.Clear();
    }
    IEnumerator ChangeScrollSpeedCoroutine(float newScrollSpeed, float time)
    {
        float t = 0;
        float oldSpeed = scrollSpeed;
        while (t <= 1)
        {
            scrollSpeed = Mathf.Lerp(oldSpeed, newScrollSpeed, t);
            t += Time.deltaTime / time;
            yield return null;
        }
    }
}
