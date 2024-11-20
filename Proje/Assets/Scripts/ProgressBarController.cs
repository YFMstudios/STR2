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
        // Baþlangýçta zaman sýfýrlanabilir.
        time = 0;
    }

    public void CreateUnits()
    {
        if(Barracks.wasBarracksCreated == true)
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
                    ResetProgressBar(progressBar);
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
                            ResetProgressBar(progressBar); // Progress bar'ý sýfýrlamak için çaðýr
                        });
                }
            }
        }
        else
        {
            Debug.Log("Öncelikle bir kýþla üretmelisiniz.");
        }
        
    }

    void ResetProgressBar(GameObject gameObject)
    {
        gameObject.transform.localScale = new Vector3(0, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
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


    public void HealUnits()
    {
        if(Hospital.wasHospitalCreated == true)
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
                LeanTween.scaleX(healProgressBar, 1, totalHealTime).setOnComplete(() => ResetProgressBar(healProgressBar));
                Debug.Log("Toplam iyileþtirme süresi: " + totalHealTime);
            }
        }
        else
        {
            Debug.Log("Öncelikle hastane inþa etmelisiniz.");
        }
    }


    public IEnumerator WarehouseIsFinished(Warehouse warehouse, System.Action<bool> onCompletion)
    {
        wareHousePanelController.cancelWarehouseButton.gameObject.SetActive(true);
        wareHousePanelController.isBuildCanceled = false; // Ýptal durumu sýfýrla
       
        // LeanTween animasyonu baþlat

        LeanTween.scaleX(buildWareHouseBar, 1, warehouse.buildTime).setOnComplete(() => ResetProgressBar(buildWareHouseBar));

        float elapsedTime = 0f; // Geçen zamaný takip et

        while (elapsedTime < warehouse.buildTime)
        {
            if (wareHousePanelController.isBuildCanceled) // Eðer iptal edilirse
            {
                LeanTween.cancel(buildWareHouseBar); // Animasyonu iptal et
                ResetProgressBar(buildWareHouseBar); // ProgressBar'ý sýfýrla
                onCompletion(false); // Baþarýsýzlýk durumunu bildir
                yield break; // Coroutine sonlandýr
            }

            elapsedTime += Time.deltaTime; // Geçen süreyi artýr
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // Ýptal edilmeden tamamlandýysa
        wareHousePanelController.cancelWarehouseButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamlandýðýnda baþarýlý olarak bildir
    }

    public IEnumerator StonePitIsFinished(StonePit stonepit, System.Action<bool> onCompletion)
    {
        stonepitPanelController.cancelStonepitButton.gameObject.SetActive(true);
        stonepitPanelController.isBuildCanceled = false; // Ýptal durumu sýfýrla

        // LeanTween animasyonu baþlat

        LeanTween.scaleX(buildStonepitBar, 1, stonepit.buildTime).setOnComplete(() => ResetProgressBar(buildStonepitBar));

        float elapsedTime = 0f; // Geçen zamaný takip et

        while (elapsedTime < stonepit.buildTime)
        {
            if (stonepitPanelController.isBuildCanceled) // Eðer iptal edilirse
            {
                LeanTween.cancel(buildStonepitBar); // Animasyonu iptal et
                ResetProgressBar(buildStonepitBar); // ProgressBar'ý sýfýrla
                onCompletion(false); // Baþarýsýzlýk durumunu bildir
                yield break; // Coroutine sonlandýr
            }

            elapsedTime += Time.deltaTime; // Geçen süreyi artýr
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // Ýptal edilmeden tamamlandýysa
        stonepitPanelController.cancelStonepitButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamlandýðýnda baþarýlý olarak bildir

    }

    public IEnumerator SawmillIsFinished(Sawmill sawmill, System.Action<bool> onCompletion)
    {
        sawmillPanelController.cancelSawmillButton.gameObject.SetActive(true);
        sawmillPanelController.isBuildCanceled = false; // Ýptal durumu sýfýrla

        // LeanTween animasyonu baþlat

        LeanTween.scaleX(buildSawmillBar, 1, sawmill.buildTime).setOnComplete(() => ResetProgressBar(buildSawmillBar));

        float elapsedTime = 0f; // Geçen zamaný takip et

        while (elapsedTime < sawmill.buildTime)
        {
            if (sawmillPanelController.isBuildCanceled) // Eðer iptal edilirse
            {
                LeanTween.cancel(buildSawmillBar); // Animasyonu iptal et
                ResetProgressBar(buildSawmillBar); // ProgressBar'ý sýfýrla
                onCompletion(false); // Baþarýsýzlýk durumunu bildir
                yield break; // Coroutine sonlandýr
            }

            elapsedTime += Time.deltaTime; // Geçen süreyi artýr
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // Ýptal edilmeden tamamlandýysa
        sawmillPanelController.cancelSawmillButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamlandýðýnda baþarýlý olarak bildir
    }

    public IEnumerator FarmIsFinished(Farm farm, System.Action<bool> onCompletion)
    {
        farmPanelController.cancelFarmButton.gameObject.SetActive(true);
        farmPanelController.isBuildCanceled = false; // Ýptal durumu sýfýrla

        // LeanTween animasyonu baþlat
        LeanTween.scaleX(buildFarmBar, 1, farm.buildTime).setOnComplete(() => ResetProgressBar(buildFarmBar));

        float elapsedTime = 0f; // Geçen zamaný takip et

        while (elapsedTime < farm.buildTime)
        {
            if (farmPanelController.isBuildCanceled) // Eðer iptal edilirse
            {
                LeanTween.cancel(buildFarmBar); // Animasyonu iptal et
                ResetProgressBar(buildFarmBar); // ProgressBar'ý sýfýrla
                onCompletion(false); // Baþarýsýzlýk durumunu bildir
                yield break; // Coroutine sonlandýr
            }

            elapsedTime += Time.deltaTime; // Geçen süreyi artýr
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // Ýptal edilmeden tamamlandýysa
        farmPanelController.cancelFarmButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamlandýðýnda baþarýlý olarak bildir
    }


    public IEnumerator BlacksmithIsFinished(Blacksmith blacksmith, System.Action<bool> onCompletion)
    {
        blacksmithPanelController.cancelBlacksmithButton.gameObject.SetActive(true);
        blacksmithPanelController.isBuildCanceled = false; // Ýptal durumu sýfýrla

        // LeanTween animasyonu baþlat
        LeanTween.scaleX(buildBlacksmithBar, 1, blacksmith.buildTime).setOnComplete(() => ResetProgressBar(buildBlacksmithBar));

        float elapsedTime = 0f; // Geçen zamaný takip et

        while (elapsedTime < blacksmith.buildTime)
        {
            if (blacksmithPanelController.isBuildCanceled) // Eðer iptal edilirse
            {
                LeanTween.cancel(buildBlacksmithBar); // Animasyonu iptal et
                ResetProgressBar(buildBlacksmithBar); // ProgressBar'ý sýfýrla
                onCompletion(false); // Baþarýsýzlýk durumunu bildir
                yield break; // Coroutine sonlandýr
            }

            elapsedTime += Time.deltaTime; // Geçen süreyi artýr
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // Ýptal edilmeden tamamlandýysa
        blacksmithPanelController.cancelBlacksmithButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamlandýðýnda baþarýlý olarak bildir
    }

    public IEnumerator LabIsFinished(Lab lab, System.Action<bool> onCompletion)
    {
        labPanelController.cancelLabButton.gameObject.SetActive(true);
        labPanelController.isBuildCanceled = false; // Ýptal durumu sýfýrla

        // LeanTween animasyonu baþlat
        LeanTween.scaleX(buildLabBar, 1, lab.buildTime).setOnComplete(() => ResetProgressBar(buildLabBar));

        float elapsedTime = 0f; // Geçen zamaný takip et

        while (elapsedTime < lab.buildTime)
        {
            if (labPanelController.isBuildCanceled) // Eðer iptal edilirse
            {
                LeanTween.cancel(buildLabBar); // Animasyonu iptal et
                ResetProgressBar(buildLabBar); // ProgressBar'ý sýfýrla
                onCompletion(false); // Baþarýsýzlýk durumunu bildir
                yield break; // Coroutine sonlandýr
            }

            elapsedTime += Time.deltaTime; // Geçen süreyi artýr
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // Ýptal edilmeden tamamlandýysa
        labPanelController.cancelLabButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamlandýðýnda baþarýlý olarak bildir
    }

    public IEnumerator BarracksIsFinished(Barracks barracks, System.Action<bool> onCompletion)
    {
        barracksPanelController.cancelBarracksButton.gameObject.SetActive(true);
        barracksPanelController.isBuildCanceled = false; // Ýptal durumu sýfýrla

        // LeanTween animasyonu baþlat
        LeanTween.scaleX(buildBarracksBar, 1, barracks.buildTime).setOnComplete(() => ResetProgressBar(buildBarracksBar));

        float elapsedTime = 0f; // Geçen zamaný takip et

        while (elapsedTime < barracks.buildTime)
        {
            if (barracksPanelController.isBuildCanceled) // Eðer iptal edilirse
            {
                LeanTween.cancel(buildBarracksBar); // Animasyonu iptal et
                ResetProgressBar(buildBarracksBar); // ProgressBar'ý sýfýrla
                onCompletion(false); // Baþarýsýzlýk durumunu bildir
                yield break; // Coroutine sonlandýr
            }

            elapsedTime += Time.deltaTime; // Geçen süreyi artýr
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // Ýptal edilmeden tamamlandýysa
        barracksPanelController.cancelBarracksButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamlandýðýnda baþarýlý olarak bildir
    }

    public IEnumerator HospitalIsFinished(Hospital hospital, System.Action<bool> onCompletion)
    {
        hospitalPanelController.cancelHospitalButton.gameObject.SetActive(true);
        hospitalPanelController.isBuildCanceled = false; // Ýptal durumu sýfýrla

        // LeanTween animasyonu baþlat
        LeanTween.scaleX(buildHospitalBar, 1, hospital.buildTime).setOnComplete(() => ResetProgressBar(buildHospitalBar));

        float elapsedTime = 0f; // Geçen zamaný takip et

        while (elapsedTime < hospital.buildTime)
        {
            if (hospitalPanelController.isBuildCanceled) // Eðer iptal edilirse
            {
                LeanTween.cancel(buildHospitalBar); // Animasyonu iptal et
                ResetProgressBar(buildHospitalBar); // ProgressBar'ý sýfýrla
                onCompletion(false); // Baþarýsýzlýk durumunu bildir
                yield break; // Coroutine sonlandýr
            }

            elapsedTime += Time.deltaTime; // Geçen süreyi artýr
            yield return null; // Bir sonraki kareye kadar bekle
        }

        // Ýptal edilmeden tamamlandýysa
        hospitalPanelController.cancelHospitalButton.gameObject.SetActive(false);
        onCompletion(true); // Tamamlandýðýnda baþarýlý olarak bildir
    }
}
