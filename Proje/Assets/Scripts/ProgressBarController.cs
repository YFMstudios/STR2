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
        // Ba�lang��ta zaman s�f�rlanabilir.
        time = 0;
    }

    public void CreateUnits()
    {
        // �retim s�relerini toplamak i�in de�i�kenler
        float totalTime = 0;
        totalUnitAmount = 0;
        // Sava��� slider'�n�n de�eri varsa
        if (slider.savasciSlider.value > 0)
        {
            float savasciTime = slider.savasciSlider.value * savasciCreationTime;
            totalTime += savasciTime;
            totalUnitAmount += slider.savasciSlider.value;
        }

        // Ok�u slider'�n�n de�eri varsa
        if (slider.okcuSlider.value > 0)
        {
            float okcuTime = slider.okcuSlider.value * okcuCreationTime;
            totalTime += okcuTime;
            totalUnitAmount += slider.okcuSlider.value;
        }

        // M�zrak�� slider'�n�n de�eri varsa
        if (slider.mizrakciSlider.value > 0)
        {
            float mizrakciTime = slider.mizrakciSlider.value * mizrakciCreationTime;
            totalTime += mizrakciTime;
            totalUnitAmount += slider.mizrakciSlider.value;
        }

        // T�m birimlerin toplam �retim s�resi s�f�rdan b�y�kse progress bar'� g�ncelle
        if (totalTime > 0)
        {
            // E�er progress bar doluyorsa ve aktifse
            if (isProgressBarActive)
            {
                // Mevcut animasyonu durdur
                LeanTween.cancel(progressBar);             
                // Progress bar'� s�f�rla
                ResetProgressBar();
                isProgressBarActive = false;
                totalUnitAmount = 0;
            }
            else
            {
                // Progress bar'� ba�lat
                isProgressBarActive = true; // Progress bar aktif
                LeanTween.scaleX(progressBar, 1, totalTime)
                    .setOnComplete(() =>
                    {
                        // Progress bar doldu�unda yap�lacak i�lemler
                        OnProgressComplete();
                        isProgressBarActive = false; // Progress bar art�k aktif de�il
                        ResetProgressBar(); // Progress bar'� s�f�rlamak i�in �a��r
                    });
            }
        }
    }

    void ResetProgressBar()
    {
        progressBar.transform.localScale = new Vector3(0, progressBar.transform.localScale.y, progressBar.transform.localScale.z);
        // �sterseniz progress bar'� yeniden kullanmak i�in ba�ka i�lemler de yapabilirsiniz
    }
    void OnProgressComplete()
    {
        // Burada progress bar doldu�unda yap�lacak i�lemleri tan�mla
        Debug.Log("Progress Bar doldu, i�lem ger�ekle�tiriliyor!");
        Kingdom.myKingdom.SoldierAmount += totalUnitAmount;
        totalUnitAmount = 0;
        Debug.Log("Krall���n�z�n asker say�s�:" + Kingdom.myKingdom.SoldierAmount);
    }

    void ResetHealProgressBar()
    {
        healProgressBar.transform.localScale = new Vector3(0, healProgressBar.transform.localScale.y, healProgressBar.transform.localScale.z);
        // �sterseniz progress bar'� yeniden kullanmak i�in ba�ka i�lemler de yapabilirsiniz
    }

    public void HealUnits()
    {
        float totalHealTime = 0; // Toplam iyile�tirme s�resi

        // HastaneSlider de�erlerini kontrol et
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

        // Toplam iyile�tirme s�resi s�f�rdan b�y�kse progress bar'� g�ncelle
        if (totalHealTime > 0)
        {
            LeanTween.scaleX(healProgressBar, 1, totalHealTime).setOnComplete(ResetHealProgressBar);
            Debug.Log("Toplam iyile�tirme s�resi: " + totalHealTime);
        }
    }


}
