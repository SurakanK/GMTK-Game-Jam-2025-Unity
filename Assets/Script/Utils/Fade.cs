using System.Collections;
using UnityEngine;

public static class Fade
{
    public static IEnumerator FadeGameobject(GameObject target, float duration = 1f, bool fadeIn = false)
    {
        float time = 0f;
        float startAlpha = fadeIn ? 0f : 1f;
        float endAlpha = fadeIn ? 1f : 0f;

        SpriteRenderer[] spriteRenderers = target.GetComponentsInChildren<SpriteRenderer>(true);
        ParticleSystem[] particleSystems = target.GetComponentsInChildren<ParticleSystem>(true);

        Color[] originalColors = new Color[spriteRenderers.Length];
        for (int i = 0; i < spriteRenderers.Length; i++)
            originalColors[i] = spriteRenderers[i].color;

        while (time < duration)
        {
            if (!Application.isPlaying)
                yield break;

            float t = time / duration;
            float alpha = Mathf.Lerp(startAlpha, endAlpha, t);

            for (int i = 0; i < spriteRenderers.Length; i++)
            {
                var c = originalColors[i];
                c.a = alpha;
                spriteRenderers[i].color = c;
            }

            foreach (var ps in particleSystems)
            {
                var main = ps.main;
                Color c = main.startColor.color;
                c.a = alpha;
                main.startColor = c;
            }

            time += Time.deltaTime;
            yield return null;
        }

        for (int i = 0; i < spriteRenderers.Length; i++)
        {
            var c = originalColors[i];
            c.a = endAlpha;
            spriteRenderers[i].color = c;
        }

        foreach (var ps in particleSystems)
        {
            var main = ps.main;
            Color c = main.startColor.color;
            c.a = endAlpha;
            main.startColor = c;
        }
    }
}
