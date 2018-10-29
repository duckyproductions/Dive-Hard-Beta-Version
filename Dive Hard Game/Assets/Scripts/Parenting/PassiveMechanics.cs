using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PassiveMechanics : StoreObjectsParent {

    public override void Start()
    {
        Execution();
    }

    protected abstract void Execution();


    protected override void Action() { }
    protected override IEnumerator Activation(Player _jugador) { yield return null; }
    protected override void BackToPool() { }
    protected override void DistancePooling() { }
    protected override void FixedUpdate() { }
    protected override void OnTriggerEnter2D(Collider2D collision) { }
  
}
