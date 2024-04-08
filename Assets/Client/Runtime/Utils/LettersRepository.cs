using System;
using System.Collections.Generic;

using UnityEngine.Pool;

namespace Client.Runtime.Utils
{
    public class LettersRepository
    {
        private ObjectPool<LetterModel> _pool;
        private Func<LetterModel> _createFunc;

        public LettersRepository(Func<LetterModel> createFunc)
        {
            _createFunc = createFunc;
        }

        public List<LetterModel> ActiveElements { get; private set; } = new();

        public LetterModel Get()
        {
            _pool ??= CreatePool();
            var element = _pool.Get();
            ActiveElements.Add(element);
            return element;
        }

        public void Release(LetterModel model)
        {
            ActiveElements.Remove(model);
            if (!model.Active)
                return;
            _pool.Release(model);
        }

        private ObjectPool<LetterModel> CreatePool()
        {
            _pool = new ObjectPool<LetterModel>(() =>
            {
                var model = _createFunc();
                return model;
            }, model => { model.Active = true; }, model => { model.Active = false; });

            return _pool;
        }

        public void Clear()
        {
            for (int i = 0; i < ActiveElements.Count; i++)
            {
               _pool.Release(ActiveElements[i]);
            }
            
            ActiveElements.Clear();
        }
    }
}