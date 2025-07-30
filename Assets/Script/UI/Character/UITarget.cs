using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITarget : UIFollow
{
    protected BaseCharacter owner;

    public void Initialized(BaseCharacter baseCharacter)
    {
        owner = baseCharacter;

        if (!owner)
        {
            OnHide();
            return;
        }

        followAt = owner.ReferencePoints.uiCharacterTransfrom;
        UpdatePosition();
        OnShow();
    }
}
