using UnityEngine;
using TMPro;

public class FPSCounter : MonoBehaviour
{
    private int _FPS;
    private int _frameBufferLenght = 60;
    private int[] _frameBuffer;
    private int _frameBufferIndex;
    private int _biggestFPS, _lowestFPS;

    [SerializeField]
    private TextMeshProUGUI _FPSText;

    private string[] _FPS0to120 =
    {
        "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10",
        "11", "12", "13", "14", "15", "16", "17", "18", "19", "20",
        "21", "22", "23", "24", "25", "26", "27", "28", "29", "30",
        "31", "32", "33", "34", "35", "36", "37", "38", "39", "40",
        "41", "42", "43", "44", "45", "46", "47", "48", "49", "50",
        "51", "52", "53", "54", "55", "56", "57", "58", "59", "60",
        "61", "62", "63", "64", "65", "66", "67", "68", "69", "70",
        "71", "72", "73", "74", "75", "76", "77", "78", "79", "80",
        "81", "82", "83", "84", "85", "86", "87", "88", "89", "90",
        "91", "92", "93", "94", "95", "96", "97", "98", "99", "100",
        "100", "101", "102", "103", "104", "105", "106", "107", "108", "109", "110",
        "111", "112", "113", "114", "115", "116", "117", "118", "119", "120",
        "120+"
    };

    private void Update()
    {
        if (_frameBuffer == null || _frameBufferLenght != _frameBuffer.Length)
        {
            InitializeBuffer();
        }

        UpdateBuffer();
        CalculateFPS();
    }

    private void InitializeBuffer()
    {
        _frameBuffer = new int[_frameBufferLenght];
        _frameBufferIndex = 0;
    }

    private void UpdateBuffer()
    {
        _frameBuffer[_frameBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
        if (_frameBufferIndex >=_frameBufferLenght)
        {
            _frameBufferIndex = 0;
        }
    }

    private void CalculateFPS()
    {
        int Sum = 0;
        int Lowest = int.MaxValue;
        int Biggest = 0;

        for (int i = 0; i < _frameBufferLenght; i++)
        {
            int fps = _frameBuffer[i];
            Sum += fps;

            if (fps > Biggest)
            {
                Biggest = fps;
            }

            if (fps < Lowest)
            {
                Lowest = fps;
            }
        }

        _biggestFPS = Biggest;
        _lowestFPS = Lowest;

        _FPS = Sum / _frameBufferLenght;

        if (_biggestFPS <= 120)
        {
            _FPSText.text = "FPS: " + "Mid." + _FPS0to120[_FPS] + " Max." + _FPS0to120[_biggestFPS] + " Min." + _FPS0to120[_lowestFPS];
        }
        else
        {
            string sFPS = "0";
            string sLowestFPS = "0";

            if (_FPS >= 120)
            {
                sFPS = _FPS0to120[122];
            }

            if (_lowestFPS >= 120)
            {
                sLowestFPS = _FPS0to120[122];
            }

            _FPSText.text = "FPS: " + "Mid." + sFPS + " Max." + _FPS0to120[122] + " Min." + sLowestFPS;
        }
    }
}
