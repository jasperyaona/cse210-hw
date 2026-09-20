using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        string result = "";

        foreach (char character in _text)
        {
            if (char.IsLetter(character))
            {
                result += "_";
            }
            else
            {
                result += character;
            }
        }

        return result;
    }
}