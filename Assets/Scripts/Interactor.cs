using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public abstract class Interactor
    {
        public virtual void OnCreate() { } //����� ��� ���� � ����������� �������
        public virtual void Initialize() { } //����� ��� ���� � ����������� ������� Oncreate
        public virtual void OnStart() { }//����� ��� ���� � ����������� �������������������
    }
}

