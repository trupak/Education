using System.Collections.Generic;

namespace DataStructures
{
    public class BinaryMatrix
    {
        private int[,] _matrix;

        public BinaryMatrix(int[,] matrix)
        {
            _matrix = matrix;
        }
        
        public int Get(int row, int col)
        {
            return _matrix[row, col];
        }

        public IList<int> Dimensions()
        {
            return new List<int>
            {
                _matrix.GetLength(0), _matrix.GetLength(1)
            };
        }
    }
}