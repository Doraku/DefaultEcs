using System;
using System.Collections;
using System.Collections.Generic;
using DefaultEcs;
using Microsoft.Xna.Framework;

namespace DefaultBoids.Component
{
    public sealed class Grid
    {
        public struct Enumerable : IEnumerable<List<Entity>>
        {
            private readonly Grid _grid;
            private readonly Vector2 _position;

            public Enumerable(Grid grid, Vector2 position)
            {
                _grid = grid;
                _position = position;
            }

            public Enumerator GetEnumerator() => new Enumerator(_grid, _position);

            IEnumerator<List<Entity>> IEnumerable<List<Entity>>.GetEnumerator() => GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public struct Enumerator : IEnumerator<List<Entity>>
        {
            private readonly Grid _grid;
            private readonly int minI;
            private readonly int minJ;
            private readonly int maxI;
            private readonly int maxJ;

            private int currentI;
            private int currentJ;

            public Enumerator(Grid grid, Vector2 position)
            {
                _grid = grid;
                int i = Math.Clamp((int)(position.X / _grid._cellWidth), 0, grid._width);
                int j = Math.Clamp((int)(position.Y / _grid._cellHeight), 0, grid._height);

                minI = currentI = Math.Max(0, i - 1);
                minJ = currentJ = Math.Max(0, j - 1);

                --currentI;

                maxI = Math.Min(_grid._width - 1, i + 1);
                maxJ = Math.Min(_grid._height - 1, j + 1);
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

                return true;
            }

            public void Reset()
            {
                currentI = minI - 1;
                currentJ = minJ;
            }

            public void Dispose()
            { }

            public List<Entity> Current => _grid._cells[currentI, currentJ];

            object IEnumerator.Current => Current;
        }

        private readonly int _width;
        private readonly int _height;

        private readonly float _cellWidth;
        private readonly float _cellHeight;
        private readonly List<Entity>[,] _cells;

        public Grid(int capacity)
        {
            _width = (int)(DefaultGame.ResolutionWidth / DefaultGame.NeighborRange);
            _height = (int)(DefaultGame.ResolutionHeight / DefaultGame.NeighborRange);

            _cellWidth = DefaultGame.ResolutionWidth / _width;
            _cellHeight = DefaultGame.ResolutionHeight / _height;
            _cells = new List<Entity>[_width, _height];

            for (int i = 0; i < _cells.GetLength(0); ++i)
            {
                for (int j = 0; j < _cells.GetLength(1); ++j)
                {
                    _cells[i, j] = new List<Entity>(capacity);
                }
            }
        }

        public void Update(Entity entity, Vector2 previous, Vector2 position)
        {
            int oldI = Math.Clamp((int)((previous.X + _cellWidth) / _cellWidth), 0, _width - 1);
            int oldJ = Math.Clamp((int)((previous.Y + _cellHeight) / _cellHeight), 0, _height - 1);

            int newI = Math.Clamp((int)((position.X + _cellWidth) / _cellWidth), 0, _width - 1);
            int newJ = Math.Clamp((int)((position.Y + _cellHeight) / _cellHeight), 0, _height - 1);

            if (oldI != newI || oldJ != newJ)
            {
                List<Entity> entities = _cells[oldI, oldJ];
                lock (entities)
                {
                    entities.Remove(entity);
                }
                entities = _cells[newI, newJ];
                lock (entities)
                {
                    entities.Add(entity);
                }
            }
        }

        public Enumerable GetEnumerator(Vector2 position) => new Enumerable(this, position);
    }
}
