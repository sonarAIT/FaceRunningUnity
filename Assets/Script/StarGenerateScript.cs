using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StarGenerateScript : MonoBehaviour
{
    ParticleSystem currentParticleSystem;
    Color[] COLORS = new Color[]{Color.white, Color.red, Color.yellow, Color.blue, new Color(1f, 0.255f, 0f, 1f), Color.magenta};

    // Start is called before the first frame update
    void Start()
    {
        currentParticleSystem = GameObject.Find("Star").GetComponent<ParticleSystem>();
        ChangeLevel(1);
    }

    public void ChangeLevel(int level) {
        const float alpha1 = 1.0f;
        Gradient ourGradientMin = new Gradient();
        ourGradientMin.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(COLORS[Math.Min(level-1, COLORS.Length-1)], 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha1, 0.0f), new GradientAlphaKey(alpha1, 1.0f) }
        );

        // A simple 2 color gradient with a fixed alpha of 0.0f.
        const float alpha2 = 1.0f;
        Gradient ourGradientMax = new Gradient();
        ourGradientMax.SetKeys(
            new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f), new GradientColorKey(COLORS[Math.Min(level-1, COLORS.Length-1)], 1.0f) },
            new GradientAlphaKey[] { new GradientAlphaKey(alpha2, 0.0f), new GradientAlphaKey(alpha2, 1.0f) }
        );
 
        var randomColors = new ParticleSystem.MinMaxGradient(ourGradientMin, ourGradientMax);
        randomColors.mode = ParticleSystemGradientMode.RandomColor;
        ParticleSystem.MainModule psMain = currentParticleSystem.main;
        psMain.startColor = randomColors;
    }

    public void Pause(bool isPause) {
        if(isPause) {
            currentParticleSystem.Pause();
        } else {
            currentParticleSystem.Play();
        }
        
    }
}
