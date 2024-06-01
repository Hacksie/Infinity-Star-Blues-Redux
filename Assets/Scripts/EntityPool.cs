using System.Collections.Generic;
using UnityEngine;
using System.Linq;


namespace HackedDesign
{
    public class EntityPool : MonoBehaviour
    {
        [Header("Game Objects")]
        [SerializeField] private List<GameObject> entityPrefabs;
        [SerializeField] private Transform entityParent;

        public static EntityPool Instance { get; private set; }

        private List<GameObject> entities = new List<GameObject>();

        EntityPool()
        {
            Instance = this;
        }

        public void Reset()
        {
            foreach(var entity in entities)
            {
                entity.gameObject.SetActive(false);
                Destroy(entity);
            }

            entities.Clear();
        }

        private void Add(GameObject entity)
        {
            entities.Add(entity);
        }   

        private void Remove(GameObject entity)
        {
            entities.Remove(entity);
        }

        private void Spawn(GameObject entityPrefab, Vector3 position, Quaternion rotation)
        {
            var gameObject = entities.FirstOrDefault(e => e.name == entityPrefab.name);
            if(gameObject == null)
            {
                gameObject = Instantiate(entityPrefab, position, rotation, entityParent);
                Add(gameObject);
            }
            else 
            {
                gameObject.transform.position = position;
                gameObject.transform.rotation = rotation;
                gameObject.SetActive(true);
            }
        }
    }
}