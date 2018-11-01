﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Manager of Stage Game
/// </summary>

namespace Assets.Scripts.ObjectsScene
{
    class SpawnPlatforms : MonoBehaviour{

        public int maxPlatform = 15;

        public GameObject platformObject;
        public GameObject platformSpike;
        public GameObject DogAndPlatform;
     
        //Scene manipulation
        public GameObject MountainPrefab;
        public GameObject SkyPrefab;
        public GameObject CoinPrefab;

        public float horizontalMin = 30.5991f;
        public float horizontalMax = 30.5992f;
        public float verticalMin = 6f;
        public float verticalMax = 6;

        public Vector3 originPosition;
        public Vector3 originPositionPlataform;
        public Vector3 originPositionSky;
        public Vector3 originPositionMountain;

        void Start(){
            originPosition = DogAndPlatform.transform.position;
            originPositionPlataform = platformObject.transform.position;
            originPositionSky = SkyPrefab.transform.position;
            originPositionMountain = MountainPrefab.transform.position;
            Spawn();
        }

        void Spawn(){
            for (int i = 0; i < maxPlatform; i++){
               
                //Origin Sample 
                //Vector3 randomPosition = originPosition +
                //    new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax),
                //                UnityEngine.Random.Range(verticalMin, verticalMax),10);
                //Instantiate(platform, randomPosition, Quaternion.identity);

                Vector3 randomPositionPrefabSky = originPositionSky
                          + new Vector3(7.0f, 0, 3);
                Instantiate(SkyPrefab, randomPositionPrefabSky, Quaternion.identity);
                originPositionSky = randomPositionPrefabSky;

                Vector3 randomPositionPrefabMountain = originPositionMountain
                         + new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax), 0, 2);
                Instantiate(MountainPrefab, randomPositionPrefabMountain, Quaternion.identity);
                originPositionMountain = randomPositionPrefabMountain;

                if (i % 3 == 0){

                    Debug.Log("\nOrigin Position SPIKE: i[" + i +"]: "+ originPosition);

                    Vector3 randomPosition = originPosition
                        + new Vector3(7.0f, 0, 0);
                    Instantiate(platformSpike, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;

                    //Ajustar coordenadas Z para que o alinhamento fique correto

                    //Vector3 randomPositionPrefab = randomPosition
                    //          + new Vector3(UnityEngine.Random.Range(horizontalMin, horizontalMax), 0, 0);
                    //Instantiate(SkyPrefab, randomPositionPrefab, Quaternion.identity);
                    //originPosition = randomPositionPrefab;
                    Debug.Log("\nRandom Position SPIKE: i[" + i + "]: " + randomPosition);
                }
                else if (i % 5 == 0 ){

                    Debug.Log("\nOrigin Position Dog: i[" + i + "]: " + originPosition);
                    Vector3 randomPosition = originPosition
                        + new Vector3(7.0f, 0, 0);
                    Instantiate(DogAndPlatform, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;
                    Debug.Log("\nRandom Position Dog: i[" + i + "]: " + randomPosition);

                   

                }
                //else if (i % 2 == 0 ){
                //    Debug.Log("\nOrigin Position Dog: i[" + i + "]: " + originPosition);

                //    Vector3 randomPosition = originPosition
                //        + new Vector3(7.0f, 0, 0);
                //    Instantiate(platformObject, randomPosition, Quaternion.identity);
                //    originPosition = randomPosition;

                //    Debug.Log("\nRandom Position Dog: i[" + i + "]: " + randomPosition);
                //}
                else{

                    Debug.Log("\nOrigin Position Object : i[" + i + "]: " + originPosition);

                    Vector3 randomPosition = originPosition +
                    new Vector3(7.0f, 0, 0);
                    Instantiate(platformObject, randomPosition, Quaternion.identity);
                    originPosition = randomPosition;
                    
                    Debug.Log("\nRandom Position Object : i[" + i + "]: " + randomPosition);
                }


            }
        }

    }
}
