double length = double.Parse(Console.ReadLine());
double width = double.Parse(Console.ReadLine());
double height = double.Parse(Console.ReadLine());

try
{
    Box box = new Box(length, width, height);
    Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
    Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():f2}");
    Console.WriteLine($"Volume - {box.Volume():f2}");
}
catch (ArgumentException ex)
{

    Console.WriteLine(ex.Message);
}


public class Box
{

	private double _length;
	private double _width;
	private double _height;

    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Height
    {
		get { return _height; }
		private set
		{
			if(value <= 0)
			{
				throw new ArgumentException("Height cannot be zero or negative.");
			}
			_height = value;
		}
	}
	public double Length
    {
		get { return _length; }
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Length cannot be zero or negative.");
            }
            _length = value;
		}
	}
    public double Width
    {
        get { return _width; }
        private set
		{
            if (value <= 0)
            {
                throw new ArgumentException("Width cannot be zero or negative.");
            }
            _width = value;
		}
    }

    public double SurfaceArea()
    {
        double surfaceArea = 2* Length * Width + 2* Length * Height + 2* Width * Height;

        return surfaceArea;
    }
    public double LateralSurfaceArea()
    {
        double lateralSurfaceArea = 2 * Length * Height + 2 * Width * Height;

        return lateralSurfaceArea;
    }
    public double Volume()
    {
        double volume = Length * Width* Height;

        return volume;
    }
}