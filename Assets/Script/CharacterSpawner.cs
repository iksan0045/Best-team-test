using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameplayTest
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject[] playerPrefab;

        [SerializeField]
        private GameObject[] _npcChar;

        [SerializeField]
        private Transform npcSpawnPos;

        [SerializeField]
        private Transform spawnPos;

        [SerializeField]
        private Dropdown characterDropdown;



        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SpawnCharacter()
        {

            int characterID = characterDropdown.value;
            if (characterID >= 1)
            {
                GameObject newCharacter = Instantiate(playerPrefab[1], spawnPos.position, Quaternion.identity);
                CharacterPlayer characterController = newCharacter.GetComponent<CharacterPlayer>();
                characterController.SetAsPlayer();
                if (characterController != null)
                {
                    if (characterID > 1)
                    {
                        Instantiate(_npcChar[characterID], npcSpawnPos.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(_npcChar[UnityEngine.Random.Range(0,1)], npcSpawnPos.position, Quaternion.identity);
                    }
                }
            }
            else
            {
                Instantiate(playerPrefab[0], spawnPos.position, Quaternion.identity);
            }

        }

        public void ResetChar()
        {
            SceneManager.LoadScene(0);
        }
    }
}
