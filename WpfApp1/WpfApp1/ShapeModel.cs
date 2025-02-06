using System.ComponentModel;
using System.Windows.Media;
using Color = System.Windows.Media.Color;

namespace WpfApp1;

public class ShapeModel : INotifyPropertyChanged
{
    private ShapeType _shapeType = ShapeType.Rectangle;
    private Color _shapeColor = Colors.Blue;
    private string _text = "Sample Text";
    private Color _textColor = Colors.Red;
    private double _width = 100;
    private double _height = 100;
    private double _rotation = 0;
    private double _scaleX = 1;
    private double _scaleY = 1;

    public ShapeType ShapeType
    {
        get => _shapeType;
        set
        {
            if (_shapeType != value)
            {
                _shapeType = value;
                OnPropertyChanged(nameof(ShapeType));
            }
        }
    }

    public Color ShapeColor
    {
        get => _shapeColor;
        set { _shapeColor = value; OnPropertyChanged(nameof(ShapeColor)); }
    }

    public string Text
    {
        get => _text;
        set { _text = value; OnPropertyChanged(nameof(Text)); }
    }

    public Color TextColor
    {
        get => _textColor;
        set { _textColor = value; OnPropertyChanged(nameof(TextColor)); }
    }

    public double Width
    {
        get => _width;
        set { _width = value; OnPropertyChanged(nameof(Width)); }
    }

    public double Height
    {
        get => _height;
        set { _height = value; OnPropertyChanged(nameof(Height)); }
    }

    public double Rotation
    {
        get => _rotation;
        set { _rotation = value; OnPropertyChanged(nameof(Rotation)); }
    }

    public double ScaleX
    {
        get => _scaleX;
        set { _scaleX = value; OnPropertyChanged(nameof(ScaleX)); }
    }

    public double ScaleY
    {
        get => _scaleY;
        set { _scaleY = value; OnPropertyChanged(nameof(ScaleY)); }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}