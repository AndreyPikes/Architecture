using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public sealed class SceneManagerExample : SceneManagerBase
    {
        public override void InitSceneMap()
        {
            this.sceneConfigMaps[SceneConfigExample.SCENE_NAME] = new SceneConfigExample();
        }
    }
}

