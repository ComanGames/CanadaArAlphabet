using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Characters
{
    public class ArCharactersController:MonoBehaviour
    {
        public ArCharacter[] Characters;
        private Queue<ArCharacter> _charactersQueue;

        public void Start()
        {
            _charactersQueue = new Queue<ArCharacter>();

            foreach (ArCharacter arCharacter in Characters)
                _charactersQueue.Enqueue(arCharacter);
        }

        public ArCharacter GetCurrent()
        {
            if (_charactersQueue.Count == 0)
                return null;
            return _charactersQueue.Peek();
        }
        public void MoveNext()
        {
            _charactersQueue.Dequeue().IsActive = true;

        }

        public void SetCharacterDetected(Action<ArCharacter> characterDetected)
        {
            foreach (ArCharacter arCharacter in Characters)
            {
                arCharacter.CharacterDetected = characterDetected;
            }

        }
    }
}