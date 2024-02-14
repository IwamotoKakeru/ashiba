using System;
using UnityEngine;

/// <summary>
/// オブジェクトを左右に振動させる
/// 主に生成時に死体を振動させるのに使用
/// </summary>
public class Oscillator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Oscillator oscillator;
    private float elapsedTime = 0.0f;
    private float oscillateTime = 3.0f;

    private float angularSpeed = 64.0f;
    private float maxAmplitude = 0.2f;
    private float dumpingCoefficient = 2.0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        oscillator = GetComponent<Oscillator>();
        Invoke("StopOscillate", oscillateTime);
    }

    /// <summary>
    /// 減衰振動関数, 指数関数的に減衰しながら振動する様子を値で返す
    /// </summary>
    /// <param name="_time">時間</param>
    /// <param name="_angularSpeed">角速度</param>
    /// <param name="_maxAmplitude">最大振幅</param>
    /// <param name="_dumpingCoefficient">減衰率</param>
    /// <returns>振動している座標</returns>
    double DampedOscillation(double _time, double _angularSpeed, double _maxAmplitude, double _dumpingCoefficient)
    {
        return _maxAmplitude * Math.Pow(Math.E, -_time * _dumpingCoefficient) * Math.Cos(_angularSpeed * _time);
    }

    void StopOscillate()
    {
        spriteRenderer.transform.localPosition = new Vector3(0, 0, 0);
        oscillator.enabled = false;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        float xPos = (float)DampedOscillation(elapsedTime, angularSpeed, maxAmplitude, dumpingCoefficient);
        spriteRenderer.transform.localPosition = new Vector3(xPos, 0, 0);
    }
}
