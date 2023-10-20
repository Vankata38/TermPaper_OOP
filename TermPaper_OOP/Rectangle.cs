namespace TermPaper_OOP
{
    public class Rectangle : VectorObject
    {
        public float Width { get; set; }
        public float Height { get; set; }

        public Rectangle(float x, float y, float width, float height, Color color)
            : base(x, y, color)
        {
            Width = width;
            Height = height;
        }

        public override float Perimeter()
        {
            return 2 * (Width + Height);
        }

        public override float Area()
        {
            return Width * Height;
        }

        public override void Draw(Graphics graph)
        {
            graph.DrawRectangle(Pen, X, Y, Width, Height);
        }
    }
}
