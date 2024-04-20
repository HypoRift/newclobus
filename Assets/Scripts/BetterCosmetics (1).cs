using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.VR;
using Photon.VR.Cosmetics;

public class BetterCosmetics : MonoBehaviour
{
    [Header("Made by Chroiud")]
    [Header("Give Credits")]

    public bool RightHandCosmetic;
    public bool LeftHandCosmetic;
    public bool HeadCosmetic;
    public bool BodyCosmetic;
    public bool FaceCosmetic;
    
    public string NameOfCosmetic;

    public string HandTag = "HandTag";

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == HandTag);
        {
            if(RightHandCosmetic == true)
            {
                PhotonVRManager.SetCosmetic(CosmeticType.RightHand, NameOfCosmetic);
            }
            if(LeftHandCosmetic == true)
            {
                PhotonVRManager.SetCosmetic(CosmeticType.LeftHand, NameOfCosmetic);
            }
            if(HeadCosmetic == true)
            {
                PhotonVRManager.SetCosmetic(CosmeticType.Head, NameOfCosmetic);
            }
            if(BodyCosmetic == true)
            {
                PhotonVRManager.SetCosmetic(CosmeticType.Body, NameOfCosmetic);
            }
            if(FaceCosmetic == true)
            {
                PhotonVRManager.SetCosmetic(CosmeticType.Face, NameOfCosmetic);
            }
        }
    }
}
