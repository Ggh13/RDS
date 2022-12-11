using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class move : player_stats
{
    public mouseDetect md;



    public float rot_speed = 1f;
    public float turn_speed = 1f;
    public float turn_speed2 = 1f;
    public float turn_speed3 = 1f;
    public GameObject skin;
    public float my_rote;
    public Quaternion end_pos;
    public float progress = 0;
    public float steps = 0.01f;
    public float y_rot;
    public CharacterController my_body;

    public Animator my_anim;

 


    public inputKeys inputKeys;
    public Vector3 go;
    // Start is called before the first frame update
    void Start()
    {
        y_rot = transform.rotation.y;
        turn_speed = 0;
        my_body = transform.gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
/*
void FixedUpdate()
{

    float translation = inputKeys.translation;
    float rotation = inputKeys.rotation;

    rotate();
    move_(translation, rotation);
    stamina_res();
}
public void stamina_res()
{
    if (stamina < 1)
        stamina = 0;
    else if (stamina > max_stamina)
    {
        stamina = max_stamina;
    }


    stamina_slider.value = (stamina / max_stamina) * 100;

    if (last_stamina > stamina)
    {
        res = false;
        timer_stamina = Time.time + timer_res_stamina;
        last_stamina = stamina;
    }
    else if (timer_stamina <= Time.time)
    {
        last_stamina = stamina;
        res = true;
        if (last_stamina == stamina)
        {
            stamina += stamina_res_count;
        }
    }
}
public void rotate()
{
   Debug.Log(transform.rotation.y.ToString() + "        " +  (y_rot).ToString());
    y_rot = y_rot + md.deltaMousePositionX * rot_speed;
    transform.rotation = Quaternion.Euler(transform.rotation.x, y_rot, transform.rotation.z);
}
/*
private void move_(float trans, float rot)
{
    go = new Vector3(0, 0, 0);
    //Debug.Log(trans / move_speed);
    if (Mathf.Abs(trans) >= 0.9f * move_speed) { 
           go += new Vector3(0, 0, trans);
    }
    if (Mathf.Abs(rot) >= 0.05f * move_speed)
    {
        go += new Vector3(rot, 0, 0);
    }


    if (Mathf.Abs(rot) + Mathf.Abs(trans) > 0)
    {

        if (Input.GetKey(KeyCode.LeftShift))
        {
            go = go * (run_speed / move_speed);
            my_anim.SetBool("run", true);
            my_anim.SetBool("walk", false);
           //stamina -= exp_run_exp;
        }
        else
        {
            my_anim.SetBool("run", false);
            my_anim.SetBool("walk", true);
        }
    }
    else
    {
        turn_speed = 0;
        my_anim.SetBool("run", false);
        my_anim.SetBool("walk", false);
    }

    go = go.normalized;


    Vector3 start = (skin.transform.position - new Vector3(0, skin.transform.position.y, 0));
    Vector3 end = ((skin.transform.position + (go * turn_speed3) - new Vector3(0, skin.transform.position.y, 0)) * turn_speed3);

    if (go != Vector3.zero)
    {
        Quaternion desiredRotation = Quaternion.LookRotation(go, Vector3.up);

        Quaternion deltaRotate = Quaternion.Lerp(transform.rotation, desiredRotation, rot_speed);

        transform.rotation = deltaRotate;
    }
    my_body.Move((go - new Vector3(0, graviry, 0)) * move_speed);
}
*/
}
