using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomScrripf : Rod
{
    [SerializeField] private AudioSource noSound;
public Sprite manhVun;
public void Bang(Vector2 pos, bool flag = false){
var hits = Physics2D.CircleCastAll(pos, 3,Vector2.zero);
foreach(var hit in hits){
    if(hit.transform.tag == Config.TAG_GOLD){
        Destroy(hit.transform.gameObject);
    }else if(hit.transform.tag== Config.TAG_BOOM){
        hit.transform.tag = Config.TAG_GOLD;
       hit.transform.GetComponent<BoomScrripf>().Bang(hit.point, true);
    }
}
if(flag){
    Destroy(gameObject);
}
}
void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.tag == "Pod"){
        this.gameObject.GetComponent<SpriteRenderer>().sprite = manhVun;
        noSound.Play();
    }
}
}
