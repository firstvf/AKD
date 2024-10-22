using UnityEngine;

namespace Assets.Project.Scripts
{
    public class TakeItemSystem : MonoBehaviour
    {
        [SerializeField] private Transform _pointer;
        [SerializeField] private Transform _itemsParent;
        [SerializeField] private Transform _holdItemParent;
        [SerializeField] private float _rayCastRange;
        [SerializeField] private Transform _interaction;
        [SerializeField] private LayerMask _layerMask;
        private bool _isItemHold;
        private Item _item;

        public bool IsItemSelected { get; private set; }

        private void Update()
        {
            RayCastSelectable();
            PickUpItem();
            IsItemSelected = false;
        }

        private void OnDrawGizmos()
        {
            Gizmos.DrawRay(_interaction.position, _interaction.forward * _rayCastRange);
        }

        private void PickUpItem()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                if (!_isItemHold && _item != null && IsItemSelected)
                {
                    _item.Rigidbody.isKinematic = true;
                    _isItemHold = true;
                    _item.transform.position = _holdItemParent.transform.position;
                    _item.transform.SetParent(_holdItemParent);
                }
                else if (_isItemHold)
                {
                    _item.transform.SetParent(_itemsParent);
                    _item.Rigidbody.isKinematic = false;
                    _isItemHold = false;
                }
            }
        }

        private void RayCastSelectable()
        {
            if (_isItemHold)
            {
                _pointer.gameObject.SetActive(false);
                return;
            }
            else _pointer.gameObject.SetActive(true);

            var ray = new Ray(_interaction.position, _interaction.forward);

            if (Physics.Raycast(ray, out RaycastHit hitInfo, _rayCastRange, _layerMask))
            {
                _pointer.position = hitInfo.point;

                if (hitInfo.collider.gameObject.TryGetComponent(out Item item))
                {
                    IsItemSelected = true;
                    _item = item;
                }
            }
        }
    }
}