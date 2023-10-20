namespace TermPaper_OOP
{
    public abstract class VectorObject
    {
        protected Pen Pen { get; }
        public float X { get; set; }
        public float Y { get; set; }

        public VectorObject(float x, float y, Color color)
        {
            X = x;
            Y = y;
            Pen = new Pen(color);
        }

        public abstract float Perimeter();
        public abstract float Area();
        public abstract void Draw(Graphics graph);
    }
}
