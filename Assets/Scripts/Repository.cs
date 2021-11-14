using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public abstract class Repository
    {
        public abstract void Initialize();
        public abstract void Save();
    }
}

