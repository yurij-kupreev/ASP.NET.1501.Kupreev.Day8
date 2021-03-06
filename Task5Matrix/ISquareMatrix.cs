﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5Matrix
{
    public interface ISquareMatrix<T>
    {
        int Length { get; set; }
        T this[int x, int y] { get; set; }
        MatrixChangeEvent mce { get; set; }
    }
}
