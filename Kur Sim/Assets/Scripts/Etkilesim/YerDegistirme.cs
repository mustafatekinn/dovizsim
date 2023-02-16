using UnityEngine.EventSystems;

using UnityEngine;
namespace StarterAssets
{
    public class YerDegistirme : MonoBehaviour, IPointerClickHandler
    {
        public int Objectcode;
        public GameObject DestroyedObje, BuildSystem, InputsObject, Canvas;
        enum DataType { Duzenle, Paketle };
        [SerializeField] DataType dataType;
        public GameObject Kutu, Location;
        public void OnPointerClick(PointerEventData eventData)
        {
            if (dataType == DataType.Duzenle)
            {
                var a = InputsObject.GetComponent<StarterAssetsInputs>();
                a.cursorInputForLook = true;
                a.cursorLocked = true;
                BuildSystem.GetComponent<BuildSystem>().Yapi();
                BuildSystem.GetComponent<BuildSystem>().Objectcode = Objectcode;
                BuildSystem.GetComponent<BuildSystem>().Yerlestiriyorum = true;
                Destroy(DestroyedObje);
                Canvas.SetActive(false);
            }
            if (dataType == DataType.Paketle)
            {
                var a = InputsObject.GetComponent<StarterAssetsInputs>();
                a.cursorInputForLook = true;
                a.cursorLocked = true;
                Canvas.SetActive(false);
                GameObject Koli = Instantiate(Kutu, new Vector3(Location.transform.position.x, Location.transform.position.y + 0.5f, Location.transform.position.z), Location.transform.rotation);
                Koli.GetComponent<KoliObject>().ObjeCode = Objectcode;
                Koli.GetComponent<KoliObject>().BuildSystem = BuildSystem;
                Destroy(Location);
            }

        }
    }
}