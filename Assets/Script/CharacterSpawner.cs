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
        private GameObject playerPrefab;

        [SerializeField]
        private GameObject npcPrefab;

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
            GameObject newCharacter = Instantiate(playerPrefab, spawnPos.position, Quaternion.identity);
            int characterID = characterDropdown.value;
            // Set ID karakter pada objek karakter yang baru di-spawn.
            CharacterPlayer characterController = newCharacter.GetComponent<CharacterPlayer>();
            if (characterController != null)
            {
                characterController.SetCharacterId(characterID);

                Instantiate(npcPrefab, npcSpawnPos.position, Quaternion.identity);

            }
        }

        public void ResetChar()
        {
            SceneManager.LoadScene(0);
        }
    }
}
