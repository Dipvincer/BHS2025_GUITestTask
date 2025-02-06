using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace WpfApp1;

public class MainViewModel : INotifyPropertyChanged
{
    private ShapeModel _rectangleShape;
    private ShapeModel _circleShape;
    private ShapeModel _currentShape;
    private ShapeType _currentShapeType;
    private Visibility _rectangleVisibility;
    private Visibility _ellipseVisibility;
    private double _textPositionX = 50;
    private double _textPositionY = 50;
    

    public ShapeType CurrentShapeType
    {
        get => _currentShapeType;
        set
        {
            _currentShapeType = value;
            ChangeShape(value);
        }
    }
    
    public ShapeModel CurrentShape
    {
        get => _currentShape;
        set { _currentShape = value; OnPropertyChanged(nameof(CurrentShape)); }
    }

    public Visibility RectangleVisibility
    {
        get => _rectangleVisibility;
        set { _rectangleVisibility = value; OnPropertyChanged(nameof(RectangleVisibility)); }
    }

    public Visibility EllipseVisibility
    {
        get => _ellipseVisibility;
        set { _ellipseVisibility = value; OnPropertyChanged(nameof(EllipseVisibility)); }
    }

    public double TextPositionX
    {
        get => _textPositionX;
        set { _textPositionX = value; OnPropertyChanged(nameof(TextPositionX)); }
    }

    public double TextPositionY
    {
        get => _textPositionY;
        set { _textPositionY = value; OnPropertyChanged(nameof(TextPositionY)); }
    }

    public ICommand ChangeShapeCommand { get; }

    public MainViewModel()
    {
        _rectangleShape = new ShapeModel { ShapeType = ShapeType.Rectangle };
        _circleShape = new ShapeModel { ShapeType = ShapeType.Circle };
        _currentShape = _rectangleShape;
        ChangeShapeCommand = new RelayCommand(ChangeShape);
        UpdateVisibility();
    }

    private void ChangeShape(object parameter)
    {
        if (parameter is ShapeType shapeType)
        {
            if (shapeType == ShapeType.Rectangle)
            {
                _rectangleShape = new ShapeModel
                {
                    ShapeType = ShapeType.Rectangle,
                    ShapeColor = _rectangleShape.ShapeColor,
                    Text = _rectangleShape.Text,
                    TextColor = _rectangleShape.TextColor,
                    Width = _rectangleShape.Width,
                    Height = _rectangleShape.Height,
                    Rotation = _rectangleShape.Rotation
                };
                CurrentShape = _rectangleShape;
            }
            else if (shapeType == ShapeType.Circle)
            {
                _circleShape = new ShapeModel
                {
                    ShapeType = ShapeType.Circle,
                    ShapeColor = _circleShape.ShapeColor,
                    Text = _circleShape.Text,
                    TextColor = _circleShape.TextColor,
                    Width = _circleShape.Width,
                    Height = _circleShape.Height,
                    ScaleX = _circleShape.ScaleX,
                    ScaleY = _circleShape.ScaleY
                };
                CurrentShape = _circleShape;
            }
            UpdateVisibility();
        }
    }

    private void UpdateVisibility()
    {
        if (CurrentShapeType == ShapeType.Rectangle)
        {
            RectangleVisibility = Visibility.Visible;
            EllipseVisibility = Visibility.Collapsed;
        }
        else
        {
            RectangleVisibility = Visibility.Collapsed;
            EllipseVisibility = Visibility.Visible;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}