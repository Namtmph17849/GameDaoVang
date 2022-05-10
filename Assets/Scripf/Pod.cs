using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pod : MonoBehaviour
{
    public enum PodState{
        ROTATION,
        SHOOT,
        REWIND
    }
    [SerializeField] private int rotateSpeed = 1;
    PodState podState = PodState.ROTATION;
    private int angle;
    [SerializeField]private float speed;
    [SerializeField]private AudioSource congVangSound;
    private Vector3 Origin;
    private int _tien;
    private int _slowDown;
    private Transform _Rod;
    private bool _flag;
    public Text score;
    public GameObject no;
    public Animator anim;
    
    void OnTriggerEnter2D(Collider2D col) {
        if(_flag) return;        
        _flag = true;
        _Rod = col.transform;
        
        if(_Rod.tag == Config.TAG_BOOM){
        _Rod.tag = this.tag;
            _Rod.GetComponent<BoomScrripf>().Bang(_Rod.position);
             Instantiate(no, transform.position, Quaternion.identity);
             
        }
        _Rod.SetParent(transform);
         _slowDown = _Rod.GetComponent<Rod>().slowDown;
        _tien += _Rod.GetComponent<Rod>().tien;
         podState = PodState.REWIND;
         
    }
    // Start is called before the first frame update
    void Awake() {
        Origin = transform.position;
        score = GetComponent<Text>();
        anim = transform.root.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(podState){
            case PodState.ROTATION:

            anim.Play("onGiadungim");
            if(Input.GetKeyDown(KeyCode.Space))
                podState = PodState.SHOOT;
                angle += rotateSpeed;
            if(angle>80 || angle <-80)
            rotateSpeed *= -1;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            break;
            case PodState.SHOOT:
            anim.Play("ongGiakeo");
            transform.Translate(Vector3.down * speed * Time.deltaTime);
            if(Mathf.Abs(transform.position.x) >8 || transform.position.y <-4){
                podState = PodState.REWIND;
            }
            break;
            case PodState.REWIND:
            anim.Play("ongGiakeo");
            transform.Translate(Vector3.up *(speed - _slowDown) * Time.deltaTime);
            
            if(Mathf.Floor(transform.position.x) == Mathf.Floor(Origin.x)  && Mathf.Floor(transform.position.y)  == Mathf.Floor(Origin.y)){
                if(_Rod != null){
                _slowDown = 0;
                _flag = false;
                congVangSound.Play();
                Destroy(_Rod.gameObject);
                // setTien(_tien);
                ScoreScripf.scoreValue = _tien;
                }
                transform.position = Origin;
                // Destroy(_Rod.GetComponent<Rod>());
                podState = PodState.ROTATION;
            }
            break;
            
        }
        
    }
    // private void setTien(int tien){
    //     score.text = string.Format("$ {0}", tien);
    // }

}
