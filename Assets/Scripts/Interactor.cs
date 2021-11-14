using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public abstract class Interactor
    {
        public virtual void OnCreate() { } //когда все репо и интеракторы созданы
        public virtual void Initialize() { } //когда все репо и интеракторы сделали Oncreate
        public virtual void OnStart() { }//когда все репо и интеракторы проинициализированы
    }
}

