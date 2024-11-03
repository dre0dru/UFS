using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// ReSharper disable NotResolvedInText

namespace Inventories
{
    public sealed class Inventory : IEnumerable<Item>
    {
        private readonly Dictionary<Item, Vector2Int> _items = new();
        private readonly Item[,] _grid;

        public event Action<Item, Vector2Int> OnAdded;
        public event Action<Item, Vector2Int> OnRemoved;
        public event Action<Item, Vector2Int> OnMoved;
        public event Action OnCleared;

        public int Width { get; }
        public int Height { get; }
        public int Count => _items.Count;

        public Inventory(in int width, in int height)
        {
            ValidateSize(width, height);

            Width = width;
            Height = height;
            _grid = new Item[width, height];
        }

        public Inventory(in int width,
            in int height,
            params KeyValuePair<Item, Vector2Int>[] items)
            : this(width, height, (IEnumerable<KeyValuePair<Item, Vector2Int>>)items)
        {
        }

        public Inventory(in int width,
            in int height,
            params Item[] items)
            : this(width, height, (IEnumerable<Item>)items)
        {
        }

        public Inventory(in int width,
            in int height,
            in IEnumerable<KeyValuePair<Item, Vector2Int>> items)
            : this(width, height)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            foreach (var pair in items)
            {
                if (!AddItem(pair.Key, pair.Value))
                {
                    throw new ArgumentException("Invalid items configuration");
                }
            }
        }

        public Inventory(in int width,
            in int height,
            in IEnumerable<Item> items)
            : this(width, height)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            foreach (var item in items)
            {
                if (!AddItem(item))
                {
                    throw new ArgumentException("Invalid items configuration");
                }
            }
        }

        /// <summary>
        /// Checks for adding an item on a specified position
        /// </summary>
        public bool CanAddItem(in Item item, in Vector2Int position)
        {
            if (item == null)
            {
                return false;
            }

            if (Contains(item))
            {
                return false;
            }

            ValidateItemSize(item);

            if (!IsValidPosition(position))
            {
                return false;
            }

            if (!CanFitItem(item, position))
            {
                return false;
            }

            return true;
        }

        public bool CanAddItem(in Item item, in int posX, in int posY)
        {
            return CanAddItem(item, new Vector2Int(posX, posY));
        }

        /// <summary>
        /// Adds an item on a specified position if not exists
        /// </summary>
        public bool AddItem(in Item item, in Vector2Int position)
        {
            if (!CanAddItem(item, position))
            {
                return false;
            }

            PlaceItem(item, position);
            _items.Add(item, position);
            OnAdded?.Invoke(item, position);
            return true;
        }

        public bool AddItem(in Item item, in int posX, in int posY)
        {
            return AddItem(item, new Vector2Int(posX, posY));
        }

        /// <summary>
        /// Checks for adding an item on a free position
        /// </summary>
        public bool CanAddItem(in Item item)
        {
            if (item == null)
            {
                return false;
            }

            if (Contains(item))
            {
                return false;
            }

            return FindFreePosition(item.Size, out _);
        }

        /// <summary>
        /// Adds an item on a free position
        /// </summary>
        public bool AddItem(in Item item)
        {
            if (!CanAddItem(item))
            {
                return false;
            }

            if (!FindFreePosition(item.Size, out var position))
            {
                return false;
            }

            return AddItem(item, position);
        }

        /// <summary>
        /// Returns a free position for a specified item
        /// </summary>
        public bool FindFreePosition(in Vector2Int size, out Vector2Int freePosition)
        {
            ValidateItemSize(size.x, size.y);

            for (var y = 0; y <= Height - size.y; y++)
            for (var x = 0; x <= Width - size.x; x++)
            {
                freePosition = new Vector2Int(x, y);
                if (IsAreaFree(freePosition, size))
                {
                    return true;
                }
            }

            freePosition = Vector2Int.zero;
            return false;
        }

        /// <summary>
        /// Checks if a specified item exists
        /// </summary>
        public bool Contains(in Item item)
        {
            return item != null && _items.ContainsKey(item);
        }

        /// <summary>
        /// Checks if a specified position is occupied
        /// </summary>
        public bool IsOccupied(in Vector2Int position)
        {
            return IsOccupied(position.x, position.y);
        }

        public bool IsOccupied(in int x, in int y)
        {
            return IsValidPosition(x, y) && _grid[x, y] != null;
        }

        /// <summary>
        /// Checks if a position is free
        /// </summary>
        public bool IsFree(in Vector2Int position)
        {
            return IsFree(position.x, position.y);
        }

        public bool IsFree(in int x, in int y)
        {
            return IsValidPosition(x, y) && _grid[x, y] == null;
        }

        /// <summary>
        /// Removes a specified item if exists
        /// </summary>
        public bool RemoveItem(in Item item)
        {
            return RemoveItem(item, out _);
        }

        public bool RemoveItem(in Item item, out Vector2Int position)
        {
            position = Vector2Int.zero;

            if (item == null || !_items.TryGetValue(item, out position))
            {
                return false;
            }

            RemoveItemFromGrid(item, position);
            _items.Remove(item);
            OnRemoved?.Invoke(item, position);
            return true;
        }

        /// <summary>
        /// Returns an item at specified position
        /// </summary>
        public Item GetItem(in Vector2Int position)
        {
            ValidatePosition(position);
            var item = _grid[position.x, position.y];
            if (item == null)
            {
                throw new NullReferenceException();
            }

            return item;
        }

        public Item GetItem(in int x, in int y)
        {
            return GetItem(new Vector2Int(x, y));
        }

        public bool TryGetItem(in Vector2Int position, out Item item)
        {
            item = null;
            if (!IsValidPosition(position.x, position.y))
            {
                return false;
            }

            item = _grid[position.x, position.y];
            return item != null;
        }

        public bool TryGetItem(in int x, in int y, out Item item)
        {
            return TryGetItem(new Vector2Int(x, y), out item);
        }

        /// <summary>
        /// Returns matrix positions of a specified item
        /// </summary>
        public Vector2Int[] GetPositions(in Item item)
        {
            if (item == null)
            {
                throw new NullReferenceException();
            }

            if (!_items.TryGetValue(item, out var position))
            {
                throw new KeyNotFoundException();
            }

            var positions = new List<Vector2Int>();
            for (var x = position.x; x < position.x + item.Size.x; x++)
            for (var y = position.y; y < position.y + item.Size.y; y++)
            {
                positions.Add(new Vector2Int(x, y));
            }

            return positions.ToArray();
        }

        public bool TryGetPositions(in Item item, out Vector2Int[] positions)
        {
            positions = null;
            if (item == null || !Contains(item))
            {
                return false;
            }

            positions = GetPositions(item);
            return true;
        }

        /// <summary>
        /// Clears all inventory items
        /// </summary>
        public void Clear()
        {
            if (Count == 0)
            {
                return;
            }

            _items.Clear();
            Array.Clear(_grid, 0, _grid.Length);
            OnCleared?.Invoke();
        }

        /// <summary>
        /// Returns a count of items with a specified name
        /// </summary>
        public int GetItemCount(string name)
        {
            return _items.Keys.Count(item => item.Name == name);
        }

        /// <summary>
        /// Moves a specified item to a target position if it exists
        /// </summary>
        public bool MoveItem(in Item item, in Vector2Int newPosition)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (!Contains(item))
            {
                return false;
            }

            var oldPosition = _items[item];

            if (oldPosition == newPosition)
            {
                return true;
            }

            RemoveItemFromGrid(item, oldPosition);

            if (!CanFitItem(item, newPosition))
            {
                PlaceItem(item, oldPosition);
                return false;
            }

            PlaceItem(item, newPosition);
            _items[item] = newPosition;
            OnMoved?.Invoke(item, newPosition);
            return true;
        }

        /// <summary>
        /// Reorganizes inventory space to make the free area uniform
        /// </summary>
        public void ReorganizeSpace()
        {
            var items = _items.ToList();
            Clear();

            foreach (var pair in items.OrderByDescending(p => p.Key.Size.x * p.Key.Size.y))
            {
                AddItem(pair.Key);
            }
        }

        /// <summary>
        /// Copies inventory items to a specified matrix
        /// </summary>
        public void CopyTo(in Item[,] matrix)
        {
            for (var x = 0; x < Width; x++)
            for (var y = 0; y < Height; y++)
            {
                matrix[x, y] = _grid[x, y];
            }
        }

        public IEnumerator<Item> GetEnumerator()
        {
            return ((IEnumerable<Item>)_items.Keys).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool CanFitItem(Item item, Vector2Int position)
        {
            if (position.x + item.Size.x > Width || position.y + item.Size.y > Height)
            {
                return false;
            }

            return IsAreaFree(position, item.Size);
        }

        private bool IsAreaFree(Vector2Int position, Vector2Int size)
        {
            for (var x = position.x; x < position.x + size.x; x++)
            for (var y = position.y; y < position.y + size.y; y++)
            {
                if (!IsFree(x, y))
                {
                    return false;
                }
            }

            return true;
        }

        private void PlaceItem(Item item, Vector2Int position)
        {
            for (var x = position.x; x < position.x + item.Size.x; x++)
            for (var y = position.y; y < position.y + item.Size.y; y++)
            {
                _grid[x, y] = item;
            }
        }

        private void RemoveItemFromGrid(Item item, Vector2Int position)
        {
            for (var x = position.x; x < position.x + item.Size.x; x++)
            for (var y = position.y; y < position.y + item.Size.y; y++)
            {
                _grid[x, y] = null;
            }
        }

        private bool IsValidPosition(Vector2Int position)
        {
            return position.x >= 0 && position.x < Width && position.y >= 0 && position.y < Height;
        }

        private bool IsValidPosition(int x, int y)
        {
            return x >= 0 && x < Width && y >= 0 && y < Height;
        }

        private void ValidatePosition(Vector2Int position)
        {
            if (!IsValidPosition(position.x, position.y))
            {
                throw new IndexOutOfRangeException();
            }
        }

        private static void ValidateSize(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        private static void ValidateItemSize(Item item)
        {
            ValidateItemSize(item.Size.x, item.Size.y);
        }

        private static void ValidateItemSize(int width, int height)
        {
            if (width <= 0 || height <= 0)
            {
                throw new ArgumentOutOfRangeException("Invalid item size");
            }
        }
    }
}
