﻿using System;
using System.Collections.Generic;

namespace Sources.Utils.CustomCollections
{
    public interface ICustomList<T> : IReadOnlyList<T>
    {
        event Action CountChanged;
    }
}