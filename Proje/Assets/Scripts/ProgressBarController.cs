using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public GameObject progressBar;
    public GameObject healProgressBar;
    public SliderController slider;
    public HastaneSliderController hastaneSlider;
    public float savasciCreationTime = 1.5f;
    public float okcuCreationTime = 2.5f;
    public float mizrakciCreationTime = 4.5f;
    private float totalUnitAmount;
    public float savasciHealTime = 1.5f;
    public float okcuHealTime = 2.5f;
    public float mizrakciHealTime = 4.5f;

    private bool isProgressBarActive = false;

    public float time;
    public TextMeshProUGUI kalanZaman;
    void Start()
    {
        // Baþlangýçta zaman sýfýrlanabilir.
        time = 0;
    }

    public void CreateUnits()
    {
        // Üretim sürelerini toplamak için deðiþkenler
        float totalTime = 0;
        totalUnitAmount = 0;
        // Savaþçý slider'ýnýn deðeri varsa
        if (slider.savasciSlider.value > 0)
        {
            float savasciTime = slider.savasciSlider.value * savasciCreationTime;
            totalTime += savasciTime;
            totalUnitAmount += slider.savasciSlider.value;
        }

        // Okçu slider'ýnýn deðeri varsa
        if (slider.okcuSlider.value > 0)
        {
            float okcuTime = slider.okcuSlider.value * okcuCreationTime;
            totalTime += okcuTime;
            totalUnitAmount += slider.okcuSlider.value;
        }

        // Mýzrakçý slider'ýnýn deðeri varsa
        if (slider.mizrakciSlider.value > 0)
        {
            float mizrakciTime = slider.mizrakciSlider.value * mizrakciCreationTime;
            totalTime += mizrakciTime;
            totalUnitAmount += slider.mizrakciSlider.value;
        }

        // Tüm birimlerin toplam üretim süresi sýfýrdan büyükse progress bar'ý güncelle
        if (totalTime > 0)
        {
            // Eðer progress bar doluyorsa ve aktifse
            if (isProgressBarActive)
            {
                // Mevcut animasyonu durdur
                LeanTween.cancel(progressBar);             
                // Progress bar'ý sýfýrla
                ResetProgressBar();
                isProgressBarActive = false;
                totalUnitAmount = 0;
            }
            else
            {
                // Progress bar'ý baþlat
                isProgressBarActive = true; // Progress bar aktif
                LeanTween.scaleX(progressBar, 1, totalTime)
                    .setOnComplete(() =>
                    {
                        // Progress bar dolduðunda yapýlacak iþlemler
                        OnProgressComplete();
                        isProgressBarActive = false; // Progress bar artýk aktif deðil
                        ResetProgressBar(); // Progress bar'ý sýfýrlamak için çaðýr
                    });
            }
        }
    }

    void ResetProgressBar()
    {
        progressBar.transform.localScale = new Vector3(0, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
        // Ýsterseniz progress bar'ý yeniden kullanmak için baþka iþlemler de yapabilirsiniz
    }
    void OnProgressComplete()
    {
        // Burada progress bar dolduðunda yapýlacak iþlemleri tanýmla
        Debug.Log("Progress Bar doldu, iþlem gerçekleþtiriliyor!");
        Kingdom.myKingdom.SoldierAmount += totalUnitAmount;
        totalUnitAmount = 0;
        Debug.Log("Krallýðýnýzýn asker sayýsý:" + Kingdom.myKingdom.SoldierAmount);
    }

    void ResetHealProgressBar()
    {
        healProgressBar.transform.localScale = new Vector3(0, healProgressBar.transform.localScale.y, healProgressBar.transform.localScale.z);
        // Ýsterseniz progress bar'ý yeniden kullanmak için baþka iþlemler de yapabilirsiniz
    }

    public void HealUnits()
    {
        float totalHealTime = 0; // Toplam iyileþtirme süresi

        // HastaneSlider deðerlerini kontrol et
        if (hastaneSlider.savasciSlider.value > 0)
        {
            totalHealTime += hastaneSlider.savasciSlider.value * savasciHealTime;
        }

        if (hastaneSlider.okcuSlider.value > 0)
        {
            totalHealTime += hastaneSlider.okcuSlider.value * okcuHealTime;
        }

        if (hastaneSlider.mizrakciSlider.value > 0)
        {
            totalHealTime += hastaneSlider.mizrakciSlider.value * mizrakciHealTime;
        }

        // Toplam iyileþtirme süresi sýfýrdan büyükse progress bar'ý güncelle
        if (totalHealTime > 0)
        {
            LeanTween.scaleX(healProgressBar, 1, totalHealTime).setOnComplete(ResetHealProgressBar);
            Debug.Log("Toplam iyileþtirme süresi: " + totalHealTime);
        }
    }


}
