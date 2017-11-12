using System;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    #region Public Members

    private short framerateAverage;

    public short FrameRateAverage
    {
        get { return framerateAverage; }
    }

    #endregion

    #region Private Members

    private float[] fpsBuffer;

    private int fpsBufferIndex;

    #endregion

    #region Public Methods

    public void Awake()
    {
        fpsBuffer = new float[60];
        fpsBufferIndex = 0;
    }

    public void Update()
    {
        UpdateBuffer();
        CalculateFps();
    }

    #endregion

    #region Private Methods

    private void UpdateBuffer()
    {
        fpsBuffer[fpsBufferIndex++] = 1f / Time.unscaledDeltaTime;
        if (fpsBufferIndex >= 60)
        {
            fpsBufferIndex = 0;
        }
    }

    private float sumOfFps;

    private int bufferLoop;

    private void CalculateFps()
    {
        sumOfFps = 0;

        for (bufferLoop = 0; bufferLoop < 60; bufferLoop++)
        {
            sumOfFps += fpsBuffer[bufferLoop];
        }
        framerateAverage = Convert.ToInt16(sumOfFps / 60f);
    }

    #endregion
}