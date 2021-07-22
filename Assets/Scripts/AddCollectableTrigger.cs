using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollectableTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CollectableProperties>() == null)
            return;

        if(!other.gameObject.GetComponent<CollectableProperties>().enabled)
            return;

        ScoreManager.instance.Add(other.gameObject.GetComponent<CollectableProperties>());
        ScoreManager.instance.collectedObjects[ScoreManager.instance.FinalIndex()].goldQuantity = other.gameObject.GetComponent<CollectableProperties>().goldQuantity;
        ScoreManager.instance.collectedObjects[ScoreManager.instance.FinalIndex()].silverQuantity = other.gameObject.GetComponent<CollectableProperties>().silverQuantity;
        ScoreManager.instance.collectedObjects[ScoreManager.instance.FinalIndex()].copperQuantity = other.gameObject.GetComponent<CollectableProperties>().copperQuantity;
        ScoreManager.instance.collectedObjects[ScoreManager.instance.FinalIndex()].emeraldQuantity = other.gameObject.GetComponent<CollectableProperties>().emeraldQuantity;
        ScoreManager.instance.collectedObjects[ScoreManager.instance.FinalIndex()].diamondQuality = other.gameObject.GetComponent<CollectableProperties>().diamondQuality;
        ScoreManager.instance.collectedObjects[ScoreManager.instance.FinalIndex()].charge = other.gameObject.GetComponent<CollectableProperties>().charge;
        ScoreManager.instance.collectedObjects[ScoreManager.instance.FinalIndex()].isDiamagnetic = other.gameObject.GetComponent<CollectableProperties>().isDiamagnetic;
        ScoreManager.instance.collectedObjects[ScoreManager.instance.FinalIndex()].isMagnetic = other.gameObject.GetComponent<CollectableProperties>().isMagnetic;

        other.gameObject.GetComponent<CollectableProperties>().enabled = false;
        other.gameObject.GetComponent<CollectableProperties>().isMagnetic = false;
        other.gameObject.tag = "Untagged";
    }
}
