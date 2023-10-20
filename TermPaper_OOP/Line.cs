namespace TermPaper_OOP
{
    public class Line : VectorObject
    {
        public float EndX { get; set; }
        public float EndY { get; set; }

        public Line(float x, float y, float endX, float endY, Color color)
            : base(x, y, Color.Blue)
        {
            EndX = endX;
            EndY = endY;
        }

        public override float Perimeter()
        {
            return 0;
        }

        public override float Area()
        {
            return 0;
        }

        public override void Draw(Graphics graph)
        {
            graph.DrawLine(Pen, X, Y, EndX, EndY);
        }
    }
}
