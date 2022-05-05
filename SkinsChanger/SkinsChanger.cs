using UnityEngine;
using Unity.VectorGraphics;

public class SkinsChanger : MonoBehaviour
{
    [SerializeField] private Camera _backgroundCamera;
    [SerializeField] private SpriteRenderer[] _cubesInGame;
    [SerializeField] private SpriteRenderer[] _shadowsInGame;
    [SerializeField] private SpriteRenderer _secondShadow;
    [SerializeField] private SpriteRenderer _startLine;
    [SerializeField] private SVGImage[] _buttons;
    [SerializeField] private ScoreTextDraver _scoreTextDraver;

    [SerializeField] private Skins[] _skins;

    private int _skinNumber, _colorNumber;

    private SaveData _saveData = new SaveData();
    private Utilits _utilits = new Utilits();

    private void Start()
    {
        /*SkinNumber = SaveData.LoadInt("SkinNumber");

        SkinChange(SkinNumber);

        ColorNumber = SaveData.LoadInt("ColorNumber" + SkinNumber.ToString());

        ColorChange(ColorNumber);*/

        //Вынести всё это в какой-нибудь лоадер
    }

    public void NextSkin()
    {
        _utilits.LoopIntValue(_skinNumber += 1, 0, 1);
        ChangeSkin(_skinNumber);
    }

    public void LastSkin()
    {
        _utilits.LoopIntValue(_skinNumber -= 1, 0, 1);
        ChangeSkin(_skinNumber);
    }

    public void NextColor()
    {
        _utilits.LoopIntValue(_colorNumber += 1, 0, 1);
        ChangeColor(_colorNumber);
    }

    public void LastColor()
    {
        _utilits.LoopIntValue(_colorNumber -= 1, 0, 1);
        ChangeColor(_colorNumber);
    }

    public void ChangeColor(int number)
    {
        if (_skinNumber == 0)
        {
            ChangeSprites(_cubesInGame, _skins[0].CubesSkins[number]);

            _saveData.SaveInt("ColorNumber" + _skinNumber.ToString(), _colorNumber); //Сохраняем цвет фона/куба текущего скина
        }
    }

    public void ChangeSkin(int number)
    {
        int backgroundNumber = Random.Range(0, _skins[number].BackgroundColors.Length);
        _backgroundCamera.backgroundColor = _skins[number].BackgroundColors[backgroundNumber];

        int zatichka = 0;
        ChangeSprites(_cubesInGame, _skins[number].CubesSkins[zatichka]);

        ChangeSpritesColor(_shadowsInGame, _skins[number].ShadowsColor);

        _secondShadow.color = _skins[number].SecondShadowColor;

        _startLine.color = _skins[number].StartLineColor;

        ChangeSVGImagesColor(_buttons, _skins[number].ButtonsColor);

        //scoreTextDraver.Numbers = Skins[number].Numbers;
        _scoreTextDraver.DrawScoreText(0); //Вот этой херни тут быть не должно. Вообще не касаться скриптов в этом классе

        ChangeColor(_saveData.LoadInt("ColorNumber" + _skinNumber.ToString())); //При смене скина меняем цвет фона/куба на тот, что был раньше

        _saveData.SaveInt("SkinNumber", _skinNumber);
    }

    private void ChangeSprites(SpriteRenderer[] ChangedSprites, Sprite NewSprites)
    {
        for (int i = 0; i < ChangedSprites.Length; i++)
        {
            ChangedSprites[i].sprite = NewSprites;
        }
    }

    private void ChangeSpritesColor(SpriteRenderer[] ChangedSprites, Color Color)
    {
        for (int i = 0; i < ChangedSprites.Length; i++)
        {
            ChangedSprites[i].color = Color;
        }
    }

    private void ChangeSVGImagesColor(SVGImage[] ChangedSprites, Color Color)
    {
        for (int i = 0; i < ChangedSprites.Length; i++)
        {
            ChangedSprites[i].color = Color;
        }
    }
}

[System.Serializable]
public class Skins
{
    public Color[] BackgroundColors;

    public Sprite[] CubesSkins;

    public Color ButtonsColor;

    public Color ShadowsColor;

    public Color SecondShadowColor;

    public Color StartLineColor;

    public Sprite[] Numbers;
}