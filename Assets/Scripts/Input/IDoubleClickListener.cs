﻿using UnityEngine.Events;

namespace ShapeToy
{
    public interface IDoubleClickListener
    {
        void AddListener(UnityAction action);
    }
}