using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_controller : MonoBehaviour {

    GameObject mapa;

    public int next_global_respaw;    
    List<GameObject> enemies ;
    public posiciones[] positions;
    public int respaw_per_position;

    public int number_of_enemies;

    bool level_finished;
    public int rounds;

    public GameObject prefab_de_mierda;

    // Use this for initialization
    void Start() {
        number_of_enemies = 20;
        next_global_respaw = 40;
        respaw_per_position = 5;
        mapa = GameObject.FindGameObjectWithTag("base_map");
        positions = new posiciones[] { posiciones.arriba, posiciones.derecha, posiciones.izquierda, posiciones.abajo };
        init_enemies();
        respaw_enemies_delay();               
    }

    // Update is called once per frame
    void Update() {
        
    }

    void init_enemies() {

        for (int index = 0; index < number_of_enemies; index++) {
            GameObject enemigo = GameObject.FindGameObjectWithTag("enemy_mele");
            //enemies.Add(enemigo.GetComponent<Enemy_mele>());
            
            enemies.Add(prefab_de_mierda);
        }
    }


    public void respaw_enemies_delay() {
        while (!level_finished )
        {
            if (rounds != 0)
            {
                wait_delay(next_global_respaw);
                respawn_enemies(0);
            }
            else {
                level_finished = true;
            }        
        }
    }

    public void respawn_enemies(int callback_parameter) {
        int enemies_per_position = (callback_parameter >0) ? callback_parameter  : Mathf.RoundToInt(enemies.Count / positions.Length);
        int enemies_remaining = (enemies_per_position == enemies.Count) ? 0 : enemies.Count - enemies_per_position;

        for (int index_position = 0; index_position < positions.Length; index_position++)
        {
            wait_delay(respaw_per_position);
            for (int index = 0; index < enemies_per_position; index++)
            {
                GameObject enemigo = enemies[index];
                //if (!enemigo.alive) { continue; }
                //enemigo.alive = true;
                instanciate_enemy(enemigo , calculate_position(index_position));
            }
        }
        if (enemies_remaining > 0) { respawn_enemies(enemies_remaining); }
        rounds--;
    }


    public void wait_delay(int delay) {

    }

    public void instanciate_enemy(GameObject enemigo , Vector2 position) {
        //GameObject nemico = GameObject.FindGameObjectWithTag("enemy_mele");
        Instantiate(enemigo, position , Quaternion.identity);
    }

    public Vector2 calculate_position(int position) {
        Vector2 posicion_respawn = new Vector2();
        if (position == (int) posiciones.arriba) { posicion_respawn = new Vector2(Random.Range(0, mapa.transform.localScale.x), mapa.transform.localScale.y); }
        if (position == (int)posiciones.abajo) { posicion_respawn = new Vector2(Random.Range(0, mapa.transform.localScale.x), -mapa.transform.localScale.y); }
        if (position == (int)posiciones.derecha) { posicion_respawn = new Vector2(mapa.transform.localScale.x, Random.Range(0, mapa.transform.localScale.y)); }
        if (position == (int)posiciones.izquierda) { posicion_respawn = new Vector2(-mapa.transform.localScale.x, Random.Range(0, mapa.transform.localScale.y)); }
        return posicion_respawn;
    }

    public enum posiciones{
     arriba = 1,
     abajo = 2,
     derecha = 3,
     izquierda = 4
    }

}
