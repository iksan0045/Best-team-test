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
        private GameObject _npcChar;

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
            // Buat karakter baru dari prefab.
            int characterID = characterDropdown.value;
            GameObject newCharacter = Instantiate(playerPrefab[characterID], spawnPos.position, Quaternion.identity);
            
            // Set ID karakter pada objek karakter yang baru di-spawn.
            CharacterPlayer characterController = newCharacter.GetComponent<CharacterPlayer>();
            characterController.SetAsPlayer();
            if (characterController != null)
            {
                int randomNpc = UnityEngine.Random.Range(1,playerPrefab.Length);
                Instantiate(_npcChar, npcSpawnPos.position, Quaternion.identity);
            
            }
        }

        public void ResetChar()
        {
            SceneManager.LoadScene(0);
        }
    }
}
