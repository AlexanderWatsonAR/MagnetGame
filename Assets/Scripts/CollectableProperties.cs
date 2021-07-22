using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CollectableProperties : MonoBehaviour
{
    public float goldQuantity;
    public float silverQuantity;
    public float copperQuantity;
    public float emeraldQuantity;
    public float diamondQuality;
    public float charge;
    public bool isDiamagnetic;
    public bool isMagnetic;
}
public class CollectablePropertiesStereo
{
    public float goldQuantity;
    public float silverQuantity;
    public float copperQuantity;
    public float emeraldQuantity;
    public float diamondQuality;
    public float charge;
    public bool isDiamagnetic;
    public bool isMagnetic;

    public CollectablePropertiesStereo(float gold, float silver, float copper, float emerald, float diamond, float charge, bool isDiamagnetic, bool isMagnetic)
    {
        goldQuantity = gold;
        silverQuantity = silver;
        copperQuantity = copper;
        emeraldQuantity = emerald;
        diamondQuality = diamond;
        this.charge = charge;
        this.isDiamagnetic = isDiamagnetic;
        this.isMagnetic = isMagnetic;
    }

    public CollectablePropertiesStereo(CollectableProperties collectableProperties)
    {
        new CollectablePropertiesStereo(collectableProperties.goldQuantity, collectableProperties.silverQuantity, collectableProperties.copperQuantity, collectableProperties.emeraldQuantity, collectableProperties.diamondQuality, collectableProperties.charge, collectableProperties.isDiamagnetic, collectableProperties.isMagnetic);
    }
}

