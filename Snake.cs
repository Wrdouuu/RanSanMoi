class Snake
{
    public List<Point> Body { get; private set; }
    public Point Head => Body.First();

    public Snake(int x, int y)
    {
        Body = new List<Point> { new Point(x, y) };
    }

    public void Move(Direction direction)
    {
        Point newHead = Head;

        switch (direction)
        {
            case Direction.Up: newHead = new Point(Head.X, Head.Y - 1); break;
            case Direction.Down: newHead = new Point(Head.X, Head.Y + 1); break;
            case Direction.Left: newHead = new Point(Head.X - 1, Head.Y); break;
            case Direction.Right: newHead = new Point(Head.X + 1, Head.Y); break;
        }

        Body.Insert(0, newHead);
        Body.RemoveAt(Body.Count - 1);
    }

    public void Grow()
    {
        Body.Add(Body.Last());
    }

    public bool HasCollided(int screenWidth, int screenHeight)
    {
        // Check wall collision
        if (Head.X < 0 || Head.X >= screenWidth || Head.Y < 0 || Head.Y >= screenHeight)
        {
            return true;
        }

        // Check self collision
        return Body.Skip(1).Any(part => part.Equals(Head));
    }
}
