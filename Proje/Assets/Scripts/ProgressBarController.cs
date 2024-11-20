using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarController : MonoBehaviour
{
    public GameObject progressBar;
    public GameObject healProgressBar;
    public GameObject buildWareHouseBar;
    public GameObject buildStonepitBar;
    public GameObject buildSawmillBar;
    public GameObject buildFarmBar;
    public GameObject buildBlacksmithBar;
    public GameObject buildLabBar;
    public GameObject buildBarracksBar;
    public GameObject buildHospitalBar;


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


    public WareHousePanelController wareHousePanelController;
    public StonepitPanelController stonepitPanelController;
    public SawmillPanelController sawmillPanelController;
    public FarmPanelController farmPanelController;
    public BlacksmithPanelController blacksmithPanelController;
    public LabPanelController labPanelController;
    public BarracksPanelController barracksPanelController;
    public HospitalPanelController hospitalPanelController;

    public float time;
    public TextMeshProUGUI kalanZaman;
    void Start()
    {
        // Ba�lang��ta zaman s�f�rlanabilir.
        time = 0;
    }

    public void CreateUnits()
    {
        if(Barracks.wasBarracksCreated == true)
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
                    ResetProgressBar(progressBar);
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
                            ResetProgressBar(progressBar); // Progress bar'� s�f�rlamak i�in �a��r
                        });
                }
            }
        }
        else
        {
            Debug.Log("�ncelikle bir k��la �retmelisiniz.");
        }
        
    }

    void ResetProgressBar(GameObject gameObject)
    {
        gameObject.transform.localScale = new Vector3(0, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
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


    public void HealUnits()
    {
        if(Hospital.wasHospitalCreated == true)
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
                LeanTween.scaleX(healProgressBar, 1, totalHealTime).setOnComplete(() => ResetProgressBar(healProgressBar));
                Debug.Log("Toplam iyile�tirme s�resi: " + totalHealTime);
            }
        }
        else
        {
            Debug.Log("�ncelikle hastane in�a etmelisiniz.");
        }
    }


    public IEnumerator WarehouseIsFinished(Warehouse warehouse, System.Action<bool> onCompletion)
    {
        wareHousePanelController.cancelWarehouseButton.gameObject.SetActive(true);
        wareHousePanelController.isBuildCanceled = false; // �ptal durumu s�f�rla
       
        // LeanTween animasyonu ba�lat

        LeanTween.scaleX(buildWareHouseBar, 1, warehouse.buildTime).setOnComplete(() => ResetProgressBar(buildWareHouseBar));

        float elapsedTime = 0f; // Ge�en zaman� takip et

        while (elapsedTime < warehouse.buildTime)
        {
            if (wareHousePanelController.isBuildCanceled) // E�er iptal edilirse
            {
                LeanTween.cancel(buildWareHouseBar); // Animasyonu iptal et
                ResetProgressBar(buildWareHouseBar); // ProgressBar'� s�f�rla
                onCompletion(false); // Ba�ar�s�zl�k durumunu bildir
                yield break; // Coroutine sonland�r
            }

            elapsedTime += Time.deltaTime; // Ge�en s�reyi art�r
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // �ptal edilmeden tamamland�ysa
        wareHousePanelController.cancelWarehouseButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamland���nda ba�ar�l� olarak bildir
    }

    public IEnumerator StonePitIsFinished(StonePit stonepit, System.Action<bool> onCompletion)
    {
        stonepitPanelController.cancelStonepitButton.gameObject.SetActive(true);
        stonepitPanelController.isBuildCanceled = false; // �ptal durumu s�f�rla

        // LeanTween animasyonu ba�lat

        LeanTween.scaleX(buildStonepitBar, 1, stonepit.buildTime).setOnComplete(() => ResetProgressBar(buildStonepitBar));

        float elapsedTime = 0f; // Ge�en zaman� takip et

        while (elapsedTime < stonepit.buildTime)
        {
            if (stonepitPanelController.isBuildCanceled) // E�er iptal edilirse
            {
                LeanTween.cancel(buildStonepitBar); // Animasyonu iptal et
                ResetProgressBar(buildStonepitBar); // ProgressBar'� s�f�rla
                onCompletion(false); // Ba�ar�s�zl�k durumunu bildir
                yield break; // Coroutine sonland�r
            }

            elapsedTime += Time.deltaTime; // Ge�en s�reyi art�r
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // �ptal edilmeden tamamland�ysa
        stonepitPanelController.cancelStonepitButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamland���nda ba�ar�l� olarak bildir

    }

    public IEnumerator SawmillIsFinished(Sawmill sawmill, System.Action<bool> onCompletion)
    {
        sawmillPanelController.cancelSawmillButton.gameObject.SetActive(true);
        sawmillPanelController.isBuildCanceled = false; // �ptal durumu s�f�rla

        // LeanTween animasyonu ba�lat

        LeanTween.scaleX(buildSawmillBar, 1, sawmill.buildTime).setOnComplete(() => ResetProgressBar(buildSawmillBar));

        float elapsedTime = 0f; // Ge�en zaman� takip et

        while (elapsedTime < sawmill.buildTime)
        {
            if (sawmillPanelController.isBuildCanceled) // E�er iptal edilirse
            {
                LeanTween.cancel(buildSawmillBar); // Animasyonu iptal et
                ResetProgressBar(buildSawmillBar); // ProgressBar'� s�f�rla
                onCompletion(false); // Ba�ar�s�zl�k durumunu bildir
                yield break; // Coroutine sonland�r
            }

            elapsedTime += Time.deltaTime; // Ge�en s�reyi art�r
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // �ptal edilmeden tamamland�ysa
        sawmillPanelController.cancelSawmillButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamland���nda ba�ar�l� olarak bildir
    }

    public IEnumerator FarmIsFinished(Farm farm, System.Action<bool> onCompletion)
    {
        farmPanelController.cancelFarmButton.gameObject.SetActive(true);
        farmPanelController.isBuildCanceled = false; // �ptal durumu s�f�rla

        // LeanTween animasyonu ba�lat
        LeanTween.scaleX(buildFarmBar, 1, farm.buildTime).setOnComplete(() => ResetProgressBar(buildFarmBar));

        float elapsedTime = 0f; // Ge�en zaman� takip et

        while (elapsedTime < farm.buildTime)
        {
            if (farmPanelController.isBuildCanceled) // E�er iptal edilirse
            {
                LeanTween.cancel(buildFarmBar); // Animasyonu iptal et
                ResetProgressBar(buildFarmBar); // ProgressBar'� s�f�rla
                onCompletion(false); // Ba�ar�s�zl�k durumunu bildir
                yield break; // Coroutine sonland�r
            }

            elapsedTime += Time.deltaTime; // Ge�en s�reyi art�r
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // �ptal edilmeden tamamland�ysa
        farmPanelController.cancelFarmButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamland���nda ba�ar�l� olarak bildir
    }


    public IEnumerator BlacksmithIsFinished(Blacksmith blacksmith, System.Action<bool> onCompletion)
    {
        blacksmithPanelController.cancelBlacksmithButton.gameObject.SetActive(true);
        blacksmithPanelController.isBuildCanceled = false; // �ptal durumu s�f�rla

        // LeanTween animasyonu ba�lat
        LeanTween.scaleX(buildBlacksmithBar, 1, blacksmith.buildTime).setOnComplete(() => ResetProgressBar(buildBlacksmithBar));

        float elapsedTime = 0f; // Ge�en zaman� takip et

        while (elapsedTime < blacksmith.buildTime)
        {
            if (blacksmithPanelController.isBuildCanceled) // E�er iptal edilirse
            {
                LeanTween.cancel(buildBlacksmithBar); // Animasyonu iptal et
                ResetProgressBar(buildBlacksmithBar); // ProgressBar'� s�f�rla
                onCompletion(false); // Ba�ar�s�zl�k durumunu bildir
                yield break; // Coroutine sonland�r
            }

            elapsedTime += Time.deltaTime; // Ge�en s�reyi art�r
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // �ptal edilmeden tamamland�ysa
        blacksmithPanelController.cancelBlacksmithButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamland���nda ba�ar�l� olarak bildir
    }

    public IEnumerator LabIsFinished(Lab lab, System.Action<bool> onCompletion)
    {
        labPanelController.cancelLabButton.gameObject.SetActive(true);
        labPanelController.isBuildCanceled = false; // �ptal durumu s�f�rla

        // LeanTween animasyonu ba�lat
        LeanTween.scaleX(buildLabBar, 1, lab.buildTime).setOnComplete(() => ResetProgressBar(buildLabBar));

        float elapsedTime = 0f; // Ge�en zaman� takip et

        while (elapsedTime < lab.buildTime)
        {
            if (labPanelController.isBuildCanceled) // E�er iptal edilirse
            {
                LeanTween.cancel(buildLabBar); // Animasyonu iptal et
                ResetProgressBar(buildLabBar); // ProgressBar'� s�f�rla
                onCompletion(false); // Ba�ar�s�zl�k durumunu bildir
                yield break; // Coroutine sonland�r
            }

            elapsedTime += Time.deltaTime; // Ge�en s�reyi art�r
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // �ptal edilmeden tamamland�ysa
        labPanelController.cancelLabButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamland���nda ba�ar�l� olarak bildir
    }

    public IEnumerator BarracksIsFinished(Barracks barracks, System.Action<bool> onCompletion)
    {
        barracksPanelController.cancelBarracksButton.gameObject.SetActive(true);
        barracksPanelController.isBuildCanceled = false; // �ptal durumu s�f�rla

        // LeanTween animasyonu ba�lat
        LeanTween.scaleX(buildBarracksBar, 1, barracks.buildTime).setOnComplete(() => ResetProgressBar(buildBarracksBar));

        float elapsedTime = 0f; // Ge�en zaman� takip et

        while (elapsedTime < barracks.buildTime)
        {
            if (barracksPanelController.isBuildCanceled) // E�er iptal edilirse
            {
                LeanTween.cancel(buildBarracksBar); // Animasyonu iptal et
                ResetProgressBar(buildBarracksBar); // ProgressBar'� s�f�rla
                onCompletion(false); // Ba�ar�s�zl�k durumunu bildir
                yield break; // Coroutine sonland�r
            }

            elapsedTime += Time.deltaTime; // Ge�en s�reyi art�r
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // �ptal edilmeden tamamland�ysa
        barracksPanelController.cancelBarracksButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamland���nda ba�ar�l� olarak bildir
    }

    public IEnumerator HospitalIsFinished(Hospital hospital, System.Action<bool> onCompletion)
    {
        hospitalPanelController.cancelHospitalButton.gameObject.SetActive(true);
        hospitalPanelController.isBuildCanceled = false; // �ptal durumu s�f�rla

        // LeanTween animasyonu ba�lat
        LeanTween.scaleX(buildHospitalBar, 1, hospital.buildTime).setOnComplete(() => ResetProgressBar(buildHospitalBar));

        float elapsedTime = 0f; // Ge�en zaman� takip et

        while (elapsedTime < hospital.buildTime)
        {
            if (hospitalPanelController.isBuildCanceled) // E�er iptal edilirse
            {
                LeanTween.cancel(buildHospitalBar); // Animasyonu iptal et
                ResetProgressBar(buildHospitalBar); // ProgressBar'� s�f�rla
                onCompletion(false); // Ba�ar�s�zl�k durumunu bildir
                yield break; // Coroutine sonland�r
            }

            elapsedTime += Time.deltaTime; // Ge�en s�reyi art�r
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // �ptal edilmeden tamamland�ysa
        hospitalPanelController.cancelHospitalButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamland���nda ba�ar�l� olarak bildir
    }
}
