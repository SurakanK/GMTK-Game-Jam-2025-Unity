using System.Collections;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using Spine.Unity;
using UnityEngine;
using UnityEngine.UI;

public static class GameUtils
{
    public static float Interpolate(float input, float minInput, float maxInput, float minOutput, float maxOutput)
    {
        float t = Mathf.InverseLerp(minInput, maxInput, input);
        return Mathf.RoundToInt(Mathf.Lerp(minOutput, maxOutput, t));
    }

    public static float Map(float input, float minInput, float maxInput, float minOutput, float maxOutput)
    {
        return (input - minInput) * (maxOutput - minOutput) / (maxInput - minInput) + minInput;
    }

    public static float MapReverse(int value, int min, int max, float minOutput, float maxOutput)
    {
        value = Mathf.Clamp(value, min, max);
        float t = (float)(value - min) / (max - min);
        t = 1f - t;
        return Mathf.Lerp(minOutput, maxOutput, t);
    }

    public static Color HexToRGB(string hex)
    {
        hex = hex.Replace("#", "");
        byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
        byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
        byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
        return new Color32(r, g, b, 255);
    }

    public static string CurrencyFormat(int currency)
    {
        return string.Format("{0:" + "#,##0" + "}", currency);
    }

    public static int ParseCurrency(string currencyString)
    {
        string currencyWithoutCommas = currencyString.Replace(",", "");
        return int.Parse(currencyWithoutCommas);
    }

    public static string AmountFormat(float amount)
    {
        return amount % 1 == 0 ? amount.ToString("F0") : amount.ToString("F2");
    }

    public static string AmountFormat(int currency)
    {
        if (currency >= 1000000)
        {
            return string.Format("{0:#,##0.##}M", currency / 1000000m);
        }
        else if (currency >= 1000)
        {
            return string.Format("{0:#,##0.##}K", currency / 1000m);
        }
        else
        {
            return string.Format("{0:#,##0}", currency);
        }
    }

    public static int ParseAmount(string value)
    {
        if (value.EndsWith("K") || value.EndsWith("k"))
        {
            float numericValue = float.Parse(value.Substring(0, value.Length - 1));
            return (int)(numericValue * 1000);
        }
        else if (value.EndsWith("M") || value.EndsWith("m"))
        {
            float numericValue = float.Parse(value.Substring(0, value.Length - 1));
            return (int)(numericValue * 1000000);
        }
        else
        {
            return int.Parse(value);
        }
    }

    public static void ForceRebuildLayout(GameObject gameObject)
    {
        foreach (var layoutGroup in gameObject.GetComponentsInChildren<LayoutGroup>())
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(layoutGroup.GetComponent<RectTransform>());
        }

        var layout = gameObject.GetComponent<LayoutGroup>();
        if (layout)
        {
            LayoutRebuilder.ForceRebuildLayoutImmediate(layout.GetComponent<RectTransform>());
        }
    }

    public static int RandomWeighted(int min, int max, float pow)
    {
        float randomValue = Mathf.Pow(Random.value, pow);
        int weightedExpDrop = Mathf.RoundToInt(min + (max - min) * randomValue);
        return weightedExpDrop;
    }

    public static Vector3 RandomAroundPosition(Vector3 basePosition, float radius)
    {
        return new Vector3(
            basePosition.x + Random.Range(-radius, radius),
            0,
            basePosition.z + Random.Range(-radius, radius)
        );
    }

    public static Vector3 RandomAroundPosition2D(Vector3 basePosition, float radius)
    {
        Vector2 randomOffset2D = Random.insideUnitCircle * radius;
        return basePosition + new Vector3(randomOffset2D.x, randomOffset2D.y, 0f);
    }

    public static void SetVFX(ParticleSystem vfx, Transform owner, Vector3 scale = default)
    {
        if (scale == default)
        {
            scale = vfx.transform.localScale;
        }

        vfx.transform.parent = owner;
        vfx.transform.localPosition = Vector3.zero;
        vfx.transform.localScale = scale;
    }

    public static GameObject FindChildWithTag(Transform parent, string tag)
    {
        Transform[] children = parent.GetComponentsInChildren<Transform>();
        foreach (Transform child in children)
        {
            if (child.CompareTag(tag))
            {
                return child.gameObject;
            }
        }
        return null;
    }

    public static int[] ConvertStringToIntArray(string input)
    {
        string[] stringArray = input.Split(',');
        int[] intArray = new int[stringArray.Length];
        for (int i = 0; i < stringArray.Length; i++)
        {
            intArray[i] = int.Parse(stringArray[i]);
        }
        return intArray;
    }

    public static Vector3 GetRandomPositionAround(Transform transform, float min, float max)
    {
        float degrees = Random.Range(0f, 360f);
        Vector3 direction = new Vector3(Mathf.Cos(degrees), 0, Mathf.Sin(degrees));
        return transform.position + direction * Random.Range(min, max);
    }

    public static T DataClone<T>(T data)
    {
        var json = JsonUtility.ToJson(data);
        return JsonUtility.FromJson<T>(json);
    }

    public static Vector2 GetWorldSize(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        float width = Vector3.Distance(corners[0], corners[3]);
        float height = Vector3.Distance(corners[0], corners[1]);

        return new Vector2(width, height);
    }

    public static void SetGameObjectLayer(GameObject obj, int newLayer)
    {
        if (obj == null) return;
        obj.layer = newLayer;

        foreach (Transform child in obj.transform)
        {
            if (child == null) continue;
            SetGameObjectLayer(child.gameObject, newLayer);
        }
    }

    public static void Fade(this SkeletonAnimation skeleton, MonoBehaviour runner, float from, float to, float duration)
    {
        if (skeleton == null || skeleton.Skeleton == null || runner == null)
            return;

        runner.StartCoroutine(FadeCoroutine(skeleton, from, to, duration));
    }

    private static IEnumerator FadeCoroutine(SkeletonAnimation skeleton, float from, float to, float duration)
    {
        float time = 0f;
        skeleton.Skeleton.A = from;

        while (time < duration)
        {
            time += Time.deltaTime;
            float alpha = Mathf.Lerp(from, to, time / duration);
            skeleton.Skeleton.A = alpha;
            yield return null;
        }

        skeleton.Skeleton.A = to;
    }

    public static void FadeIn(this SkeletonAnimation skeleton, MonoBehaviour runner, float duration = 1f)
    {
        Fade(skeleton, runner, skeleton.Skeleton.A, 1f, duration);
    }

    public static void FadeOut(this SkeletonAnimation skeleton, MonoBehaviour runner, float duration = 1f)
    {
        Fade(skeleton, runner, skeleton.Skeleton.A, 0f, duration);
    }

    public static void UIFade(this CanvasGroup canvasGroup, bool isActive, bool isFade, float duration = 0)
    {
        if (canvasGroup == null)
            return;

        canvasGroup.DOKill();

        if (isFade)
        {
            canvasGroup.DOFade(isActive ? 1f : 0f, duration)
                       .SetEase(Ease.InOutSine)
                       .OnStart(() =>
                       {
                           if (isActive)
                               canvasGroup.blocksRaycasts = canvasGroup.interactable = true;
                       })
                       .OnComplete(() =>
                       {
                           if (!isActive)
                               canvasGroup.blocksRaycasts = canvasGroup.interactable = false;
                       });
        }
        else
        {
            canvasGroup.alpha = isActive ? 1f : 0f;
            canvasGroup.blocksRaycasts = canvasGroup.interactable = isActive;
        }
    }

    public static (string time, string suffix, bool isDay) TimeToString(float currentTime)
    {
        int hours = Mathf.FloorToInt(currentTime);
        int minutes = Mathf.FloorToInt((currentTime - hours) * 60f);

        bool isDay = hours >= 6 && hours < 18;
        string suffix = hours >= 12 ? "PM" : "AM";

        int hour12 = hours % 12;
        if (hour12 == 0) hour12 = 12;

        return (time: $"{hour12:D2}:{minutes:D2}", suffix, isDay);
    }
}