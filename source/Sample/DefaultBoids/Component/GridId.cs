using System;
using System.Collections;
using System.Collections.Generic;
using DefaultEcs;
using Microsoft.Xna.Framework;

namespace DefaultBoids.Component
{
    public readonly struct GridId : IEquatable<GridId>
    {
        public readonly int X;
        public readonly int Y;

        public GridId(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override int GetHashCode() => X + (Y * 1000);

        public override bool Equals(object obj) => obj is GridId other && Equals(other);

        public bool Equals(GridId other) => X == other.X && Y == other.Y;

        public override string ToString() => $"{X} {Y}";

        public static bool operator ==(GridId left, GridId right) => left.Equals(right);

        public static bool operator !=(GridId left, GridId right) => !(left == right);
    }

    public static class GridIdExtension
    {
        private const int _width = (int)(DefaultGame.ResolutionWidth / DefaultGame.NeighborRange * 3);
        private const int _height = (int)(DefaultGame.ResolutionHeight / DefaultGame.NeighborRange * 3);
        private const int _cellWidth = DefaultGame.ResolutionWidth / _width;
        private const int _cellHeight = DefaultGame.ResolutionHeight / _height;

        public struct Enumerable : IEnumerable<GridId>
        {
            private readonly GridId _id;

            public Enumerable(GridId id)
            {
                _id = id;
            }

            public Enumerator GetEnumerator() => new(_id);

            IEnumerator<GridId> IEnumerable<GridId>.GetEnumerator() => GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public struct Enumerator : IEnumerator<GridId>
        {
            private readonly int minI;
            private readonly int minJ;
            private readonly int maxI;
            private readonly int maxJ;

            private int currentI;
            private int currentJ;

            public Enumerator(GridId id)
            {
                minI = currentI = Math.Max(0, id.X - 1);
                minJ = currentJ = Math.Max(0, id.Y - 1);

                --currentI;
                Current = default;

                maxI = Math.Min(_width - 1, id.X + 1);
                maxJ = Math.Min(_height - 1, id.Y + 1);
            }

            public bool MoveNext()
            {
                if (++currentI > maxI)
                {
                    if (++currentJ > maxJ)
                    {
                        return false;
                    }

                    currentI = minI;
                }

                Current = new GridId(currentI, currentJ);

                return true;
            }

            public void Reset()
            {
                currentI = minI - 1;
                currentJ = minJ;
            }

            public void Dispose()
            { }

            public GridId Current { get; private set; }

            object IEnumerator.Current => Current;
        }

        public static Enumerable GetNeighbors(this GridId id) => new(id);

        public static GridId ToGridId(this Vector2 position) => new((int)Math.Clamp(position.X / _cellWidth, 0, _width - 1), (int)Math.Clamp(position.Y / _cellHeight, 0, _height - 1));

        public static void CreateBehaviors(this World world)
        {
            for (int i = 0; i < _width; ++i)
            {
                for (int j = 0; j < _height; ++j)
                {
                    Entity entity = world.CreateEntity();
                    entity.Set(new GridId(i, j));
                    entity.Set<Behavior>();
                }
            }
        }
    }
}
